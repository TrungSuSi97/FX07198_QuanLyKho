using System;
using TPH.ViettelSignCertificate.Constants;
using TPH.ViettelSignCertificate.Extensions;
using TPH.ViettelSignCertificate.Models.Requests;
using TPH.ViettelSignCertificate.Models.Responses;

namespace TPH.ViettelSignCertificate.Services.Impl
{
    public class SignCertificateImpl: ISignCertificate
    {
        public CerInfoResponse GetCertInfo(GetCerInfoRequest request)
        {
            if (!request.IsValid())
            {
                return new CerInfoResponse()
                {
                    Code = SignMessageConstant.InvalidInputCode,
                    Message = SignMessageConstant.InvalidInputMessage
                };
            }

            try
            {
                var xmlFormat = GetCerInfoRequestXml(request.AppCode, request.Password, request.SerialNumber);
                var result = WebExtension.PostXml(request.ApiUrl, xmlFormat);

                if (result.Code == SignMessageConstant.SuccessCode)
                {
                    var resultObj = ConverterExtension.DeserializeObject<CerInfoEnvelope>(result.Message);
                    var content = resultObj.Body.GetCertInfoResponse.Return;

                    if (content.Status.ToLower().Equals("true"))
                    {
                        return new CerInfoResponse()
                        {
                            Code = SignMessageConstant.SuccessCode,
                            Message = SignMessageConstant.SuccessMessage,

                            Company = content.CertBO.Dn,
                            ISSUER = content.CertBO.Issuer,
                            Name = content.CertBO.Name,
                            Serial = content.CertBO.Serial,
                            ValidFrom = content.CertBO.ValidFr,
                            ValidTo = content.CertBO.ValidTo
                        };
                    }

                    return new CerInfoResponse()
                    {
                        Code = content.ObjectError.ErrorCode,
                        Message = content.ObjectError.ErrorDesc
                    };
                }

                return new CerInfoResponse()
                {
                    Code = result.Code,
                    Message = result.Message
                };
            }
            catch (Exception ex)
            {
                return new CerInfoResponse()
                {
                    Code = SignMessageConstant.UnknowErrorCode,
                    Message = ex.Message
                };
            }
        }

        public PdfBase64Response SignPdfBase64(SignPdfBase64Request request)
        {
            if (!request.IsValid())
            {
                return new PdfBase64Response()
                {
                    Code = SignMessageConstant.InvalidInputCode,
                    Message = SignMessageConstant.InvalidInputMessage
                };
            }

            try
            {
                var xmlFormat = GetSignPdfBase64RequestXml(request.AppCode, request.Password,
                                                    request.SerialNumber, request.FileContent, 
                                                    request.DigestAlgorithm);
                var result = WebExtension.PostXml(request.ApiUrl, xmlFormat);

                if (result.Code == SignMessageConstant.SuccessCode)
                {
                    var resultObj = ConverterExtension.DeserializeObject<SignPdfBase64Envelope>(result.Message);
                    var content = resultObj.Body.SignPdfBase64Response.Return;

                    if (content.Status.ToLower().Equals("true"))
                    {
                        return new PdfBase64Response()
                        {
                            Code = SignMessageConstant.SuccessCode,
                            Message = SignMessageConstant.SuccessMessage,

                            FileContent = content.SignedFileBase64
                        };
                    }

                    return new PdfBase64Response()
                    {
                        Code = content.ObjectError.ErrorCode,
                        Message = content.ObjectError.ErrorDesc
                    };
                }

                return new PdfBase64Response()
                {
                    Code = result.Code,
                    Message = result.Message
                };
            }
            catch (Exception ex)
            {
                return new PdfBase64Response()
                {
                    Code = SignMessageConstant.UnknowErrorCode,
                    Message = ex.Message
                };
            }
        }

