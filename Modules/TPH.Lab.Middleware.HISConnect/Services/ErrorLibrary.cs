namespace TPH.Lab.Middleware.HISConnect.Services
{
    public class ErrorLibrary
    {
        public static string ConvertErrorToVietNamese(string inputError)
        {
            switch (inputError)
            {
                case
                    "Unable to connect to the remote server":
                    return "KHÔNG THỂ KẾT NỐI TỚI MÁY CHỦ HIS\nHÃY KIỂM TRA LẠI MẠNG HOẶC LIÊN HỆ IT ĐỂ ĐƯỢC HỖ TRỢ.";
                case
                    "Invalid URI: The format of the URI could not be determined.":
                    return "ĐƯỜNG LINK URI KHÔNG ĐÚNG.\nKHÔNG THỂ XÁC ĐỊNH ĐỊNH DẠNG CỦA URI.\nLIÊN HỆ TPH ĐỂ ĐƯỢC HỖ TRỢ.";
                default:
                    return inputError;
            }
        }
    }
}
