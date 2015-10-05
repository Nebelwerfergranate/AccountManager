using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Account_Manager
{
    public static class Delete
    {
        public static string DeleteAccount(Dictionary<uint, Account> accounts, List<String> userCommands)
        {
            string info = "";
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
                accounts.Remove(id);
                info += "Каталог ID " + id + " удален.";
            }
            else
            {
                return "Каталога с ID " + id + " не найдено";
            }
            return info;
        }
    }
}
