using System.Xml.Serialization;

namespace TPH.ViettelSignCertificate.Models.Responses
{
    [XmlRoot(ElementName = "certBO")]
    public class CertBO
    {
        [XmlElement(ElementName = "certStatus")]
        public string CertStatus { get; set; }

        [XmlElement(ElementName = "dn")]
        public string Dn { get; set; }

        [XmlElement(ElementName = "issuer")]
        public string Issuer { get; set; }

        [XmlElement(ElementName = "keyLength")]
        public string KeyLength { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "serial")]
        public string Serial { get; set; }

        [XmlElement(ElementName = "validFr")]
        public string ValidFr { get; set; }

        [XmlElement(ElementName = "validTo")]
        public string ValidTo { get; set; }
    }

    [XmlRoot(ElementName = "objectError")]
    public class ObjectError
    {
        [XmlElement(ElementName = "errorCode")]
        public int ErrorCode { get; set; } = 0;


        [XmlElement(ElementName = "errorDesc")]
        public string ErrorDesc { get; set; } = "";
    }

    [XmlRoot(ElementName = "return")]
    public class CerInfoReturn
    {
        [XmlElement(ElementName = "status")]
        public string Status { get; set; }


        [XmlElement(ElementName = "objectError")]
        public ObjectError ObjectError { get; set; } = new ObjectError();


        [XmlElement(ElementName = "certBO")]
        public CertBO CertBO { get; set; }
    }

    [XmlRoot(ElementName = "getCertInfoResponse")]
    public class GetCertInfoResponse
    {
        [XmlElement(ElementName = "return")]
        public CerInfoReturn Return { get; set; }

        //[XmlAttribute(AttributeName = "ns2")]
        //public string Ns2 { get; set; }
    }

    [XmlRoot(ElementName = "Body")]
    public class CerInfoBody
    {
        [XmlElement(ElementName = "getCertInfoResponse")]
        public GetCertInfoResponse GetCertInfoResponse { get; set; }
    }

    [XmlRoot(ElementName = "Envelope")]
    public class CerInfoEnvelope
    {
        [XmlElement(ElementName = "Body")]
        public CerInfoBody Body { get; set; }

        //[XmlAttribute(AttributeName = "S")]
        //public string S { get; set; }
    }
}
