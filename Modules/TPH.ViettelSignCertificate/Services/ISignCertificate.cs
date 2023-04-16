using TPH.ViettelSignCertificate.Models.Requests;
using TPH.ViettelSignCertificate.Models.Responses;

namespace TPH.ViettelSignCertificate.Services
{
    public interface ISignCertificate
    {
        CerInfoResponse GetCertInfo(GetCerInfoRequest request);
        PdfBase64Response SignPdfBase64(SignPdfBase64Request request);
        PdfBase64RectangleTextResponse SignPdfBase64RectangleText(SignPdfBase64RectangleTextRequest request);
    }
}
