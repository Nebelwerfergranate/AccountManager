using System;
using System.Xml;

namespace Account_Manager
{
    public static class Config
    {
        // Fields
        private static string format = "";
        private static string path = "";


        // Properties
        public static string Format
        {
            get { return format; }
        }

        public static string Path
        {
            get { return path; }
        }


        // Methods
        public static bool Init()
        {
            string configPath = "config.xml";
            XmlDocument config = new XmlDocument();
            try
            {
                config.Load(configPath);
                foreach (XmlNode node in config.SelectNodes("config"))
                {
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        if (child.Name == "format")
                        {
                            format = child.InnerText;
                        }
                        else if (child.Name == "path")
                        {
                            path = child.InnerText;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            if(path!= "" && format!= "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
