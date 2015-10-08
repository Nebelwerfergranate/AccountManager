using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Account_Manager
{
    public class Update : Operation
    {
        public void UpdateAccountInfo(List<String> userCommands)
        {
            if (userCommands.Count < 4)
            {
                SendMessage("Пропущена одна или несколько команд");
                return;
            }

            uint id = 0;
            Account account = null;
            int fieldsUpdated = 0;

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
                account = ConsoleMenu.AccountTable.GetAccount(id);
            }
            else
            {
                SendMessage("Каталога с указанным ID не существует");
                return;
            }
            

            if (userCommands[2].ToUpper() != "SET")
            {
                SendMessage("Пропущено ключевое слово SET");
                return;
            }

            userCommands.RemoveRange(0, 3);
            string[] commandsArray = String.Join(" ", userCommands.ToArray()).Split(',');

            Regex parseInstructions = new Regex(@"([A-z]{3,})\s*=\s*([\s,A-z,0-9,А-я,\-,@,\.]*)",
                RegexOptions.IgnorePatternWhitespace);

            foreach (string instruction in commandsArray)
            {
                Match match = parseInstructions.Match(instruction);
                while (match.Success)
                {
                    string field = match.Groups[1].Value;
                    string newValue = match.Groups[2].Value;

                    if (UpdateField(account, field, newValue))
                    {
                        fieldsUpdated++;
                    }
                    match = match.NextMatch();
                }
            }
            SendMessage("Обновлено " + fieldsUpdated + " строк.");
        }

        private static bool UpdateField(Account account, string field, string newValue )
        {
            switch (field.ToLower())
            {
                case "firstname":
                    if (newValue.Contains('@') || newValue.Contains('.'))
                    {
                        return false;
                    }
                    account.FirstName = newValue;
                    break;
                case "lastname":
                    if (newValue.Contains('@') || newValue.Contains('.'))
                    {
                        return false;
                    }
                    account.LastName = newValue;
                    break;
                case "age":
                    try
                    {
                        account.Age = Byte.Parse(newValue);
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                    break;
                case "position":
                    if (newValue.Contains('@') || newValue.Contains('.'))
                    {
                        return false;
                    }
                    account.Position = newValue;
                    break;
                case "email":
                    if (newValue.Contains(' '))
                    {
                        return false;
                    }
                    account.Email = newValue;
                    break;
                case "salary":
                    try
                    {
                        account.Salary = UInt32.Parse(newValue);
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                    break;
                default:
                    return false;
            }
            return true;
        }
    }
}