        public PdfBase64RectangleTextResponse SignPdfBase64RectangleText(SignPdfBase64RectangleTextRequest request)
        {
            if (!request.IsValid())
            {
                return new PdfBase64RectangleTextResponse()
                {
                    Code = SignMessageConstant.InvalidInputCode,
                    Message = SignMessageConstant.InvalidInputMessage
                };
            }

            try
            {
                var xmlFormat = GetSignPdfBase64RectangleTextRequestXml(request);
                var result = WebExtension.PostXml(request.ApiUrl, xmlFormat);

                if (result.Code == SignMessageConstant.SuccessCode)
                {
                    var resultObj = ConverterExtension.DeserializeObject<PdfBase64RectangleTextEnvelope>(result.Message);
                    var content = resultObj.Body.SignPdfBase64RectangleTextResponse.Return;

                    if (content.Status.ToLower().Equals("true"))
                    {
                        return new PdfBase64RectangleTextResponse()
                        {
                            Code = SignMessageConstant.SuccessCode,
                            Message = SignMessageConstant.SuccessMessage,

                            FileContent = content.SignedFileBase64
                        };
                    }

                    return new PdfBase64RectangleTextResponse()
                    {
                        Code = content.ObjectError.ErrorCode,
                        Message = content.ObjectError.ErrorDesc
                    };
                }

                return new PdfBase64RectangleTextResponse()
                {
                    Code = result.Code,
                    Message = result.Message
                };
            }
            catch (Exception ex)
            {
                return new PdfBase64RectangleTextResponse()
                {
                    Code = SignMessageConstant.UnknowErrorCode,
                    Message = ex.Message
                };
            }
        }

