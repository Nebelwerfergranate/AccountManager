using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Account_Manager.Console_Menu
{
    class AccountBinFormatter : IDbOperations
    {
        // Fields
        private static BinaryFormatter formatter = new BinaryFormatter();
        private string path;


        // Constructors
        public AccountBinFormatter(string path)
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
                    deserialize = formatter.Deserialize(fs);
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
            using (FileStream fs = new FileStream(Path, FileMode.Create))
            {
                formatter.Serialize(fs, accounts);
            }
        }
    }
}
