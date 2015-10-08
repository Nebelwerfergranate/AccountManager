using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Account_Manager
{
    public class Exit : Operation
    {
        public void SaveAndExit()
        {
            SendMessage("Работа программы завершена. " +
                        "Каталоги будут сохранены в файл "
                        + ConsoleMenu.AccountTable.FilePath);
            ConsoleMenu.AccountTable.Save();
            Environment.Exit(1);
        }
    }
}