        private string GetCerInfoRequestXml(string username, string password, string serial)
        {
            var xmlFormat =
                "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ws=\"http://ws.viettel.com/\">" +
                "    <soapenv:Header/>" +
                "    <soapenv:Body>" +
                "       <ws:getCertInfo>" +
                "          <arg0>" + username + "</arg0>" +
                "          <arg1>" + password + "</arg1>" +
                "          <arg2>" + serial + "</arg2>" +
                "       </ws:getCertInfo>" +
                "    </soapenv:Body>" +
                " </soapenv:Envelope>";

            return xmlFormat;
        }
        private string GetSignPdfBase64RequestXml(string username, string password, string serial, 
            string fileContent, string digestAlgorithm)
        {
            var xmlFormat =
                "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ws=\"http://ws.viettel.com/\">" +
                "    <soapenv:Header/>" +
                "    <soapenv:Body>" +
                "       <ws:signPdfBase64>" +
                "          <arg0>" + username + "</arg0>" +
                "          <arg1>" + password + "</arg1>" +
                "          <arg2>" + serial + "</arg2>" +
                "          <arg3>" + fileContent + "</arg3>" +
                "          <arg4>" + digestAlgorithm + "</arg4>" +
                "       </ws:signPdfBase64>" +
                "    </soapenv:Body>" +
                " </soapenv:Envelope>";

            return xmlFormat;
        }
        private string GetSignPdfBase64RectangleTextRequestXml(SignPdfBase64RectangleTextRequest request)
        {
            var xmlFormat =
                "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ws=\"http://ws.viettel.com/\">" +
                "    <soapenv:Header/>" +
                "    <soapenv:Body>" +
                "       <ws:signPdfBase64RectangleText>" +
                "          <arg0>" + request.AppCode + "</arg0>" +
                "          <arg1>" + request.Password + "</arg1>" +
                "          <arg2>" + request.SerialNumber + "</arg2>" +
                "          <arg3>" + request.FileContent + "</arg3>" +
                "          <arg4>" + request.DigestAlgorithm + "</arg4>" +
                "          <arg5>";
            if (request.DisplayRectangle != null)
            {
                if (!string.IsNullOrWhiteSpace(request.DisplayRectangle.Contact))
                {
                    xmlFormat += "               <contact>" + request.DisplayRectangle.Contact + "</contact>";
                }

                if (!string.IsNullOrWhiteSpace(request.DisplayRectangle.Reason))
                {
                    xmlFormat += "               <reason>" + request.DisplayRectangle.Reason + "</reason>";
                }
                if (!string.IsNullOrWhiteSpace(request.DisplayRectangle.DateFormat))
                {
                    xmlFormat += "               <dateFormatString>" + request.DisplayRectangle.DateFormat + "</dateFormatString>";
                }
                if (!string.IsNullOrWhiteSpace(request.DisplayRectangle.DisplayText))
                {
                    xmlFormat += "               <displayText>" + request.DisplayRectangle.DisplayText + "</displayText>";
                }
                if (!string.IsNullOrWhiteSpace(request.DisplayRectangle.FormatRectangleText))
                {
                    xmlFormat += "               <formatRectangleText>" + request.DisplayRectangle.FormatRectangleText.Replace(@"\r\n", Environment.NewLine) + "</formatRectangleText>";
                }

                if (request.DisplayRectangle.LocateSign > 0)
                {
                    xmlFormat += "               <locateSign>" + request.DisplayRectangle.LocateSign + "</locateSign>";
                }
                if (!string.IsNullOrWhiteSpace(request.DisplayRectangle.Location))
                {
                    xmlFormat += "               <location>" + request.DisplayRectangle.Location + "</location>";
                }
                if (request.DisplayRectangle.WidthRectangle > 0)
                {
                    xmlFormat += "               <widthRectangle>" + request.DisplayRectangle.WidthRectangle + "</widthRectangle>";
                }
                if (request.DisplayRectangle.HeightRectangle > 0)
                {
                    xmlFormat += "               <heightRectangle>" + request.DisplayRectangle.HeightRectangle + "</heightRectangle>";
                }
                if (request.DisplayRectangle.MarginBottomOfRectangle > 0)
                {
                    xmlFormat += "               <marginBottomOfRectangle>" + request.DisplayRectangle.MarginBottomOfRectangle + "</marginBottomOfRectangle>";
                }
                if (request.DisplayRectangle.MarginLeftOfRectangle > 0)
                {
                    xmlFormat += "               <marginLeftOfRectangle>" + request.DisplayRectangle.MarginLeftOfRectangle + "</marginLeftOfRectangle>";
                }
                if (request.DisplayRectangle.MarginRightOfRectangle > 0)
                {
                    xmlFormat += "               <marginRightOfRectangle>" + request.DisplayRectangle.MarginRightOfRectangle + "</marginRightOfRectangle>";
                }
                if (request.DisplayRectangle.MarginTopOfRectangle > 0)
                {
                    xmlFormat += "               <marginTopOfRectangle>" + request.DisplayRectangle.MarginTopOfRectangle + "</marginTopOfRectangle>";
                }
                if (request.DisplayRectangle.NumberPageSign > 0)
                {
                    xmlFormat += "               <numberPageSign>" + request.DisplayRectangle.NumberPageSign + "</numberPageSign>";
                }
                if (!string.IsNullOrWhiteSpace(request.DisplayRectangle.Organization))
                {
                    xmlFormat += "               <organization>" + request.DisplayRectangle.Organization + "</organization>";
                }
                if (!string.IsNullOrWhiteSpace(request.DisplayRectangle.OrganizationUnit))
                {
                    xmlFormat += "               <organizationUnit>" + request.DisplayRectangle.OrganizationUnit + "</organizationUnit>";
                }
                if (request.DisplayRectangle.SignDate != null)
                {
                    xmlFormat += "               <signDate>" + request.DisplayRectangle.SignDate + "</signDate>";
                }
                if (request.DisplayRectangle.FontSize > 0)
                {
                    xmlFormat += "               <sizeFont>" + request.DisplayRectangle.FontSize + "</sizeFont>";
                }
            }

            xmlFormat += 
                "          </arg5>" +
                "          <arg6></arg6>" +
                "       </ws:signPdfBase64RectangleText>" +
                "    </soapenv:Body>" +
                " </soapenv:Envelope>";

            return xmlFormat;
        }

    }
}
