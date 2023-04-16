using System.Windows.Forms;
using TPH.LIS.Common;

namespace TPH.LIS.Patient.Constants
{
    public enum enumTrangThaiLayMau
    {
        ChuaThucHien = -1,
        KhongXacDinh = 0,
        YeuCauLayLai = 1,
        ChuaLayDu = 2,
        ChuaLayMau = 3,
        DaLayDu = 4
    }
    public enum enumTrangThaiNhanMau
    {
        ChuaThucHien = -1,
        KhongXacDinh = 0,
        YeuCauLayLai = 1,
        ChuaNhanDu = 2,
        ChuaNhanMau = 3,
        DaNhanDu = 4
    }
    public class TrangThaiLayMau
    {
        public string TrangThaiThuongQui { get; set; }
        public string TrangThaiViSinh { get; set; }
        public string TrangThaiGPB { get; set; }
        public string TrangThaiChung { get; set; }
        public enumTrangThaiLayMau idTrangThaiLayMauTQ { get; set; }
        public enumTrangThaiLayMau idTrangThaiLayMauVS { get; set; }
        public enumTrangThaiLayMau idTrangThaiLayMauGPB { get; set; }
        public enumTrangThaiLayMau idTrangThaiLayMauChung { get; set; }
    }

    public class TrangThaiNhanMau
    {
        public string TrangThaiThuongQui { get; set; }
        public string TrangThaiViSinh { get; set; }
        public string TrangThaiGPB { get; set; }
        public string TrangThaiChung { get; set; }
        public enumTrangThaiNhanMau idTrangThaiNhanMauTQ { get; set; }
        public enumTrangThaiNhanMau idTrangThaiNhanMauVS { get; set; }
        public enumTrangThaiNhanMau idTrangThaiNhanMauGPB { get; set; }
        public enumTrangThaiNhanMau idTrangThaiNhanMauChung { get; set; }
    }
    public class SampleStatus
    {

