namespace TPH.HIS.WebAPI.Models.HisReponses
{
    public class OrderResponse: ResultResponse
    {
        public OrderResponse()
        {
            //Data = new List<ChiDinh>();
        }
    }
    public class ChiDinh
    {
        public string Code { get; set; }
        public string PatId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Diagnosis { get; set; }
        public string DateOrder { get; set; }
        public string DatePrint { get; set; }
        public string YearOfBirth { get; set; }
        public string MonthOfBirth { get; set; }
        public string DayOfBirth { get; set; }
        public string BirthDay { get; set; }
        public string GenderId { get; set; }
        public string Gender { get; set; }
        public string ObjectID { get; set; }
        public string ObjectName { get; set; }
        public string DocOrder { get; set; }
        public string DocName { get; set; }
        public string MedexahId { get; set; }
        public string MedexahName { get; set; }
        public string HiID { get; set; }
        public string NoHi { get; set; }
        public string NoRoom { get; set; }
        public string NoBed { get; set; }
        public string Prioritize { get; set; }
        public string Status { get; set; }
        public string TreatmentFormID { get; set; }
    }
}
