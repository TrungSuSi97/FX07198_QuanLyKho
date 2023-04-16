using System.Xml.Serialization;

namespace TPH.ViettelSignCertificate.Models.Responses
{
    [XmlRoot(ElementName = "return")]
    public class SignPdfBase64Return
    {
        [XmlElement(ElementName = "status")]
        public string Status { get; set; }

        [XmlElement(ElementName = "objectError")]
        public ObjectError ObjectError { get; set; } = new ObjectError();

        [XmlElement(ElementName = "signedFileBase64")]
        public string SignedFileBase64 { get; set; }
    }

    [XmlRoot(ElementName = "signPdfBase64Response")]
    public class SignPdfBase64Response
    {
        [XmlElement(ElementName = "return")]
        public SignPdfBase64Return Return { get; set; }

        //[XmlAttribute(AttributeName = "ns2")]
        //public string Ns2 { get; set; }
    }

    [XmlRoot(ElementName = "Body")]
    public class SignPdfBase64Body
    {
        [XmlElement(ElementName = "signPdfBase64Response")]
        public SignPdfBase64Response SignPdfBase64Response { get; set; }
    }

    [XmlRoot(ElementName = "Envelope")]
    public class SignPdfBase64Envelope
    {
        [XmlElement(ElementName = "Body")]
        public SignPdfBase64Body Body { get; set; }


        //[XmlAttribute(AttributeName = "S")]
        //public string S { get; set; }
    }
}
