using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Account_Manager
{
    public static class ConsoleMenu
    {
        // Fields
        private static Dictionary<uint, Account> accounts; 



        // Methods
        public static void Start(Dictionary<uint, Account> accountsFromMain)
        {
            accounts = accountsFromMain;
            if (Config.Init())
            {
                //InformUser(String.Format("format: {0}", Config.Format));
                //InformUser(String.Format("path: {0}", Config.Path));
            }
            else
            {
                InformUser("Конфигурационный файл config.xml не найден или составлен некорректно.");
                return;
            }

            while (true)
            {
                Console.Clear();
                Console.Write("Введите команду: ");
                string userInput = Console.ReadLine();
                if (userInput.Length == 0)
                {
                    PrintHelp();
                    InformUser();
                    continue;
                }
                List<String> userCommands = new List<string>(
                    userInput.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                    );
                switch (userCommands[0].ToUpper())
                {
                    case "SELECT":
                        Select.PrintSelected(userCommands);
                        break;
                    case "ADD":
                        Add.AddNewAccount(userCommands);
                        break;
                    case "UPDATE":
                        Update.UpdateAccountInfo(userCommands);
                        break;
                    case "DELETE":
                        Delete.DeleteAccount(userCommands);
                        break;
                    case "EXIT":
                        Exit.SaveAndExit(userCommands);
                        break;
                    default: 
                        ErrorMessage(userInput);
                        break;
                }
            }
        }

        public static void InformUser(string msg = "")
        {
            if (msg.Length != 0)
            {
                Console.WriteLine(msg);
            }
            Console.WriteLine("Нажмите любую клавишу что бы продолжить");
            Console.ReadKey();
        }

        public static void ErrorMessage(string userInput)
        {
            Console.WriteLine();
            PrintHelp();
            Console.WriteLine();
            InformUser("Некорректная комманда. Ошибка после '" + userInput + "'. Пожалуйста, проверьте синтаксис.");
        }

        private static void PrintHelp()
        {
            Console.WriteLine("Для управления каталогами используйте следующие команды");
            Console.WriteLine("\tSELECT id или SELECT * или SELECT(id, id, id)");
            Console.WriteLine("\tADD (), ()");
            Console.WriteLine("\tDELETE id");
            Console.WriteLine("\tUPDATE id SET поле = значение");
            Console.WriteLine("\tEXIT");
        }
    }
}
