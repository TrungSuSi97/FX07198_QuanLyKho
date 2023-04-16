using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPH.LIS.User.Models
{
    public class UserLogInPermission
    {
        public string HeThong { get; set; }
        public string NhomQuyen { get; set; }
        public string LoaiDichVu { get; set; }
        public List<string> DanhSachQuyen { get; set; }
    }
}
