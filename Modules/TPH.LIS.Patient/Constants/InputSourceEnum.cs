using System.Collections.Generic;
using System.Data;

namespace TPH.LIS.Patient.Constants
{
    public enum InputSourceEnum
   {
       Normal = 1,
       ByList = 2,
       NHM = 3,
       SangLocSoSinh = 4,
       SangLocTruocSinh = 5,
       ByListHIS = 6,
       ByHIS = 7
    }
    public class InputSourceType
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public static List<InputSourceType> DanhSachInput()
        {
            var lst = new List<InputSourceType>();
            lst.Add(new InputSourceType
            {
                ID = InputSourceEnum.Normal.ToString(),
                Description = "Tiếp nhận thủ công",
            });
            lst.Add(new InputSourceType
            {
                ID = InputSourceEnum.ByList.ToString(),
                Description = "Nhập theo danh sách"
            });
            lst.Add(new InputSourceType
            {
                ID = InputSourceEnum.ByHIS.ToString(),
                Description = "Tiếp nhận từ HIS"
            });
            lst.Add(new InputSourceType
            {
                ID = InputSourceEnum.ByListHIS.ToString(),
                Description = "Danh sách HIS"
            });
            return lst;
        }
    }
}
