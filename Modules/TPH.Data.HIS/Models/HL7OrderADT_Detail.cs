using NHapi.Model.V26.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPH.Data.HIS.Models
{
    public class HL7AbnormalFlags
    {
        public const string Normal = "N";
        public const string AboveHighNormal = "H";
        public const string BelowLowNormal = "L";
        public const string Negative = "NEG";
        public const string Positive = "POS";
        public const string NonReactive = "NR";
    }
    public class HL7DataType
    {
        public const string StringData = "ST";
        public const string Time = "TM";
        public const string Numeric = "NM";
        public const string Money = "MO";
        public const string TextData = "TX";
    }
    public class HL7OrderControl
    {
        public const string NewOrder = "NW";
        public const string CancelOrder = "CA";
        public const string OrderReleased = "OE";
        public const string DiscontinueOrder = "DC";
        public const string StatusChange = "SC";
    }
    public class HL7MessageMSHStruct
    {
        public const string FieldSeparator = "|";
        public const string EncodingCharacters = "^~\\&";
        public const string SendingApplication = "HL7_TPH.LabIMS";
        public const string SendingFacility = "TPH.LabIMS";
        public const string ReceivingApplication = "HIS";
        public const string ReceivingFacility = "ISofH";
        public const string ReturnResult_MessageStruct = "ORU_R01";
        public const string ReturnResult_MessageCode = "ORU";
        public const string ReturnResult_ActionTriger = "R011";
        public const string ReturnResult_ProcessingID = "P";

        public const string ReturnStatus_MessageStruct = "OML_O21";
        public const string ReturnStatus_MessageCode = "OML";
        public const string ReturnStatus_ActionTriger = "O21";
        public const string ReturnStatus_ProcessingID = "P";
    }
    public class HL7MessagePIDStruct
    {
        public const string SetID_PID = "1";
    }
    public class HL7MessagePVStruct
    {
        public const string SetID_PV = "1";
    }
    public class HL7PatientInfo
    {
        public string MSH_MessageControlID { get; set; }
        public string PID_PatientName { get; set; }
        public string PID_MotherSMaidenName_GivenName { get; set; }
        public string PID_SetPID { get; set; }
        public string PID_PatientPID { get; set; }
        public string PID_PatientIndentifierList { get; set; }
        public string PID_Gender { get; set; }
        public string PID_Address { get; set; }
        public string PID_City { get; set; }
        public string PID_UnformattedTelephoneNumber { get; set; }
        public string PID_TelephoneNumberOrHome { get; set; }
        public string PID_Country { get; set; }
        public DateTime PID_Birthday { get; set; }
        public string PID_PatientName_GivenName { get; set; }
        public string PID_Administrative_Sex_1 { get; set; }
        public string PID_Administrative_Sex_2 { get; set; }
        public string PID_PatientAlias_GivenName { get; set; }
        public string PID_PatientAddress_StreetAddress { get; set; }
        public string PID_PatientAddress_OtherDesignation { get; set; }
        public string PID_PhoneNumber_Bussiness { get; set; }
        /// <summary>
        /// O: Outpatient - I: Inpatient - E: Emergency
        /// </summary>
        public string PV_PatientClass { get; set; }
        public string PV_VisitNumber { get; set; }
        public string PV_AssignedPatientLocation_PointOfCare { get; set; }
        public string PV_AssignedPatientLocation_Room { get; set; }
        public string PV_AssignedPatientLocation_Bed { get; set; }
        public string PV_AssignedPatientLocation_Facility { get; set; }
        public string PV_AssignedPatientLocation_LocationStatus { get; set; }
        public string PV_AssignedPatientLocation_PersonLocationType { get; set; }
        public string PV_AssignedPatientLocation_Building { get; set; }
        public string PV_AssignedPatientLocation_Floor { get; set; }
        public string PV_AssignedPatientLocation_LocationDescription { get; set; }
        public string PV_AttendingDoctor_IDNumber { get; set; }
        public string PV_AttendingDoctor_FamilyName { get; set; }
        public string IN_Insurance_ID { get; set; }
        public string IN_Insurance_Company { get; set; }
    }
    public class HL7ORC_ADT_Detail
    {
        public string ORC_OrderControlType { get; set; }
        public string ORC_PlaceOrderNumber { get; set; }
        public DateTime? ORC_DateOfTransaction { get; set; }
        public string ORC_OrderingProvider_ID { get; set; }
        public string ORC_OrderingProvider_FamailyName { get; set; }
        public string ORC_EnteredBy_IdNumber { get; set; }
        public string ORC_EnteredBy_FamilyName { get; set; }
        public string ORC_ActionBy_IdNumber { get; set; }
        public string ORC_ActionBy_FamilyName { get; set; }
        public string ORC_OrderingProvider_DegreeEgMD { get; set; }
        public string ORC_EntererLocation_PointOfCare { get; set; }
        public string ORC_EntererLocation_Room { get; set; }
        public string ORC_EntererLocation_Bed { get; set; }
        public string ORC_EntererLocation_Facility { get; set; }
        public string ORC_EntererLocation_LocationStatus { get; set; }
        public string ORC_EntererLocation_PersonalLocationType { get; set; }
        public string ORC_EntererLocation_Building { get; set; }
        public string ORC_EntererLocation_Floor { get; set; }
        public string ORC_EntererLocation_LocationDescription { get; set; }
        public string ORC_EntererSLocation_Room { get; set; }
        public string ORC_OrderingProviderAddress_StreetAddress { get; set; }
        public string ORC_OrderingProviderAddress_City { get; set; }
        public string ORC_OrderingProviderAddress_StateProvince { get; set; }
        public string ORC_OrderingFacilityAddress_StreetAddress { get; set; }
        public string ORC_OrderingFacilityAddress_City { get; set; }
        public string ORC_OrderingFacilityAddress_StateOrProvince { get; set; }
        public string ORC_EntereringOriganization_Identifier { get; set; }
        public string ORC_EntereringOriganization_Text { get; set; }
        public string ORC_OrderControlCodeReason_Identifier { get; set; }
        public string ORC_OrderControlCodeReason_Text { get; set; }
        public DateTime? ORC_OrderEffectiveDateTime { get; set; }
        public DateTime? ORC_FillerSExpectedAvailabilityDateTime { get; set; }
        public string ORC_OrderingProviderAddress_OrtherDesignation { get; set; }
        public string TQ_Piority_ID { get; set; }
        public string TQ_Piority_Text { get; set; }
        public string OBR_SetOrderID { get; set; }
        public string OBR_PlaceOrderNumber { get; set; }
        public string OBR_UniversalServiceIdentifier_Identifier { get; set; }
        public string OBR_UniversalServiceIdentifier_Text { get; set; }
        public string OBR_UniversalServiceIdentifier_AlternateIdentifier { get; set; }
        public string OBR_UniversalServiceIdentifier_AlternateText { get; set; }
        public string OBR_ResultStatus { get; set; }
        public string OBR_CollectorIndetifier_IdNumber { get; set; }
        public string OBR_CollectorIndetifier_FamilyName { get; set; }
        public string NTE_Comment_ID { get; set; }
        public string NTE_Comment_Text { get; set; }
        public string DG_Diagnosis_ID { get; set; }
        public string DG_Diagnosis_Text { get; set; }
        public string SPM_Specimen_ParrentIDs { get; set; }
        public string SPM_Specimen_ID { get; set; }
        public string SPM_SpecimenType_Identifier { get; set; }
        public string SPM_SpecimenType_Text { get; set; }
        public string NTE_SourceOfComment { get; internal set; }
    }
    public class HL7OBX
    {
        public string OBX_SetIDOBX { get; set; }
        public string OBX_ValueType { get; set; } = HL7DataType.StringData;
        public string OBX_ObservationIdentifier_Identifier { get; set; }
        public string OBX_ObservationIdentifier_Text { get; set; }
        public string OBX_ObservcationSubID { get; set; }
        public string OBX_ObservationValue { get; set; }
        public string OBX_Unit_Identifier { get; set; }
        public string OBX_Unit_Text { get; set; }
        public string OBX_ReferencesRange { get; set; }
        public string OBX_AbnormalFlags { get; set; }
        public string OBX_Probability { get; set; }
        public string OBX_NatureOfAbnormalTest { get; set; }
        public string OBX_ObservationResultStatus { get; set; }
        public string OBX_EffectiveDateOfReferencesRange { get; set; }
        public string OBX_UserDefinedAccessChecks { get; set; }
        public DateTime? OBX_DateTimeOfTheObservation { get; set; }
        public string OBX_PrducerS_ID { get; set; }
        public string OBX_ResponsibleObserver_IDNumber { get; set; }
        public string OBX_ResponsibleObserver_Family { get; set; }
        public string OBX_ObservationMethod { get; set; }
        public string OBX_EquipmentInstanceIdentifier { get; set; }
        //public string NTE_SourceOfComment { get; set; }
        //public string NTE_Comment { get; set; }
        //public string NTE_CommentType { get; set; }
    }
    public class HL7ResultUpload
    {
        public HL7PatientInfo hL7Patient { get; set; }
        public HL7ORC_ADT_Detail hL7ORCResult { get; set; }
        public HL7OBX hL7OBXResult { get; set; }
        public HL7ResultUpload()
        {
            hL7Patient = new HL7PatientInfo();
            hL7ORCResult = new HL7ORC_ADT_Detail();
            hL7OBXResult = new HL7OBX();
        }
    }

}

