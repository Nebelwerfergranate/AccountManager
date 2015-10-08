using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Account_Manager
{
    public class Add : Operation
    {
        public void AddNewAccount(List<String> userCommands)
        {
            int accountsAdded = 0;

            if (userCommands.Count < 2)
            {
                SendMessage("Информация о новом каталоге не указана");
                return;
            }

            userCommands.RemoveAt(0);
            string command = String.Join(" ", userCommands.ToArray());
            Regex parseBrackets = new Regex(@"\(([A-z,А-я,0-9,'\,,@,\.,\-,\s]*)\)");

            // Контроль почтового адреса не строгий умышленно. Туда можно записать и пустую строку
            Regex parseFields = new Regex(@"'([A-z,А-я,0-9,\-,\s]*)'\s*,\s*
                                            '([A-z,А-я,0-9,\-,\s]*)'\s*,\s*
                                            '([0-9]*)'\s*,\s*
                                            '([A-z,А-я,0-9,\-,\s]*)'\s*,\s*
                                            '([A-z,0-9,\-,@,\.]*)'\s*,\s*
                                            '([0-9]*)'\s*\s*", RegexOptions.IgnorePatternWhitespace);

            Match inBrackets = parseBrackets.Match(command);

            while (inBrackets.Success)
            {
                Match fields = parseFields.Match(inBrackets.Groups[1].Value);
                while (fields.Success)
                {
                    try
                    {
                        Account account = new Account();
                        account.FirstName = fields.Groups[1].Value;
                        account.LastName = fields.Groups[2].Value;
                        if (fields.Groups[3].Value == "")
                        {
                            account.Age = null;
                        }
                        else
                        {
                            account.Age = Byte.Parse(fields.Groups[3].Value);
                        }
                        account.Position = fields.Groups[4].Value;
                        account.Email = fields.Groups[5].Value;
                        if (fields.Groups[6].Value == "")
                        {
                            account.Salary = null;
                        }
                        else
                        {
                            account.Salary = UInt32.Parse(fields.Groups[6].Value);
                        }

                        ConsoleMenu.AccountTable.Add(account);
                        accountsAdded++;
                    }
                    catch (Exception)
                    {
                        // Это сообщение выводиться не должно.
                        SendMessage("Ошибка парсинга строк.");
                        return;
                    }
                    fields = fields.NextMatch();
                }
                inBrackets = inBrackets.NextMatch();
            }
            SendMessage("Добавлено " + accountsAdded + " каталогов.");
        }
    }
}