        public static TrangThaiLayMau Get_TrangLayMau(string statusTQ, string statusVS)
        {
            var langConstant = new MessageConstant();
            var objTrangThai = new TrangThaiLayMau
            {
                idTrangThaiLayMauVS = enumTrangThaiLayMau.KhongXacDinh,
                idTrangThaiLayMauTQ = enumTrangThaiLayMau.KhongXacDinh
            };

            //string subFixTQ = string.IsNullOrEmpty(statusVS) || statusVS == "-1" ? "" : "TQ:";
            //string subFixVS = string.IsNullOrEmpty(statusTQ) || statusTQ == "-1" ? "" : "\nVS:";
            var returnString = string.Empty;
            if (statusTQ.Equals("1"))
            {
                objTrangThai.idTrangThaiLayMauTQ = enumTrangThaiLayMau.YeuCauLayLai;
                objTrangThai.TrangThaiThuongQui = langConstant.MAUDUOCYEUCAULAYLAI;// "MẪU ĐƯỢC YÊU CẦU LẤY LẠI";

            }
            else if (statusTQ.Equals("2"))
            {
                objTrangThai.idTrangThaiLayMauTQ = enumTrangThaiLayMau.ChuaLayDu;
                objTrangThai.TrangThaiThuongQui = langConstant.CHUADUYETLAYMAUDU; //"CHƯA DUYỆT LẤY MẪU ĐỦ";
            }
            else if (statusTQ.Equals("0") || statusTQ.Equals("3"))
            {
                objTrangThai.idTrangThaiLayMauTQ = enumTrangThaiLayMau.ChuaLayMau;
                objTrangThai.TrangThaiThuongQui = langConstant.CHUADUYETLAYMAU; //"CHƯA DUYỆT LẤY MẪU";
            }
            else if (statusTQ.Equals("4"))
            {
                objTrangThai.idTrangThaiLayMauTQ = enumTrangThaiLayMau.DaLayDu;
                objTrangThai.TrangThaiThuongQui = langConstant.DADUYETLAYDUMAU; //"ĐÃ DUYỆT LẤY ĐỦ MẪU";
            }
            else objTrangThai.TrangThaiThuongQui = "";

            if (!string.IsNullOrEmpty(statusVS))
            {
                if (statusVS.Equals("1"))
                {
                    objTrangThai.idTrangThaiLayMauVS = enumTrangThaiLayMau.YeuCauLayLai;
                    objTrangThai.TrangThaiViSinh = langConstant.MAUDUOCYEUCAULAYLAI; //"MẪU ĐƯỢC YÊU CẦU LẤY LẠI";
                }
                else if (statusVS.Equals("2"))
                {
                    objTrangThai.idTrangThaiLayMauVS = enumTrangThaiLayMau.ChuaLayDu;
                    objTrangThai.TrangThaiViSinh = langConstant.CHUADUYETLAYMAUDU; //"CHƯA DUYỆT LẤY MẪU ĐỦ";
                }
                else if (statusVS.Equals("0") || statusVS.Equals("3"))
                {
                    objTrangThai.idTrangThaiLayMauVS = enumTrangThaiLayMau.ChuaLayMau;
                    objTrangThai.TrangThaiViSinh = langConstant.CHUADUYETLAYMAU; //"CHƯA DUYỆT LẤY MẪU";
                }
                else if (statusVS.Equals("4"))
                {
                    objTrangThai.idTrangThaiLayMauVS = enumTrangThaiLayMau.DaLayDu;
                    objTrangThai.TrangThaiViSinh = langConstant.DADUYETLAYDUMAU; //"ĐÃ DUYỆT LẤY ĐỦ MẪU";
                }
                else objTrangThai.TrangThaiViSinh = "";
            }
            objTrangThai.idTrangThaiLayMauChung = enumTrangThaiLayMau.ChuaLayMau;
            if (!string.IsNullOrEmpty(objTrangThai.TrangThaiThuongQui) && !string.IsNullOrEmpty(objTrangThai.TrangThaiViSinh))
            {
                objTrangThai.TrangThaiChung = string.Format(langConstant.TQVS, objTrangThai.TrangThaiThuongQui, objTrangThai.TrangThaiViSinh);
                if (objTrangThai.idTrangThaiLayMauVS == enumTrangThaiLayMau.DaLayDu && objTrangThai.idTrangThaiLayMauTQ == enumTrangThaiLayMau.DaLayDu)
                    objTrangThai.idTrangThaiLayMauChung = enumTrangThaiLayMau.DaLayDu;
                else if (objTrangThai.idTrangThaiLayMauVS == enumTrangThaiLayMau.YeuCauLayLai || objTrangThai.idTrangThaiLayMauTQ == enumTrangThaiLayMau.YeuCauLayLai)
                    objTrangThai.idTrangThaiLayMauChung = enumTrangThaiLayMau.ChuaLayDu;
                else if (objTrangThai.idTrangThaiLayMauVS == enumTrangThaiLayMau.DaLayDu || objTrangThai.idTrangThaiLayMauVS == enumTrangThaiLayMau.ChuaLayDu || objTrangThai.idTrangThaiLayMauTQ == enumTrangThaiLayMau.DaLayDu || objTrangThai.idTrangThaiLayMauTQ == enumTrangThaiLayMau.ChuaLayDu)
                    objTrangThai.idTrangThaiLayMauChung = enumTrangThaiLayMau.ChuaLayDu;
                else
                    objTrangThai.idTrangThaiLayMauChung = enumTrangThaiLayMau.ChuaLayMau;
            }
            else if (!string.IsNullOrEmpty(objTrangThai.TrangThaiThuongQui))
            {
                objTrangThai.TrangThaiChung = objTrangThai.TrangThaiThuongQui;
                objTrangThai.idTrangThaiLayMauChung = objTrangThai.idTrangThaiLayMauTQ;
            }
            else if (!string.IsNullOrEmpty(objTrangThai.TrangThaiViSinh))
            {
                objTrangThai.TrangThaiChung = objTrangThai.TrangThaiViSinh;
                objTrangThai.idTrangThaiLayMauChung = objTrangThai.idTrangThaiLayMauVS;
            }

            return objTrangThai;
        }
        public static TrangThaiNhanMau Get_TrangNhanMau(string statusTQ, string statusVS)
        {
            var langConstant = new MessageConstant();
            var objTrangThai = new TrangThaiNhanMau
            {
                idTrangThaiNhanMauVS = enumTrangThaiNhanMau.KhongXacDinh,
                idTrangThaiNhanMauTQ = enumTrangThaiNhanMau.KhongXacDinh
            };

            //string subFixTQ = string.IsNullOrEmpty(statusVS) || statusVS == "-1" ? "" : "TQ:";
            //string subFixVS = string.IsNullOrEmpty(statusTQ) || statusTQ == "-1" ? "" : "\nVS:";
            var returnString = string.Empty;
            if (statusTQ.Equals("1"))
            {
                objTrangThai.idTrangThaiNhanMauTQ = enumTrangThaiNhanMau.YeuCauLayLai;
                objTrangThai.TrangThaiThuongQui = langConstant.MAUDUOCYEUCAULAYLAI; //"MẪU ĐƯỢC YÊU CẦU LẤY LẠI";
            }
            else if (statusTQ.Equals("2"))
            {
                objTrangThai.idTrangThaiNhanMauTQ = enumTrangThaiNhanMau.ChuaNhanDu;
                objTrangThai.TrangThaiThuongQui = langConstant.CHUADUYETNHANMAUDU; //"CHƯA DUYỆT NHẬN MẪU ĐỦ";
            }
            else if (statusTQ.Equals("0") || statusTQ.Equals("3"))
            {
                objTrangThai.idTrangThaiNhanMauTQ = enumTrangThaiNhanMau.ChuaNhanMau;
                objTrangThai.TrangThaiThuongQui = langConstant.CHUADUYETNHANMAU; //"CHƯA DUYỆT NHẬN MẪU";
            }
            else if (statusTQ.Equals("4"))
            {
                objTrangThai.idTrangThaiNhanMauTQ = enumTrangThaiNhanMau.DaNhanDu;
                objTrangThai.TrangThaiThuongQui = langConstant.DADUYETNHANDUMAU; //"ĐÃ DUYỆT NHẬN ĐỦ MẪU";
            }
            else objTrangThai.TrangThaiThuongQui = "";

            if (!string.IsNullOrEmpty(statusVS))
            {
                if (statusVS.Equals("1"))
                {
                    objTrangThai.idTrangThaiNhanMauVS = enumTrangThaiNhanMau.YeuCauLayLai;
                    objTrangThai.TrangThaiViSinh = langConstant.MAUDUOCYEUCAULAYLAI; //"MẪU ĐƯỢC YÊU CẦU LẤY LẠI";
                }
                else if (statusVS.Equals("2"))
                {
                    objTrangThai.idTrangThaiNhanMauVS = enumTrangThaiNhanMau.ChuaNhanDu;
                    objTrangThai.TrangThaiViSinh = langConstant.CHUADUYETNHANMAUDU; //"CHƯA DUYỆT NHẬN MẪU ĐỦ";
                }
                else if (statusVS.Equals("0") || statusVS.Equals("3"))
                {
                    objTrangThai.idTrangThaiNhanMauVS = enumTrangThaiNhanMau.ChuaNhanMau;
                    objTrangThai.TrangThaiViSinh = langConstant.CHUADUYETNHANMAU; //"CHƯA DUYỆT NHẬN MẪU";
                }
                else if (statusVS.Equals("4"))
                {
                    objTrangThai.idTrangThaiNhanMauVS = enumTrangThaiNhanMau.DaNhanDu;
                    objTrangThai.TrangThaiViSinh = langConstant.DADUYETNHANDUMAU; //"ĐÃ DUYỆT NHẬN ĐỦ MẪU";
                }
                else returnString += "";
            }

            //if (!string.IsNullOrEmpty(objTrangThai.TrangThaiThuongQui) && !string.IsNullOrEmpty(objTrangThai.TrangThaiViSinh))
            //{
            //    objTrangThai.TrangThaiChung = string.Format(langConstant.TQVS, objTrangThai.TrangThaiThuongQui,
            //        objTrangThai.TrangThaiViSinh);
            //}
            //else if (!string.IsNullOrEmpty(objTrangThai.TrangThaiThuongQui))
            //    objTrangThai.TrangThaiChung = objTrangThai.TrangThaiThuongQui;
            //else if (!string.IsNullOrEmpty(objTrangThai.TrangThaiViSinh))
            //    objTrangThai.TrangThaiChung = objTrangThai.TrangThaiViSinh;

            objTrangThai.idTrangThaiNhanMauChung = enumTrangThaiNhanMau.ChuaNhanMau;
            if (!string.IsNullOrEmpty(objTrangThai.TrangThaiThuongQui) && !string.IsNullOrEmpty(objTrangThai.TrangThaiViSinh))
            {
                objTrangThai.TrangThaiChung = string.Format(langConstant.TQVS, objTrangThai.TrangThaiThuongQui, objTrangThai.TrangThaiViSinh);
                if (objTrangThai.idTrangThaiNhanMauVS == enumTrangThaiNhanMau.DaNhanDu && objTrangThai.idTrangThaiNhanMauTQ == enumTrangThaiNhanMau.DaNhanDu)
                    objTrangThai.idTrangThaiNhanMauChung = enumTrangThaiNhanMau.DaNhanDu;
                else if (objTrangThai.idTrangThaiNhanMauVS == enumTrangThaiNhanMau.YeuCauLayLai || objTrangThai.idTrangThaiNhanMauTQ == enumTrangThaiNhanMau.YeuCauLayLai)
                    objTrangThai.idTrangThaiNhanMauChung = enumTrangThaiNhanMau.ChuaNhanDu;
                else if (objTrangThai.idTrangThaiNhanMauVS == enumTrangThaiNhanMau.DaNhanDu || objTrangThai.idTrangThaiNhanMauVS == enumTrangThaiNhanMau.ChuaNhanDu || objTrangThai.idTrangThaiNhanMauTQ == enumTrangThaiNhanMau.DaNhanDu || objTrangThai.idTrangThaiNhanMauTQ == enumTrangThaiNhanMau.ChuaNhanDu)
                    objTrangThai.idTrangThaiNhanMauChung = enumTrangThaiNhanMau.ChuaNhanDu;
                else
                    objTrangThai.idTrangThaiNhanMauChung = enumTrangThaiNhanMau.ChuaNhanMau;
            }
            else if (!string.IsNullOrEmpty(objTrangThai.TrangThaiThuongQui))
            {
                objTrangThai.TrangThaiChung = objTrangThai.TrangThaiThuongQui;
                objTrangThai.idTrangThaiNhanMauChung = objTrangThai.idTrangThaiNhanMauTQ;
            }
            else if (!string.IsNullOrEmpty(objTrangThai.TrangThaiViSinh))
            {
                objTrangThai.TrangThaiChung = objTrangThai.TrangThaiViSinh;
                objTrangThai.idTrangThaiNhanMauChung = objTrangThai.idTrangThaiNhanMauVS;
            }

            return objTrangThai;
        }
    }
}
