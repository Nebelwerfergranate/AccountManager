using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Account_Manager
{
    public class AccountTable
    {
        // fields
        private readonly Config config = new Config();

        private readonly IDbOperations serializer;
        private  readonly List<Account> accounts;


        // Constructors
        public AccountTable()
        {
            serializer = config.Serializer;
            accounts = serializer.Read();
            
        }


        // Properties
        public string FilePath
        {
            get { return serializer.Path; }
        }


        // Events
        public event MessageDelegate OnError;


        // Methods
        public void Save()
        {
            serializer.Write(accounts);
        }

        public void Add(Account newAcc)
        {
            uint maxId = 0;
            foreach (Account account in accounts)
            {
                if (account.Id > maxId)
                {
                    maxId = account.Id;
                }
            }
            newAcc.Id = maxId + 1;
            accounts.Add(newAcc);
        }

        public Account GetAccount(uint id)
        {
            Account returnAccount = null;
            foreach (Account account in accounts)
            {
                if (account.Id == id)
                {
                    returnAccount = account;
                    break;
                }
            }
            return returnAccount;
        }

        public Account[] GetAllAccounts()
        {
            if (accounts.Count == 0)
            {
                return null;
            }
            Account[] returnAccounts = accounts.ToArray();
            return returnAccounts;
        }

        public bool DeleteAccount(uint id)
        {
            foreach (Account account in accounts)
            {
                if (account.Id == id)
                {
                    accounts.Remove(account);
                    return true;
                }
            }
            return false;
        }

        private void SendErrorMessage(string message)
        {
            if (OnError != null)
            {
                OnError.Invoke(message);
            }
        }
    }
}
