using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Account_Manager
{
    public class Delete : Operation
    {
        public void DeleteAccount(List<String> userCommands)
        {
            string info = "";

            uint id = 0;
            try
            {
                id = UInt32.Parse(userCommands[1]);
            }
            catch (Exception)
            {
                SendMessage("ID каталога указан в некорректном формате");
                return;
            }

            if (ConsoleMenu.AccountTable.DeleteAccount(id))
            {
                info += "Каталог ID " + id + " удален.";
            }
            else
            {
                SendMessage("Каталога с ID " + id + " не найдено");
                return ;
            }
            SendMessage(info);
        }
    }
}
