using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace TPH.ViettelSignCertificate.Extensions
{
    public class ConverterExtension
    {
        public static T DeserializeObject<T>(string xml)
        {
            xml = xml.
                    Replace("S:", string.Empty).
                    Replace("ns2:", string.Empty).
                    Replace("xmlns:S=\"http://schemas.xmlsoap.org/soap/envelope/\"", string.Empty).
                    Replace("xmlns:ns2=\"http://ws.viettel.com/\"", string.Empty);

            var serializer = new XmlSerializer(typeof(T));
            using (var tr = new StringReader(xml))
            {
                return (T)serializer.Deserialize(tr);
            }
        }
    }
}