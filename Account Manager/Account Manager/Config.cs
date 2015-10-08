using System;
using System.IO;
using System.Xml;
using Account_Manager.Console_Menu;

namespace Account_Manager
{
    public class Config
    {
        // Fields
        private string format = "";
        private string defaultFormat = "xml";

        private string path = "";
        private string defaultPath = "default.xml";

        private string configPath = "config.xml";

        private IDbOperations serializer;


        // Constructors
        public Config()
        {
            CreateSerializer();
        }


        // Properties
        public IDbOperations Serializer
        {
            get { return serializer; }
        }


        // Methods
        private void CreateSerializer()
        {
            XmlDocument xmlDocument = new XmlDocument();
            if (!File.Exists(configPath))
            {
                XmlElement formatElement = xmlDocument.CreateElement("format");
                formatElement.InnerText = defaultFormat;

                XmlElement pathElement = xmlDocument.CreateElement("path");
                pathElement.InnerText = defaultPath;

                XmlElement configElement = xmlDocument.CreateElement("config");
                configElement.AppendChild(formatElement);
                configElement.AppendChild(pathElement);
                xmlDocument.AppendChild(configElement);
                xmlDocument.Save(configPath);
            }
            try
            {
                xmlDocument.Load(configPath);
                foreach (XmlNode node in xmlDocument.SelectNodes("config"))
                {
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        if (child.Name == "format")
                        {
                            if (child.InnerText == "bin" || child.InnerText == "binary")
                            {
                                format = "binary";
                            }
                            else if (child.InnerText == "xml")
                            {
                                format = "xml";
                            }
                            else
                            {
                                throw new ApplicationException("Формат " + child.InnerText + " программой " +
                                                               "не поддерживается.");
                            }
                        }

                        else if (child.Name == "path")
                        {
                            if (child.InnerText != "")
                            {
                                path = child.InnerText;
                            }
                            else
                            {
                                throw new ApplicationException("В файле конфигурации не указан путь.");
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                if (exception is ApplicationException)
                {
                    throw new ApplicationException(exception.Message);
                }
                throw new ApplicationException("Файл конфигурации имеет некорректный формат.");
            }
            finally
            {
                if (format == "binary")
                {
                    serializer = new AccountBinFormatter(path);
                }
                else if (format == "xml")
                {
                    serializer = new AccountXmlSerializer(path);
                }
            }
        }
    }
}
