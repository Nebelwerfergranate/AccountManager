using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.Text;

namespace Account_Manager
{
    class Program
    {

        private static void Main(string[] args)
        {
            Dictionary<uint, Account> accounts = new Dictionary<uint, Account>(); 
            ConsoleMenu.Start(accounts);
        }
    }
}
