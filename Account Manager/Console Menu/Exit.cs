using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Account_Manager
{
    public static class Exit
    {
        public static void SaveAndExit(List<String> userCommands)
        {
            ConsoleMenu.InformUser("Работа программы завершена");
            Environment.Exit(1);
        }
    }
}
