using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Account_Manager
{
    class AccountXmlSerializer : IDbOperations
    {
        // Fields
        private static XmlSerializer serializer = new XmlSerializer(typeof(List<Account>));

        private string path;


        // Constructors
        public AccountXmlSerializer(string path)
        {
            this.path = path;
        }


        // Properties
        public string Path
        {
            get { return path; }
        }


        // Methods
        public List<Account> Read()
        {
            if (!File.Exists(Path))
            {
                return new List<Account>();
            }

            object deserialize = null;

            try
            {
                using (FileStream fs = new FileStream(Path, FileMode.Open))
                {
                    deserialize = serializer.Deserialize(fs);
                    if (deserialize is List<Account>)
                    {
                        return (List<Account>)deserialize;
                    }
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Невозможно прочитать файл " + Path + ". Возможно " +
                   "файл поврежден или имеет некорректный формат.");
            }
        }

        public void Write(List<Account> accounts)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(fs, accounts);
            }
        }
    }
}
