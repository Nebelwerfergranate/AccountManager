using System;
using System.Collections.Generic;

namespace Account_Manager
{
    public class Select : Operation
    {
        public void GetSelected(List<String> userCommands)
        {
            string info = "";

            if (userCommands.Count < 2)
            {
                SendMessage("Не указан id каталога для просмотра");
                return;
            }

            if (userCommands[1] == "*")
            {
                if (ConsoleMenu.AccountTable.GetAllAccounts() == null)
                {
                    SendMessage("Каталогов не найдено.");
                    return;
                }
                Account[] accounts = ConsoleMenu.AccountTable.GetAllAccounts();
                info += "Найденные каталоги:\n\n";
                foreach (Account acc in accounts)
                {
                    info += acc.ToString();
                    info += "\n";
                }
            }
            else
            {
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
                if (ConsoleMenu.AccountTable.GetAccount(id) != null)
                {
                    info += "Найденный каталог:\n\n";
                    info += ConsoleMenu.AccountTable.GetAccount(id).ToString();
                }
                else
                {
                    SendMessage("Каталога с ID " + id + " не найдено");
                    return;
                }
            }
            SendMessage(info);
        }
    }
}
