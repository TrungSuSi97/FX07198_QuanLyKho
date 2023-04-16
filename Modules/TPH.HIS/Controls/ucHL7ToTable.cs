using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHapi.Base.Model;
using NHapi.Base.Parser;
using NHapi.Model.V25.Segment;
using NHapi.Model.V25.Group;
using NHapi.Model.V25.Message;
using NHapiTools.Base.Model;
using NHapiTools.Base.Parser;
using System.IO;
using TPH.Data.HIS.Models;
using TPH.Data.HIS;

namespace HL7Parser
{
    public partial class ucHL7ToTable : UserControl
    {
        public ucHL7ToTable()
        {
            InitializeComponent();
        }
        private IHL7v25Service hl7v25 = new HL7v25Services();
        private void btnHL7ToDataTable_Click(object sender, EventArgs e)
        {
            try
            {
                var datadetail = hl7v25.DataOrderFromHL7Message(txtHL7Message.Text.Replace("\\r", "\r").Replace("\\n", "\n").Replace("\\\\&", "\\&"));
                dtgData.Columns.Clear();
                dtgData.AutoGenerateColumns = true;
                BindingSource bs = new BindingSource();
                bs.DataSource = datadetail;
                bvData.BindingSource = bs;
                dtgData.DataSource = bs;
                dtgData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //public void DataFromHL7Message(string HL7Message)
        //{
        //    txtParseResult.Text = String.Empty;
        //    bvData.BindingSource = null;
        //    dtgData.DataSource = null;
        //    dtgData.Columns.Clear();
        //    var enhancedModelClassFactory = new OML_O21();
        //    var pipeParser = new PipeParser();
        //    var ourHl7Message = pipeParser.Parse(HL7Message, new ParserOptions());
        //    OML_O21 wrappedOML = (OML_O21)ourHl7Message;
        //    var objInfo = new HL7PatientInfo();
        //    Get_PID(objInfo, wrappedOML.PATIENT.PID);
        //    Get_PV1(objInfo, wrappedOML.PATIENT.PATIENT_VISIT.PV1);
        //    Get_IN_Insurance(objInfo, wrappedOML.PATIENT.GetINSURANCE(0).IN1);

        //    //GET ORDERS
        //    var orderList = wrappedOML.GetORDER();
        //    var prior_RESULTs = orderList.OBSERVATION_REQUEST.PRIOR_RESULTs;

        //    var lstDetailAll = new List<HL7_OrderADT_Detail>();
        //    //GET FIRST ORDER
        //    var obr1 = orderList.OBSERVATION_REQUEST.OBR;
        //    var orc1 = orderList.ORC;
        //    var objDetail_First = new HL7_OrderADT_Detail();
        //    Get_OBR(objDetail_First, orderList.OBSERVATION_REQUEST.OBR);
        //    GetInfo_ORC(objDetail_First, orderList.ORC);

        //    if (orderList.OBSERVATION_REQUEST.NTERepetitionsUsed > 0)
        //        Get_NTE(objDetail_First, orderList.OBSERVATION_REQUEST.NTEs.ToList());
        //    if (orderList.OBSERVATION_REQUEST.SPECIMENRepetitionsUsed > 0)
        //        Get_SPM(objDetail_First, orderList.OBSERVATION_REQUEST.SPECIMENs.First().SPM);

        //    Get_DG_FromOrder(objDetail_First, orderList.OBSERVATION_REQUEST);

        //    if (orderList.TIMINGRepetitionsUsed > 0)
        //        Get_TQ(objDetail_First, orderList.TIMINGs.First().TQ1);

        //    lstDetailAll.Add(objDetail_First);
        //    //GET OTHER ORDER(S)
        //    if (prior_RESULTs.Any())
        //    {
        //        var pResult = prior_RESULTs.ToList();
        //        var objDetailOther = new HL7_OrderADT_Detail();
        //        foreach (OML_O21_PRIOR_RESULT item in pResult)
        //        {
        //            var lstOrc = item.ORDER_PRIORs;
        //            foreach (OML_O21_ORDER_PRIOR itemOrc in lstOrc)
        //            {
        //                if (itemOrc.OBR.PlacerOrderNumber.EntityIdentifier.Value != null)
        //                {
        //                    Get_OBR(objDetailOther, itemOrc.OBR);
        //                    Get_DG_FromOrder_Prior(objDetailOther, itemOrc);
        //                    if (itemOrc.NTERepetitionsUsed > 0)
        //                        Get_NTE(objDetailOther, itemOrc.NTEs.ToList());
        //                    Get_SPM_FromOrder_Prior(objDetailOther, itemOrc);
        //                    lstDetailAll.Add(objDetailOther);
        //                    objDetailOther = new HL7_OrderADT_Detail();
        //                }
        //                else
        //                {
        //                    GetInfo_ORC(objDetailOther, itemOrc.ORC);
        //                    if (itemOrc.TIMING_PRIORRepetitionsUsed > 0)
        //                        Get_TQ(objDetailOther, itemOrc.TIMING_PRIORs.First().TQ1);
        //                }
        //            }
        //        }
        //    }
        //    //SHOW RESULT => TEXT
        //    LogToDebugConsole("--- PATIENT INFO ---");
        //    WriteLog_Object(objInfo);
        //    LogToDebugConsole("--- ORDER DETAIL ---");
        //    int iCount = 0;
        //    foreach (var itmChiDinh in lstDetailAll)
        //    {
        //        iCount++;
        //        LogToDebugConsole(String.Format("DETAIL OF ORDER: {0}", iCount));
        //        WriteLog_Object(itmChiDinh);
        //    }
        //    //SHOW RESULT => CONVERT TO DATATABLE
        //    var lstPinfo = new List<HL7PatientInfo>(){
        //        objInfo
        //    };
        //    var dataInfo = ConvertToDataTable(lstPinfo);
        //    var datadetail = ConvertToDataTable(lstDetailAll);
        //    int ordinal = dataInfo.Columns.Count;
        //    int icount = -1;
        //    foreach (DataColumn dtc in dataInfo.Columns)
        //    {
        //        icount++;
        //        datadetail.Columns.Add(dtc.ColumnName, dtc.DataType);
        //        datadetail.Columns[dtc.ColumnName].SetOrdinal(icount);
        //    }
        //    foreach (DataRow dataRow in datadetail.Rows)
        //    {
        //        foreach (DataColumn dtcI in dataInfo.Columns)
        //        {
        //            dataRow[dtcI.ColumnName] = dataInfo.Rows[0][dtcI.ColumnName];
        //        }
        //    }
        //    dtgData.Columns.Clear();
        //    dtgData.AutoGenerateColumns = true;
        //    BindingSource bs = new BindingSource();
        //    bs.DataSource = datadetail;
        //    bvData.BindingSource = bs;
        //    dtgData.DataSource = bs;
        //    dtgData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        //}
        //private void Get_PID(HL7PatientInfo objInfo, PID itemPID)
        //{
        //    objInfo.PID_PatientName = itemPID.GetPatientName(0).GivenName.Value;
        //    objInfo.PID_Gender = itemPID.AdministrativeSex.Value;
        //    objInfo.PID_SetPID = itemPID.SetIDPID.Value;
        //    if (itemPID.PatientIdentifierListRepetitionsUsed > 0)
        //        objInfo.PID_PatientIndentifierList = itemPID.GetPatientIdentifierList(0).IDNumber.Value;
        //    objInfo.PID_PatientPID = itemPID.PatientID.IDNumber.Value;
        //    if (itemPID.PatientAddressRepetitionsUsed > 0)
        //    {
        //        objInfo.PID_Address = itemPID.GetPatientAddress(0).StreetAddress.StreetOrMailingAddress.Value;
        //        objInfo.PID_Country = itemPID.GetPatientAddress(0).Country.Value;
        //    }
        //    if (itemPID.PhoneNumberHomeRepetitionsUsed >= 0)
        //    {
        //        objInfo.PID_TelephoneNumber = itemPID.GetPhoneNumberHome(0).TelephoneNumber.Value;
        //        objInfo.PID_UnformattedTelephoneNumber = itemPID.GetPhoneNumberHome(0).UnformattedTelephoneNumber.Value;
        //    }

        //    objInfo.PID_Birthday = itemPID.DateTimeOfBirth.Time.GetAsDate().Date;
        //}
        //private void Get_PV1(HL7PatientInfo objInfo, PV1 itemPV1)
        //{
        //    objInfo.PV_PatientClass = itemPV1.PatientClass.Value;
        //    objInfo.PV_VisitNumber = itemPV1.VisitNumber.IDNumber.Value;
        //    objInfo.PV_AssignedPatientLocation_Room = itemPV1.AssignedPatientLocation.Components[1].ToString();
        //    objInfo.PV_AssignedPatientLocation_Bed = itemPV1.AssignedPatientLocation.Components[2].ToString();
        //    objInfo.PV_AssignedPatientLocation_LocationDescription = itemPV1.AssignedPatientLocation.Components[8].ToString();
        //    var doctor = itemPV1.GetAttendingDoctor(0);
        //    objInfo.PV_AttendingDoctor_IDNumber = doctor.IDNumber.Value;
        //    objInfo.PV_AttendingDoctor_FamilyName = doctor.FamilyName.Components[0].ToString();
        //}
        //private void Get_IN_Insurance(HL7PatientInfo objInfo, IN1 itemIN1)
        //{
        //    objInfo.IN_Insurance_ID = itemIN1.InsurancePlanID.Identifier.Value;
        //    if (itemIN1.InsuranceCompanyIDRepetitionsUsed > 0)
        //        objInfo.IN_Insurance_Company = itemIN1.GetInsuranceCompanyID(0).IDNumber.Value;
        //}
        //private void GetInfo_ORC(HL7ORC_ADT_Detail objInd, ORC itemORC)
        //{
        //    objInd.ORC_OrderControlType = itemORC.OrderControl.Value;
        //    objInd.ORC_DateOfTransaction = new DateTime(itemORC.DateTimeOfTransaction.Time.Year, itemORC.DateTimeOfTransaction.Time.Month, itemORC.DateTimeOfTransaction.Time.Day, itemORC.DateTimeOfTransaction.Time.Hour, itemORC.DateTimeOfTransaction.Time.Minute, itemORC.DateTimeOfTransaction.Time.Second, 0);
        //    objInd.ORC_PlaceOrderNumber = itemORC.PlacerOrderNumber.EntityIdentifier.Value;
        //    objInd.ORC_EntererLocation_Facility = itemORC.EntererSLocation.Facility.NamespaceID.Value;
        //    objInd.ORC_EntererLocation_LocationDescription = itemORC.EntererSLocation.LocationDescription.Value;
        //    objInd.ORC_EntereringOriganization_Identifier = itemORC.EnteringOrganization.Identifier.Value;
        //    objInd.ORC_EntereringOriganization_Text = itemORC.EnteringOrganization.Text.Value;
        //    if (itemORC.OrderingProviderAddressRepetitionsUsed > 0)
        //    {
        //        objInd.ORC_OrderingProviderAddress_City = itemORC.GetOrderingProviderAddress(0).City.Value;
        //        objInd.ORC_OrderingProviderAddress_StreetAddress = itemORC.GetOrderingProviderAddress(0).StreetAddress.StreetOrMailingAddress.Value;
        //        objInd.ORC_OrderingProviderAddress_StateProvince = itemORC.GetOrderingProviderAddress(0).StateOrProvince.Value;
        //    }
        //    if (itemORC.OrderingProviderRepetitionsUsed > 0)
        //    {
        //        objInd.ORC_OrderingProvider_ID = itemORC.GetOrderingProvider(0).IDNumber.Value;
        //        objInd.ORC_OrderingProvider_FamailyName = itemORC.GetOrderingProvider(0).FamilyName.Surname.Value;
        //        objInd.ORC_OrderingProvider_DegreeEgMD = itemORC.GetOrderingProvider(0).DegreeEgMD.Value;
        //    }
        //}
        //private void Get_OBR(HL7ORC_ADT_Detail objInd, OBR itemOBR)
        //{
        //    objInd.OBR_SetOrderID = itemOBR.SetIDOBR.Value;
        //    objInd.OBR_PlaceOrderNumber = itemOBR.PlacerOrderNumber.EntityIdentifier.Value;
        //    objInd.OBR_OrderServiceCode = itemOBR.UniversalServiceIdentifier.Identifier.Value;
        //    objInd.OBR_OrderServiceName = itemOBR.UniversalServiceIdentifier.Text.Value;
        //    objInd.OBR_MasterOrderServiceCode = itemOBR.UniversalServiceIdentifier.AlternateIdentifier.Value;

        //}
        //private void Get_DG(HL7_OrderADT_Detail objInd, DG1 itemDG)
        //{
        //    objInd.DG_Diagnosis_ID = itemDG.DiagnosisCodeDG1.Identifier.Value;
        //    objInd.DG_Diagnosis_Text = itemDG.DiagnosisCodeDG1.Text.Value;
        //}
        //private void Get_DG_FromOrder(HL7_OrderADT_Detail objInd, OML_O21_OBSERVATION_REQUEST itemDG)
        //{
        //    try
        //    {
        //        var compo = itemDG.GetAll("DG1");
        //        foreach (var item in compo)
        //        {
        //            var dg = (DG1)item;
        //            objInd.DG_Diagnosis_ID = dg.DiagnosisCodeDG1.Identifier.Value;
        //            objInd.DG_Diagnosis_Text = dg.DiagnosisCodeDG1.Text.Value;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
        //private void Get_DG_FromOrder_Prior(HL7_OrderADT_Detail objInd, OML_O21_ORDER_PRIOR itemDG)
        //{
        //    try
        //    {
        //        var compo = itemDG.GetAll("DG1");

        //        foreach (var item in compo)
        //        {
        //            var dg = (DG1)item;
        //            objInd.DG_Diagnosis_ID = dg.DiagnosisCodeDG1.Identifier.Value;
        //            objInd.DG_Diagnosis_Text = dg.DiagnosisCodeDG1.Text.Value;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //}
        //private void Get_TQ(HL7_OrderADT_Detail objInd, TQ1 itemTQ)
        //{
        //    objInd.TQ_Piority_ID = itemTQ.GetPriority(0).Identifier.Value;
        //    objInd.TQ_Piority_Text = itemTQ.GetPriority(0).Text.Value;
        //}
        //private void Get_NTE(HL7_OrderADT_Detail objInd, List<NTE> itemLstNTE)
        //{
        //    foreach (NTE itemNTE in itemLstNTE)
        //    {
        //        if (itemNTE.CommentRepetitionsUsed > 0)
        //        {
        //            var obj = itemNTE.GetComment(0).ExtraComponents;
        //            objInd.NTE_Comment_ID = itemNTE.GetComment(0).Value;
        //            objInd.NTE_Comment_Text = itemNTE.GetComment(0).ExtraComponents.GetComponent(0).Data.ToString();
        //        }
        //    }
        //}
        //private void Get_SPM(HL7_OrderADT_Detail objInd, SPM itemSPM)
        //{
        //    if (itemSPM.SpecimenAdditivesRepetitionsUsed > 0)
        //    {
        //        objInd.SPM_Specimen_Identifier = itemSPM.GetSpecimenAdditives(0).Identifier.Value;
        //        objInd.SPM_Specimen_Text = itemSPM.GetSpecimenAdditives(0).Text.Value;
        //    }
        //}
        //private void Get_SPM_FromOrder_Prior(HL7_OrderADT_Detail objInd, OML_O21_ORDER_PRIOR itemSource)
        //{
        //    try
        //    {
        //        var compo = itemSource.GetAll("SPM");
        //        foreach (var item in compo)
        //        {
        //            var itemSPM = (SPM)item;
        //            if (itemSPM.SpecimenAdditivesRepetitionsUsed > 0)
        //            {
        //                objInd.SPM_Specimen_Identifier = itemSPM.GetSpecimenAdditives(0).Identifier.Value;
        //                objInd.SPM_Specimen_Text = itemSPM.GetSpecimenAdditives(0).Text.Value;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
 
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
    
        private void btnClearSource_Click(object sender, EventArgs e)
        {
            txtHL7Message.Text = String.Empty;
        }

        private void btnXuatXML_Click(object sender, EventArgs e)
        {
            if (dtgData.DataSource != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "XML|*.xml";
                var data = (DataTable)((BindingSource)dtgData.DataSource).DataSource;
                //foreach (DataRow dataRow in data.Rows)
                //{
                //    foreach (DataColumn dataColumn in data.Columns)
                //    {
                //        if (string.IsNullOrEmpty(dataRow[dataColumn.ColumnName].ToString()) && dataColumn.DataType != typeof(DateTime))
                //        {
                //            dataRow[dataColumn.ColumnName] = string.Empty;
                //        }
                //    }
                //}
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    data.TableName = "HL7Data";
                    using (Stream xmlFileStream = sfd.OpenFile())
                    {
                        data.WriteXml(xmlFileStream, XmlWriteMode.IgnoreSchema);
                    }
                }
            }
        }

        private void btnConvertResultHL7_Click(object sender, EventArgs e)
        {
            try
            {
                var datadetail =
                hl7v25.DataResultFromHL7Message(txtHL7Message.Text.Replace("\\r", "\r").Replace("\\n", "\n").Replace("\\\\&", "\\&"));
                dtgData.Columns.Clear();
                dtgData.AutoGenerateColumns = true;
                BindingSource bs = new BindingSource();
                bs.DataSource = datadetail;
                bvData.BindingSource = bs;
                dtgData.DataSource = bs;
                dtgData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }
    }
}
