namespace TPH.LIS.Common.Model
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BaseModel()
        {
            Id = 0;
            Name = string.Empty;
        }

        public BaseModel(int code, string message)
        {
            Id = code;
            Name = message;
        }
    }
}
