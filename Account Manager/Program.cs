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
            AccountTable accounts = null;
            try
            {
                accounts = new AccountTable();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }

            Test.AddAccounts(accounts);
            ConsoleMenu menu = new ConsoleMenu(accounts);
            menu.Start();
        }
    }
}
