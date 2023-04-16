using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using TPH.LabelingMachine.BCRobo.DataAccess;
using TPH.LabelingMachine.BCRobo.DataAccess.Impl;

namespace TPH.LabelingMachine.BCRobo.Connection
{
    [Serializable]
    public class LisReceiverConnectionSettings
    {
        private readonly ISystemDataAccess _systemDataAccess = new SystemDataAccessImpl();

        public string LisReceiverWebserviceAddress { get; set; }

        private const string ConfigFileURL = @"Config\LisReceiverConnectionConfig.xml";

        private static LisReceiverConnectionSettings _config = null;

        public static LisReceiverConnectionSettings GetInstance(string roboIp)
        {
            if (_config == null)
            {
                _config = new LisReceiverConnectionSettings();
                _config.ReloadConfig(roboIp);
                //_config.SaveConfig();
            }

            return _config;
        }

        public LisReceiverConnectionSettings()
        {
            //this.LisReceiverWebserviceAddress = "http://127.0.0.1:8282/LisReceiver/web";
        }

        private void CopyValue(LisReceiverConnectionSettings folderConfig)
        {
            this.LisReceiverWebserviceAddress = folderConfig.LisReceiverWebserviceAddress;
        }

        public void SaveConfig()
        {
            var data = this.Serialize();
            using (var fileStream = new StreamWriter(ConfigFileURL, false))
            {
                fileStream.Write(data);
            }
        }

        public void ReloadConfig1()
        {
            if (!File.Exists(ConfigFileURL))
            {
                var fileInfo = new FileInfo(ConfigFileURL);
                Directory.CreateDirectory(fileInfo.Directory.FullName);

                using (var fileStream = File.Create(ConfigFileURL))
                {
                    var data = this.Serialize();
                    byte[] rawData = UTF8Encoding.UTF8.GetBytes(data);
                    fileStream.Write(rawData, 0, rawData.Length);
                }
            }
            using (TextReader readFileStream = new StreamReader(ConfigFileURL))
            {
                var xmlData = readFileStream.ReadToEnd();
                var folderConfig = Deserialize(xmlData);
                CopyValue(folderConfig);
            }
        }
        public void ReloadConfig(string roboIp)
        {
            this.LisReceiverWebserviceAddress = roboIp;
        }

        public string Serialize()
        {
            string result = null;
            var serializer = new XmlSerializer(typeof(LisReceiverConnectionSettings));
            using (var memoryStream = new MemoryStream())
            {
                var settings = new XmlWriterSettings
                {
                    Encoding = UTF8Encoding.UTF8,
                    Indent = true,
                    OmitXmlDeclaration = true
                };

                using (var xmlTextWriter = XmlWriter.Create(memoryStream, settings))
                {
                    serializer.Serialize(xmlTextWriter, this);
                }

                result = Encoding.UTF8.GetString(memoryStream.ToArray());
            }

            return result;
        }

        public static LisReceiverConnectionSettings Deserialize(string xmlContent)
        {
            LisReceiverConnectionSettings result = null;

            var serializer = new XmlSerializer(typeof(LisReceiverConnectionSettings));
            using (var readStream = new MemoryStream(UTF8Encoding.UTF8.GetBytes(xmlContent)))
            {
                XmlReader reader = new XmlTextReader(readStream);
                result = (LisReceiverConnectionSettings)serializer.Deserialize(reader);
            }

            return result;
        }
    }
}
