using NHapi.Base.Model;
using NHapi.Base.Parser;
using NHapi.Model.V25.Datatype;
using NHapi.Model.V25.Group;
using NHapi.Model.V25.Message;
using NHapi.Model.V25.Segment;
using NHapiTools.Model.V25.Segment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using TPH.Data.HIS.Models;

namespace TPH.Data.HIS
{
    public class HL7v25Services : IHL7v25Service
    {
        public DataTable DataOrderFromHL7Message(string HL7Message)
        {
            var pipeParser = new PipeParser();
            var ourHl7Message = pipeParser.Parse(HL7Message, new ParserOptions());
            var tructName = ourHl7Message.GetStructureName();
            if (!tructName.Equals("OML_O21"))
                throw (new Exception("Sai định dạng bảng tin OML_O21"));
            OML_O21 wrappedOML = (OML_O21)ourHl7Message;
            var objInfo = new HL7PatientInfo();
            objInfo.MSH_MessageControlID = wrappedOML.MSH.MessageControlID.Value;
            Get_PID(objInfo, wrappedOML.PATIENT.PID);
            Get_PV1(objInfo, wrappedOML.PATIENT.PATIENT_VISIT.PV1);
            Get_IN_Insurance(objInfo, wrappedOML.PATIENT.GetINSURANCE(0).IN1);
            //GET ORDERS
            var orderList = wrappedOML.GetORDER();
            var prior_RESULTs = orderList.OBSERVATION_REQUEST.PRIOR_RESULTs;

            var lstDetailAll = new List<HL7ORC_ADT_Detail>();
            //GET FIRST ORDER
            var obr1 = orderList.OBSERVATION_REQUEST.OBR;
            var orc1 = orderList.ORC;
            var objDetail_First = new HL7ORC_ADT_Detail();
            Get_OBR(objDetail_First, orderList.OBSERVATION_REQUEST.OBR);
            GetInfo_ORC(objDetail_First, orderList.ORC);

            if (orderList.OBSERVATION_REQUEST.NTERepetitionsUsed > 0)
                Get_NTE(objDetail_First, orderList.OBSERVATION_REQUEST.NTEs.ToList());
            if (orderList.OBSERVATION_REQUEST.SPECIMENRepetitionsUsed > 0)
                Get_SPM(objDetail_First, orderList.OBSERVATION_REQUEST.SPECIMENs.First().SPM);

            Get_DG_FromOrder(objDetail_First, orderList.OBSERVATION_REQUEST);

            if (orderList.TIMINGRepetitionsUsed > 0)
                Get_TQ(objDetail_First, orderList.TIMINGs.First().TQ1);

            lstDetailAll.Add(objDetail_First);
            //GET OTHER ORDER(S)
            if (prior_RESULTs.Any())
            {
                var pResult = prior_RESULTs.ToList();
                var objDetailOther = new HL7ORC_ADT_Detail();
                foreach (OML_O21_PRIOR_RESULT item in pResult)
                {
                    var lstOrc = item.ORDER_PRIORs;
                    foreach (OML_O21_ORDER_PRIOR itemOrc in lstOrc)
                    {
                        if (itemOrc.OBR.PlacerOrderNumber.EntityIdentifier.Value != null)
                        {
                            Get_OBR(objDetailOther, itemOrc.OBR);
                            Get_DG_FromOrder_Prior(objDetailOther, itemOrc);
                            if (itemOrc.NTERepetitionsUsed > 0)
                                Get_NTE(objDetailOther, itemOrc.NTEs.ToList());
                            Get_SPM_FromOrder_Prior(objDetailOther, itemOrc);
                            lstDetailAll.Add(objDetailOther);
                            objDetailOther = new HL7ORC_ADT_Detail();
                        }
                        else
                        {
                            GetInfo_ORC(objDetailOther, itemOrc.ORC);
                            if (itemOrc.TIMING_PRIORRepetitionsUsed > 0)
                                Get_TQ(objDetailOther, itemOrc.TIMING_PRIORs.First().TQ1);
                        }
                    }
                }
            }
            var lstPinfo = new List<HL7PatientInfo>(){
                objInfo
            };
            var dataInfo = ConvertToDataTable(lstPinfo);
            var datadetail = ConvertToDataTable(lstDetailAll);
            int ordinal = dataInfo.Columns.Count;
            int icount = -1;
            foreach (DataColumn dtc in dataInfo.Columns)
            {
                icount++;
                datadetail.Columns.Add(dtc.ColumnName, dtc.DataType);
                datadetail.Columns[dtc.ColumnName].SetOrdinal(icount);
            }
            foreach (DataRow dataRow in datadetail.Rows)
            {
                foreach (DataColumn dtcI in dataInfo.Columns)
                {
                    dataRow[dtcI.ColumnName] = dataInfo.Rows[0][dtcI.ColumnName];
                }
            }
            return datadetail;
        }
        public DataTable DataResultFromHL7Message(string HL7Message)
        {
            var hl7resultlist = new List<HL7ResultUpload>();
            var pipeParser = new PipeParser();
            var ourHl7Message = pipeParser.Parse(HL7Message, new ParserOptions());
            if (!ourHl7Message.GetStructureName().Equals("ORU_R01"))
                throw (new Exception("Sai định dạng bảng tin ORU_R01"));
            ORU_R01 wrappedOML = (ORU_R01)ourHl7Message;
            var objInfo = new HL7PatientInfo();
            objInfo.MSH_MessageControlID = wrappedOML.MSH.MessageControlID.Value;
            if (wrappedOML.PATIENT_RESULTRepetitionsUsed == 1)
            {
                Get_PID(objInfo, wrappedOML.PATIENT_RESULTs.FirstOrDefault().PATIENT.PID);
                Get_PV1(objInfo, wrappedOML.PATIENT_RESULTs.FirstOrDefault().PATIENT.VISIT.PV1);
            }
            var orderList = wrappedOML.GetPATIENT_RESULT();
            var prior_RESULTs = orderList.ORDER_OBSERVATIONs;
            //GET RESULT(S)
            if (prior_RESULTs.Any())
            {
                var pResult = prior_RESULTs.ToList();
                var objDetailOther = new HL7ResultUpload();
                foreach (ORU_R01_ORDER_OBSERVATION item in pResult)
                {
                    var lstOBSERVATION = item.OBSERVATIONs;
                    Get_OBR(objDetailOther.hL7ORCResult, item.OBR);
                    GetInfo_ORC(objDetailOther.hL7ORCResult, item.ORC);
                    foreach (ORU_R01_OBSERVATION itemOBSERVATION in lstOBSERVATION)
                    {
                        Get_OBX(objDetailOther.hL7OBXResult, itemOBSERVATION.OBX);
                    }
                    hl7resultlist.Add(objDetailOther);
                    objDetailOther = new HL7ResultUpload();
                }
            }
            var dataInfo = ConvertToDataTable(new List<HL7PatientInfo> { objInfo });
            var datadetail = new DataTable();
            foreach (var itmdetail in hl7resultlist)
            {
                var dataORC_OBR = ConvertToDataTable(new List<HL7ORC_ADT_Detail> { itmdetail.hL7ORCResult });
                var dataOBX = ConvertToDataTable(new List<HL7OBX> { itmdetail.hL7OBXResult });
                int icountSub = -1;
                foreach (DataColumn dtc in dataOBX.Columns)
                {
                    icountSub++;
                    dataORC_OBR.Columns.Add(dtc.ColumnName, dtc.DataType);
                    dataORC_OBR.Columns[dtc.ColumnName].SetOrdinal(icountSub);
                }
                foreach (DataRow dataRow in dataORC_OBR.Rows)
                {
                    foreach (DataColumn dtcI in dataOBX.Columns)
                    {
                        dataRow[dtcI.ColumnName] = dataOBX.Rows[0][dtcI.ColumnName];
                    }
                }
                if (datadetail.Rows.Count == 0)
                    datadetail = dataORC_OBR;
                else
                    datadetail.Merge(dataORC_OBR);
            }

            int ordinal = dataInfo.Columns.Count;
            int icount = -1;
            foreach (DataColumn dtc in dataInfo.Columns)
            {
                icount++;
                datadetail.Columns.Add(dtc.ColumnName, dtc.DataType);
                datadetail.Columns[dtc.ColumnName].SetOrdinal(icount);
            }
            foreach (DataRow dataRow in datadetail.Rows)
            {
                foreach (DataColumn dtcI in dataInfo.Columns)
                {
                    dataRow[dtcI.ColumnName] = dataInfo.Rows[0][dtcI.ColumnName];
                }
            }
            return datadetail;
        }
        #region  helper functions
        public object Get_ObjectPrpertyValue(object objInfo, string propertiesName)
        {
            return objInfo.GetType().GetProperty(propertiesName).GetValue(objInfo, null);
        }
        public string PropertyName<T>(Expression<Func<T, object>> expression)
        {
            var body = expression.Body as MemberExpression;

            if (body == null)
            {
                body = ((UnaryExpression)expression.Body).Operand as MemberExpression;
            }
            return body.Member.Name;
        }
        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            if (data != null)
            {
                PropertyDescriptorCollection properties =
                    TypeDescriptor.GetProperties(typeof(T));
                DataTable table = new DataTable();
                foreach (PropertyDescriptor prop in properties)
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    table.Rows.Add(row);
                }
                return table;
            }
            else
                return null;
        }
        #endregion
        #region Read Message
        private void Get_PID(HL7PatientInfo objInfo, PID itemPID)
        {
            objInfo.PID_PatientName = itemPID.GetPatientName(0).GivenName.Value;
            objInfo.PID_Gender = itemPID.AdministrativeSex.Value;
            objInfo.PID_SetPID = itemPID.SetIDPID.Value;
            if (itemPID.PatientIdentifierListRepetitionsUsed > 0)
                objInfo.PID_PatientIndentifierList = itemPID.GetPatientIdentifierList(0).IDNumber.Value;
            objInfo.PID_PatientPID = itemPID.PatientID.IDNumber.Value;
            if (itemPID.PatientAddressRepetitionsUsed > 0)
            {
                objInfo.PID_Address = itemPID.GetPatientAddress(0).StreetAddress.StreetOrMailingAddress.Value;
                objInfo.PID_PatientAddress_StreetAddress = itemPID.GetPatientAddress(0).StreetAddress.StreetName.Value;
                objInfo.PID_Country = itemPID.GetPatientAddress(0).Country.Value;
                objInfo.PID_PatientAddress_OtherDesignation = itemPID.GetPatientAddress(0).OtherDesignation.Value;
            }
            if (itemPID.PhoneNumberHomeRepetitionsUsed >= 0)
            {
                objInfo.PID_TelephoneNumberOrHome = itemPID.GetPhoneNumberHome(0).TelephoneNumber.Value;
                objInfo.PID_PhoneNumber_Bussiness = itemPID.GetPhoneNumberHome(0).LocalNumber.Value;
                objInfo.PID_UnformattedTelephoneNumber = itemPID.GetPhoneNumberHome(0).UnformattedTelephoneNumber.Value;
            }
            objInfo.PID_Birthday = itemPID.DateTimeOfBirth.Time.GetAsDate().Date;
            if (itemPID.MotherSMaidenNameRepetitionsUsed > 0)
            {
                objInfo.PID_PatientName_GivenName = itemPID.GetMotherSMaidenName(0).GivenName.Value;
            }
        }
        private void Get_PV1(HL7PatientInfo objInfo, PV1 itemPV1)
        {
            objInfo.PV_PatientClass = itemPV1.PatientClass.Value;
            objInfo.PV_VisitNumber = itemPV1.VisitNumber.IDNumber.Value;
            objInfo.PV_AssignedPatientLocation_Room = itemPV1.AssignedPatientLocation.Components[1].ToString();
            objInfo.PV_AssignedPatientLocation_Bed = itemPV1.AssignedPatientLocation.Components[2].ToString();
            objInfo.PV_AssignedPatientLocation_LocationDescription = itemPV1.AssignedPatientLocation.Components[8].ToString();
            var doctor = itemPV1.GetAttendingDoctor(0);
            objInfo.PV_AttendingDoctor_IDNumber = doctor.IDNumber.Value;
            objInfo.PV_AttendingDoctor_FamilyName = doctor.FamilyName.Components[0].ToString();
        }
        private void Get_IN_Insurance(HL7PatientInfo objInfo, IN1 itemIN1)
        {
            objInfo.IN_Insurance_ID = itemIN1.InsurancePlanID.Identifier.Value;
            if (itemIN1.InsuranceCompanyIDRepetitionsUsed > 0)
                objInfo.IN_Insurance_Company = itemIN1.GetInsuranceCompanyID(0).IDNumber.Value;
        }
        private void GetInfo_ORC(HL7ORC_ADT_Detail objInd, ORC itemORC)
        {
            objInd.ORC_OrderControlType = itemORC.OrderControl.Value;
            objInd.ORC_DateOfTransaction = (itemORC.DateTimeOfTransaction.Time.Value == null ? (DateTime?)null : new DateTime(itemORC.DateTimeOfTransaction.Time.Year, itemORC.DateTimeOfTransaction.Time.Month, itemORC.DateTimeOfTransaction.Time.Day, itemORC.DateTimeOfTransaction.Time.Hour, itemORC.DateTimeOfTransaction.Time.Minute, itemORC.DateTimeOfTransaction.Time.Second, 0));
            objInd.ORC_PlaceOrderNumber = itemORC.PlacerOrderNumber.EntityIdentifier.Value;
            objInd.ORC_EntererLocation_Facility = itemORC.EntererSLocation.Facility.NamespaceID.Value;
            objInd.ORC_EntererLocation_LocationDescription = itemORC.EntererSLocation.LocationDescription.Value;
            objInd.ORC_EntereringOriganization_Identifier = itemORC.EnteringOrganization.Identifier.Value;
            objInd.ORC_EntereringOriganization_Text = itemORC.EnteringOrganization.Text.Value;
            objInd.ORC_EntererSLocation_Room = itemORC.EntererSLocation.Room.Value;
            if (itemORC.OrderingProviderAddressRepetitionsUsed > 0)
            {
                objInd.ORC_OrderingProviderAddress_City = itemORC.GetOrderingProviderAddress(0).City.Value;
                objInd.ORC_OrderingProviderAddress_StreetAddress = itemORC.GetOrderingProviderAddress(0).StreetAddress.StreetOrMailingAddress.Value;
                objInd.ORC_OrderingProviderAddress_StateProvince = itemORC.GetOrderingProviderAddress(0).StateOrProvince.Value;
            }
            if (itemORC.OrderingFacilityAddressRepetitionsUsed > 0)
            {
                objInd.ORC_OrderingFacilityAddress_City = itemORC.GetOrderingFacilityAddress(0).City.Value;
                objInd.ORC_OrderingFacilityAddress_StreetAddress = itemORC.GetOrderingFacilityAddress(0).StreetAddress.StreetOrMailingAddress.Value;
                objInd.ORC_OrderingFacilityAddress_StateOrProvince = itemORC.GetOrderingFacilityAddress(0).StateOrProvince.Value;
            }
            if (itemORC.OrderingProviderRepetitionsUsed > 0)
            {
                objInd.ORC_OrderingProvider_ID = itemORC.GetOrderingProvider(0).IDNumber.Value;
                objInd.ORC_OrderingProvider_FamailyName = itemORC.GetOrderingProvider(0).FamilyName.Surname.Value;
                objInd.ORC_OrderingProvider_DegreeEgMD = itemORC.GetOrderingProvider(0).DegreeEgMD.Value;
            }
            objInd.ORC_OrderControlCodeReason_Identifier = itemORC.OrderControlCodeReason.Identifier.Value;
            objInd.ORC_OrderControlCodeReason_Text = itemORC.OrderControlCodeReason.Text.Value;
        }
        private void Get_OBR(HL7ORC_ADT_Detail objInd, OBR itemOBR)
        {
            objInd.OBR_SetOrderID = itemOBR.SetIDOBR.Value;
            objInd.OBR_PlaceOrderNumber = itemOBR.PlacerOrderNumber.EntityIdentifier.Value;
            objInd.OBR_UniversalServiceIdentifier_Identifier = itemOBR.UniversalServiceIdentifier.Identifier.Value;
            objInd.OBR_UniversalServiceIdentifier_Text = itemOBR.UniversalServiceIdentifier.Text.Value;
            objInd.OBR_UniversalServiceIdentifier_AlternateIdentifier = itemOBR.UniversalServiceIdentifier.AlternateIdentifier.Value;
            objInd.OBR_UniversalServiceIdentifier_AlternateText = itemOBR.UniversalServiceIdentifier.AlternateText.Value;
            objInd.OBR_ResultStatus = itemOBR.ResultStatus.Value;

        }
        private void Get_OBX(HL7OBX objInd, OBX itemOBX)
        {
            objInd.OBX_SetIDOBX = itemOBX.SetIDOBX.Value;
            objInd.OBX_ValueType = itemOBX.ValueType.Value;
            objInd.OBX_ObservationIdentifier_Identifier = itemOBX.ObservationIdentifier.Identifier.Value;
            objInd.OBX_ObservationIdentifier_Text = itemOBX.ObservationIdentifier.Text.Value;
            objInd.OBX_ObservcationSubID = itemOBX.ObservationSubID.Value;
            objInd.OBX_ObservationValue = itemOBX.GetObservationValue(0).Data.ToString();
            objInd.OBX_Unit_Identifier = itemOBX.Units.Identifier.Value;
            objInd.OBX_Unit_Text = itemOBX.Units.Text.Value;
            objInd.OBX_ReferencesRange = itemOBX.ReferencesRange.Value;
            if (itemOBX.AbnormalFlagsRepetitionsUsed == 1)
                objInd.OBX_AbnormalFlags = itemOBX.GetAbnormalFlags(0).Value;
            objInd.OBX_Probability = itemOBX.Probability.Value;
            if (itemOBX.AbnormalFlagsRepetitionsUsed == 1)
                objInd.OBX_NatureOfAbnormalTest = itemOBX.GetNatureOfAbnormalTest(0).Value;
            objInd.OBX_ObservationResultStatus = itemOBX.ObservationResultStatus.Value;
            if (itemOBX.EffectiveDateOfReferenceRange != null)
                objInd.OBX_EffectiveDateOfReferencesRange = (itemOBX.EffectiveDateOfReferenceRange.Time.Value == null ? String.Empty : itemOBX.EffectiveDateOfReferenceRange.Time.ToString());
            objInd.OBX_UserDefinedAccessChecks = itemOBX.UserDefinedAccessChecks.Value;

            objInd.OBX_DateTimeOfTheObservation = (itemOBX.DateTimeOfTheObservation.Time.Value == null ? (DateTime?)null : new DateTime(itemOBX.DateTimeOfTheObservation.Time.Year
                , itemOBX.DateTimeOfTheObservation.Time.Month
                , itemOBX.DateTimeOfTheObservation.Time.Day
                , itemOBX.DateTimeOfTheObservation.Time.Hour
                , itemOBX.DateTimeOfTheObservation.Time.Minute, itemOBX.DateTimeOfTheObservation.Time.Second, 0));
            objInd.OBX_PrducerS_ID = itemOBX.ProducerSID.Identifier.Value;
            if (itemOBX.ResponsibleObserverRepetitionsUsed > 0)
            {
                objInd.OBX_ResponsibleObserver_IDNumber = itemOBX.GetResponsibleObserver(0).IDNumber.Value;
                objInd.OBX_ResponsibleObserver_Family = itemOBX.GetResponsibleObserver(0).FamilyName.Surname.Value;
            }
            objInd.OBX_ObservationMethod = itemOBX.GetObservationMethod(0).Text.Value;
            if (itemOBX.EquipmentInstanceIdentifierRepetitionsUsed > 0)
                objInd.OBX_EquipmentInstanceIdentifier = itemOBX.GetEquipmentInstanceIdentifier(0).EntityIdentifier.Value;
        }
        private void Get_DG(HL7ORC_ADT_Detail objInd, DG1 itemDG)
        {
            objInd.DG_Diagnosis_ID = itemDG.DiagnosisCodeDG1.Identifier.Value;
            objInd.DG_Diagnosis_Text = itemDG.DiagnosisCodeDG1.Text.Value;
        }
        private void Get_DG_FromOrder(HL7ORC_ADT_Detail objInd, OML_O21_OBSERVATION_REQUEST itemDG)
        {
            try
            {
                var compo = itemDG.GetAll("DG1");
                foreach (var item in compo)
                {
                    var dg = (DG1)item;
                    objInd.DG_Diagnosis_ID = dg.DiagnosisCodeDG1.Identifier.Value;
                    objInd.DG_Diagnosis_Text = dg.DiagnosisCodeDG1.Text.Value;
                }
            }
            catch (Exception ex)
            { }
        }
        private void Get_DG_FromOrder_Prior(HL7ORC_ADT_Detail objInd, OML_O21_ORDER_PRIOR itemDG)
        {
            try
            {
                var compo = itemDG.GetAll("DG1");
                foreach (var item in compo)
                {
                    var dg = (DG1)item;
                    objInd.DG_Diagnosis_ID = dg.DiagnosisCodeDG1.Identifier.Value;
                    objInd.DG_Diagnosis_Text = dg.DiagnosisCodeDG1.Text.Value;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void Get_TQ(HL7ORC_ADT_Detail objInd, TQ1 itemTQ)
        {
            objInd.TQ_Piority_ID = itemTQ.GetPriority(0).Identifier.Value;
            objInd.TQ_Piority_Text = itemTQ.GetPriority(0).Text.Value;
        }
        private void Get_NTE(HL7ORC_ADT_Detail objInd, List<NTE> itemLstNTE)
        {
            foreach (NTE itemNTE in itemLstNTE)
            {
                if (itemNTE.CommentRepetitionsUsed > 0)
                {
                    var obj = itemNTE.GetComment(0).ExtraComponents;
                    objInd.NTE_Comment_ID = itemNTE.GetComment(0).Value;
                    objInd.NTE_Comment_Text = itemNTE.GetComment(0).ExtraComponents.GetComponent(0).Data.ToString();
                }
            }
        }
        private void Get_SPM(HL7ORC_ADT_Detail objInd, SPM itemSPM)
        {
            if (itemSPM.SpecimenAdditivesRepetitionsUsed > 0)
            {
                objInd.SPM_Specimen_ID = itemSPM.SpecimenID.PlacerAssignedIdentifier.UniversalID.Value;
                // objInd.SPM_Specimen_ParrentIDs = itemSPM.GetSpecimenParentIDs(0).Message.ToString();
                objInd.SPM_SpecimenType_Identifier = itemSPM.SpecimenType.Identifier.Value;
                objInd.SPM_SpecimenType_Text = itemSPM.SpecimenType.Text.Value;
            }
        }
        private void Get_SPM_FromOrder_Prior(HL7ORC_ADT_Detail objInd, OML_O21_ORDER_PRIOR itemSource)
        {
            try
            {
                var compo = itemSource.GetAll("SPM");
                foreach (var item in compo)
                {
                    var itemSPM = (SPM)item;
                    if (itemSPM.SpecimenAdditivesRepetitionsUsed > 0)
                    {
                        objInd.SPM_SpecimenType_Identifier = itemSPM.SpecimenType.Identifier.Value;
                        objInd.SPM_SpecimenType_Text = itemSPM.SpecimenType.Text.Value;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region Create Message
        public string DataStatusToHL7(List<HL7ResultUpload> dataUpload)
        {
            var patientHL7 = dataUpload.First().hL7Patient;
            var oruMessage = new OML_O21();
            CreateMshSegment(oruMessage.MSH
                , HL7MessageMSHStruct.ReturnResult_MessageCode
                , HL7MessageMSHStruct.ReturnResult_MessageStruct
                , HL7MessageMSHStruct.ReturnResult_ActionTriger
                , GetTimeStamp()
                , HL7MessageMSHStruct.ReturnResult_ProcessingID
                , patientHL7.MSH_MessageControlID);

            CreatePidSegment(oruMessage.PATIENT.PID, patientHL7);
            CreatePv1Segment(oruMessage.PATIENT.PATIENT_VISIT.PV1, patientHL7);
            int iCount = -1;
            foreach (var item in dataUpload)
            {
                iCount++;
                var ourOrderObservation = oruMessage.GetORDER();

                CreateORCSegment(ourOrderObservation.ORC
                  , item.hL7ORCResult);
                CreateOBRSegment(ourOrderObservation.OBSERVATION_REQUEST.OBR
                  , item.hL7ORCResult);
            }
            //instantiate a PipeParser, which handles the "traditional encoding" 
            PipeParser pipeParser = new PipeParser();
            return pipeParser.Encode(oruMessage.Message);
        }
        public string DataResultToHL7(List<HL7ResultUpload> dataUpload)
        {
            var patientHL7 = dataUpload.First().hL7Patient;
            var oruMessage = new ORU_R01();
            CreateMshSegment(oruMessage.MSH
                , HL7MessageMSHStruct.ReturnResult_MessageCode
                , HL7MessageMSHStruct.ReturnResult_MessageStruct
                , HL7MessageMSHStruct.ReturnResult_ActionTriger
                , GetTimeStamp()
                , HL7MessageMSHStruct.ReturnResult_ProcessingID
                , patientHL7.MSH_MessageControlID);

            CreatePidSegment(oruMessage.GetPATIENT_RESULT().PATIENT.PID, patientHL7);
            CreatePv1Segment(oruMessage.GetPATIENT_RESULT().PATIENT.VISIT.PV1, patientHL7);

            int iCount = 0;
            foreach (var item in dataUpload)
            {
                iCount++;
                oruMessage.GetPATIENT_RESULT().AddORDER_OBSERVATION();
                var ourOrderObservation = oruMessage.GetPATIENT_RESULT().GetORDER_OBSERVATION(iCount);

                item.hL7ORCResult.OBR_SetOrderID = iCount.ToString();
                CreateORCSegment(ourOrderObservation.ORC
                  , item.hL7ORCResult);
                CreateOBRSegment(ourOrderObservation.OBR
                  , item.hL7ORCResult);
                var OBSERVATION = ourOrderObservation.AddOBSERVATION();
                CreateOBXSegment(oruMessage, ourOrderObservation, OBSERVATION.OBX
                    , item.hL7OBXResult, iCount);
                CreateNTESegment(OBSERVATION.AddNTE(), item.hL7ORCResult.NTE_Comment_Text, "RE", item.hL7ORCResult.NTE_SourceOfComment, 1);
            }
            //instantiate a PipeParser, which handles the "traditional encoding" 
            PipeParser pipeParser = new PipeParser();
            return pipeParser.Encode(oruMessage.Message);
        }
        public string DataOrderStatusToHL7(List<HL7ResultUpload> dataUpload)
        {
            var patientHL7 = dataUpload.First().hL7Patient;
            var oruMessage = new OML_O21();
            CreateMshSegment(oruMessage.MSH
                , HL7MessageMSHStruct.ReturnStatus_MessageCode
                , HL7MessageMSHStruct.ReturnStatus_MessageStruct
                , HL7MessageMSHStruct.ReturnStatus_ActionTriger
                , GetTimeStamp()
                , HL7MessageMSHStruct.ReturnStatus_ProcessingID
                , patientHL7.MSH_MessageControlID);

            CreatePidSegment(oruMessage.PATIENT.PID, patientHL7);
            CreatePv1Segment(oruMessage.PATIENT.PATIENT_VISIT.PV1, patientHL7);


            int iCount = 0;
            foreach (var item in dataUpload)
            {
                iCount++;
                var orderList = oruMessage.AddORDER();
                CreateORCSegment(orderList.ORC
                  , item.hL7ORCResult);
                item.hL7ORCResult.OBR_SetOrderID = iCount.ToString();
                CreateOBRSegment(orderList.OBSERVATION_REQUEST.OBR
                  , item.hL7ORCResult);
            }
            //instantiate a PipeParser, which handles the "traditional encoding" 
            PipeParser pipeParser = new PipeParser();
            return pipeParser.Encode(oruMessage.Message);
        }
        //Create MSH
        private void CreateMshSegment(MSH mshSegment
            , string messageCode
            , string messageStruct
            , string messageTrigerEvent
            , string currentDateTimeString
            , string processingId
            , string patientPatientOrderId)
        {
            mshSegment.FieldSeparator.Value = HL7MessageMSHStruct.FieldSeparator;
            mshSegment.EncodingCharacters.Value = HL7MessageMSHStruct.EncodingCharacters;
            mshSegment.SendingApplication.NamespaceID.Value = HL7MessageMSHStruct.SendingApplication;
            mshSegment.SendingFacility.NamespaceID.Value = HL7MessageMSHStruct.SendingFacility;
            mshSegment.ReceivingApplication.NamespaceID.Value = HL7MessageMSHStruct.SendingApplication;
            mshSegment.ReceivingFacility.NamespaceID.Value = HL7MessageMSHStruct.SendingFacility;
            mshSegment.DateTimeOfMessage.Time.Value = currentDateTimeString;
            mshSegment.MessageControlID.Value = patientPatientOrderId;
            mshSegment.MessageType.MessageCode.Value = messageCode;
            mshSegment.MessageType.MessageStructure.Value = messageStruct;
            mshSegment.MessageType.TriggerEvent.Value = messageTrigerEvent;
            mshSegment.VersionID.VersionID.Value = "2.5";
            mshSegment.ProcessingID.ProcessingID.Value = processingId;
            mshSegment.AcceptAcknowledgmentType.Value = "AL";
            mshSegment.ApplicationAcknowledgmentType.Value = "ER";
            mshSegment.CountryCode.Value = "VNM";
            mshSegment.GetCharacterSet(0).Value = "UNICODE UTF-8";
        }
        private void CreateEvnSegment(EVN evn, string currentDateTimeString)
        {
            evn.EventTypeCode.Value = "A01";
            evn.RecordedDateTime.Time.Value = currentDateTimeString;
        }
        private void CreatePidSegment(PID pid, HL7PatientInfo patient)
        {
            pid.SetIDPID.Value = HL7MessagePIDStruct.SetID_PID;
            pid.PatientID.IDNumber.Value = patient.PID_PatientPID;
            pid.GetPatientIdentifierList(0).IDNumber.Value = patient.PID_PatientIndentifierList;
            pid.GetPatientName(0).FamilyName.Surname.Value = patient.PID_PatientName;
            pid.GetMotherSMaidenName(0).GivenName.Value = patient.PID_MotherSMaidenName_GivenName;
            pid.DateTimeOfBirth.Time.Value = GetTimeStamp(patient.PID_Birthday);
            var patientAddress = pid.GetPatientAddress(0);
            patientAddress.StreetAddress.StreetOrMailingAddress.Value = patient.PID_Address;
            patientAddress.StreetAddress.StreetName.Value = patient.PID_PatientAddress_StreetAddress;

            patientAddress.City.Value = patient.PID_City;
            patientAddress.Country.Value = patient.PID_Country;
            pid.GetPhoneNumberHome(0).TelephoneNumber.Value = patient.PID_TelephoneNumberOrHome;
            pid.GetPhoneNumberHome(0).LocalNumber.Value = patient.PID_PhoneNumber_Bussiness;

            pid.GetPhoneNumberHome(0).UnformattedTelephoneNumber.Value = patient.PID_UnformattedTelephoneNumber;
            pid.GetPatientName(0).GivenName.Value = patient.PID_PatientName_GivenName;
            pid.GetPatientAlias(0).GivenName.Value = patient.PID_PatientAlias_GivenName;
            if (!string.IsNullOrEmpty(patient.PID_Administrative_Sex_1) && !string.IsNullOrEmpty(patient.PID_Administrative_Sex_2))
                pid.AdministrativeSex.Value = string.Format("{0}^{1}", patient.PID_Administrative_Sex_1, patient.PID_Administrative_Sex_2);
            else if (!string.IsNullOrEmpty(patient.PID_Administrative_Sex_1))
                pid.AdministrativeSex.Value = string.Format("{0}", patient.PID_Administrative_Sex_1);
            else if (!string.IsNullOrEmpty(patient.PID_Administrative_Sex_2))
                pid.AdministrativeSex.Value = string.Format("^{0}", patient.PID_Administrative_Sex_2);
        }
        private void CreatePv1Segment(PV1 pv1, HL7PatientInfo patient)
        {
            pv1.SetIDPV1.Value = HL7MessagePVStruct.SetID_PV;
            pv1.PatientClass.Value = patient.PV_PatientClass;
            var assignedPatientLocation = pv1.AssignedPatientLocation;
            assignedPatientLocation.LocationDescription.Value = patient.PV_AssignedPatientLocation_LocationDescription;
            assignedPatientLocation.Room.Value = patient.PV_AssignedPatientLocation_Room;
            assignedPatientLocation.Bed.Value = patient.PV_AssignedPatientLocation_Bed;
            pv1.GetAttendingDoctor(0).IDNumber.Value = patient.PV_AttendingDoctor_IDNumber;
            pv1.GetAttendingDoctor(0).FamilyName.Surname.Value = patient.PV_AttendingDoctor_FamilyName;
            pv1.VisitNumber.IDNumber.Value = patient.PV_VisitNumber;
        }
        private void Create_IN_Insurance(IN1 itemIN1, HL7PatientInfo pInfo)
        {
            itemIN1.InsurancePlanID.Identifier.Value = pInfo.IN_Insurance_ID;
            if (!string.IsNullOrEmpty(pInfo.IN_Insurance_Company))
                itemIN1.GetInsuranceCompanyID(0).IDNumber.Value = pInfo.IN_Insurance_Company;
        }
        private void CreateORCSegment(ORC orc, HL7ORC_ADT_Detail orcInfo)
        {
            orc.OrderControl.Value = orcInfo.ORC_OrderControlType;
            orc.PlacerOrderNumber.EntityIdentifier.Value = orcInfo.ORC_PlaceOrderNumber ?? "3";
            orc.GetOrderingProvider(0).IDNumber.Value = orcInfo.ORC_OrderingProvider_ID;
            orc.GetOrderingProvider(0).FamilyName.Surname.Value = orcInfo.ORC_OrderingProvider_FamailyName;
            orc.GetEnteredBy(0).IDNumber.Value = orcInfo.ORC_EnteredBy_IdNumber;
            orc.GetEnteredBy(0).FamilyName.Surname.Value = orcInfo.ORC_EnteredBy_FamilyName;
            orc.GetActionBy(0).IDNumber.Value = orcInfo.ORC_ActionBy_IdNumber;
            orc.GetActionBy(0).FamilyName.Surname.Value = orcInfo.ORC_ActionBy_FamilyName;
            orc.OrderEffectiveDateTime.Time.Value = orcInfo.ORC_OrderEffectiveDateTime == null ? string.Empty : GetTimeStamp(orcInfo.ORC_OrderEffectiveDateTime.Value, false);
            orc.FillerSExpectedAvailabilityDateTime.Time.Value = orcInfo.ORC_OrderEffectiveDateTime == null ? string.Empty : GetTimeStamp(orcInfo.ORC_FillerSExpectedAvailabilityDateTime.Value, false);
            orc.EntererSLocation.Facility.NamespaceID.Value = orcInfo.ORC_EntererLocation_Facility;
            orc.EntererSLocation.LocationDescription.Value = orcInfo.ORC_EntererLocation_LocationDescription;
            orc.DateTimeOfTransaction.Time.Value = GetTimeStamp(orcInfo.ORC_DateOfTransaction, true);
            orc.GetOrderingProviderAddress(0).StreetAddress.StreetOrMailingAddress.Value = orcInfo.ORC_OrderingProviderAddress_StreetAddress;
            orc.GetOrderingProviderAddress(0).City.Value = orcInfo.ORC_OrderingProviderAddress_City;
            orc.GetOrderingProviderAddress(0).OtherDesignation.Value = orcInfo.ORC_OrderingProviderAddress_OrtherDesignation;

            orc.OrderControlCodeReason.Identifier.Value = orcInfo.ORC_OrderControlCodeReason_Identifier;
            orc.OrderControlCodeReason.Text.Value = orcInfo.ORC_OrderControlCodeReason_Text;
            orc.GetOrderingFacilityAddress(0).City.Value = orcInfo.ORC_OrderingFacilityAddress_City;
            orc.GetOrderingFacilityAddress(0).StreetAddress.StreetOrMailingAddress.Value = orcInfo.ORC_OrderingFacilityAddress_StreetAddress;
            orc.GetOrderingFacilityAddress(0).StateOrProvince.Value = orcInfo.ORC_OrderingFacilityAddress_StateOrProvince;

        }

        private void CreateOBRSegment(OBR obr, HL7ORC_ADT_Detail obrInfo)
        {
            obr.SetIDOBR.Value = obrInfo.OBR_SetOrderID;
            obr.PlacerOrderNumber.EntityIdentifier.Value = obrInfo.OBR_PlaceOrderNumber;
            obr.UniversalServiceIdentifier.Identifier.Value = obrInfo.OBR_UniversalServiceIdentifier_Identifier;
            obr.UniversalServiceIdentifier.Text.Value = obrInfo.OBR_UniversalServiceIdentifier_Text;
            obr.UniversalServiceIdentifier.AlternateIdentifier.Value = obrInfo.OBR_UniversalServiceIdentifier_AlternateIdentifier;
            obr.UniversalServiceIdentifier.AlternateText.Value = obrInfo.OBR_UniversalServiceIdentifier_AlternateIdentifier;
            obr.ResultStatus.Value = obrInfo.OBR_ResultStatus;
            obr.GetCollectorIdentifier(0).IDNumber.Value = obrInfo.OBR_CollectorIndetifier_IdNumber;
            obr.GetCollectorIdentifier(0).FamilyName.Surname.Value = obrInfo.OBR_CollectorIndetifier_FamilyName;
        }
        private void CreateNTESegment(NTE nte, string NTE_Comment_Text, string NTE_Comment_Type, string NTE_Comment_Source
           , int icount)
        {

            if (string.IsNullOrEmpty(NTE_Comment_Text)) return;
            nte.SetIDNTE.Value = icount.ToString();
            nte.AddComment().Value = NTE_Comment_Text;
            if (!string.IsNullOrEmpty(NTE_Comment_Type))
                nte.CommentType.Identifier.Value = NTE_Comment_Type;
            if (!string.IsNullOrEmpty(NTE_Comment_Source))
                nte.SourceOfComment.Value = NTE_Comment_Source;

            //encapsulatedData.Value = objInd.NTE_Comment_Text;
            //nte.GetComment(0).ExtraComponents.GetComponent(0).Data = encapsulatedData;

        }
        private void CreateOBXSegment(ORU_R01 oru, ORU_R01_ORDER_OBSERVATION ord, OBX itemOBX, HL7OBX objInd, int icount)
        {

            itemOBX.SetIDOBX.Value = icount.ToString();
            itemOBX.ValueType.Value = objInd.OBX_ValueType;
            itemOBX.ObservationIdentifier.Identifier.Value = objInd.OBX_ObservationIdentifier_Identifier;
            itemOBX.ObservationIdentifier.Text.Value = objInd.OBX_ObservationIdentifier_Text;
            itemOBX.ObservationSubID.Value = objInd.OBX_ObservcationSubID;
            HD encapsulatedData = new HD(oru, "Observation Value");
            encapsulatedData.NamespaceID.Value = objInd.OBX_ObservationValue;
            itemOBX.GetObservationValue(0).Data = encapsulatedData;
            itemOBX.Units.Identifier.Value = objInd.OBX_Unit_Identifier;
            itemOBX.Units.Text.Value = objInd.OBX_Unit_Text;
            itemOBX.ReferencesRange.Value = objInd.OBX_ReferencesRange;

            itemOBX.GetAbnormalFlags(0).Value = objInd.OBX_AbnormalFlags;
            itemOBX.Probability.Value = objInd.OBX_Probability;

            itemOBX.GetNatureOfAbnormalTest(0).Value = objInd.OBX_NatureOfAbnormalTest;
            itemOBX.ObservationResultStatus.Value = objInd.OBX_ObservationResultStatus;

            itemOBX.EffectiveDateOfReferenceRange.Time.Value = objInd.OBX_EffectiveDateOfReferencesRange;
            itemOBX.UserDefinedAccessChecks.Value = objInd.OBX_UserDefinedAccessChecks;
            itemOBX.DateTimeOfTheObservation.Time.Value = (objInd.OBX_DateTimeOfTheObservation == null ? null : GetTimeStamp(objInd.OBX_DateTimeOfTheObservation, false));
            itemOBX.ProducerSID.Identifier.Value = objInd.OBX_PrducerS_ID;

            itemOBX.GetResponsibleObserver(0).IDNumber.Value = objInd.OBX_ResponsibleObserver_IDNumber;
            itemOBX.GetResponsibleObserver(0).FamilyName.Surname.Value = objInd.OBX_ResponsibleObserver_Family;
            itemOBX.GetObservationMethod(0).Text.Value = objInd.OBX_ObservationMethod;
            itemOBX.GetEquipmentInstanceIdentifier(0).EntityIdentifier.Value = objInd.OBX_EquipmentInstanceIdentifier;

        }

        private static string GetTimeStamp(DateTime? date = null, bool withTimeZone = true)
        {
            if (withTimeZone)
            {
                if (date == null)
                    return DateTime.Now.ToString("yyyyMMddHHmmss+0700");
                else
                    return date.Value.ToString("yyyyMMddHHmmss+0700");
            }
            else
            {
                if (date == null)
                    return DateTime.Now.ToString("yyyyMMddHHmmss");
                else
                    return date.Value.ToString("yyyyMMddHHmmss");
            }
        }
        private static string GetSequenceNumber()
        {
            const string facilityNumberPrefix = "1234"; // some arbitrary prefix for the facility
            return facilityNumberPrefix + GetTimeStamp();
        }
        #endregion
    }
}
