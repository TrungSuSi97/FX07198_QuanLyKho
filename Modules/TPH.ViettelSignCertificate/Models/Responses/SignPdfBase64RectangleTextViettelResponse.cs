using System.Xml.Serialization;

namespace TPH.ViettelSignCertificate.Models.Responses
{
    [XmlRoot(ElementName = "return")]
    public class PdfBase64RectangleTextReturn
    {
        [XmlElement(ElementName = "objectError")]
        public ObjectError ObjectError { get; set; }


        [XmlElement(ElementName = "status")]
        public string Status { get; set; }


        [XmlElement(ElementName = "signedFileBase64")]
        public string SignedFileBase64 { get; set; }
    }

    [XmlRoot(ElementName = "signPdfBase64RectangleTextResponse")]
    public class SignPdfBase64RectangleTextResponse
    {
        [XmlElement(ElementName = "return")]
        public PdfBase64RectangleTextReturn Return { get; set; }
        //[XmlAttribute(AttributeName = "ns2")]
        //public string Ns2 { get; set; }
    }

    [XmlRoot(ElementName = "Body")]
    public class PdfBase64RectangleTextBody
    {
        [XmlElement(ElementName = "signPdfBase64RectangleTextResponse")]
        public SignPdfBase64RectangleTextResponse SignPdfBase64RectangleTextResponse { get; set; }
    }

    [XmlRoot(ElementName = "Envelope")]
    public class PdfBase64RectangleTextEnvelope
    {
        [XmlElement(ElementName = "Body")]
        public PdfBase64RectangleTextBody Body { get; set; }
        //[XmlAttribute(AttributeName = "S")]
        //public string S { get; set; }
    }
}
