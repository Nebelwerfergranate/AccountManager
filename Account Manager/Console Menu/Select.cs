using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Account_Manager
{
    public static class Select
    {
        public static string GetSelectedToString(Dictionary<uint, Account> accounts, List<String> userCommands)
        {
            string info = "";

            if (accounts.Count == 0)
            {
                return "Каталогов не найдено.";
            }

            info += "Найденные каталоги:\n\n";
            if (userCommands.Count < 2)
            {
                return "Не указан id каталога для просмотра";

            }
            if (userCommands[1] == "*")
            {

                foreach (KeyValuePair<uint, Account> keyValuePair in accounts)
                {
                    info += keyValuePair.Value.ToString();
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
                    return "ID каталога указан в некорректном формате";
                }
                if (accounts.ContainsKey(id))
                {
                    info += accounts[id].ToString();
                }
                else
                {
                    return "Каталога с ID " + id + " не найдено";
                }
            }
            return info;
        }
    }
}
