using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Manager
{
    class Program
    {

        private static void Main(string[] args)
        {
            Dictionary<uint, Account> accounts = new Dictionary<uint, Account>(); 
            Test.AddAccounts(accounts);
            ConsoleMenu.Start(accounts);
        }
    }
}
