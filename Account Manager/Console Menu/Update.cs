using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Account_Manager
{
    public static class Update
    {
        public static string UpdateAccountInfo(Dictionary<uint, Account> accountsList, List<String> userCommands)
        {
            if (userCommands.Count < 4)
            {
                return "Пропущена одна или несколько команд";
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
                return "ID каталога указан в некорректном формате";
            }

            if (accountsList.ContainsKey(id))
            {
                account = accountsList[id];
            }
            else
            {
                return "Каталога с указанным ID не существует";
            }
            

            if (userCommands[2].ToUpper() != "SET")
            {
                return "Пропущено ключевое слово SET";
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
            return "Обновлено " + fieldsUpdated + " строк.";
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
