using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPH.Language.Models;

namespace TPH.Language.Services
{
    public interface IAppLanguage
    {
        object Get_InfoForObject(object objInfo, DataRow drInfo);
        int Insert_HeThong_NgonNgu(HETHONG_NGONNGU objInfo);
        int Update_HeThong_NgonNgu(HETHONG_NGONNGU objInfo);
        int Delete_HeThong_NgonNgu(int id);
        DataTable Data_HeThong_NgonNgu(int? id, string idNgonNgu);
        HETHONG_NGONNGU Get_Info_HeThong_NgonNgu(DataRow drInfo);
        HETHONG_NGONNGU Get_Info_HeThong_NgonNgu(int id);
        bool CheckExists_HeThong_NgonNgu(int? id, string idNgonNgu);
    }
}
