using System;
using System.Collections.Generic;

namespace Account_Manager
{
    public class ConsoleMenu
    {
        // Fields
        private readonly Add add = new Add();
        private readonly Delete delete = new Delete();
        private readonly Select select = new Select();
        private readonly Update update = new Update();
        private readonly Exit exit = new Exit();

        private static AccountTable accountTable;


        // Constructors
        public ConsoleMenu(AccountTable accounts)
        {
            accountTable = accounts;
            accountTable.OnError += InformUser;

            add.OnMessage += InformUser;
            delete.OnMessage += InformUser;
            select.OnMessage += InformUser;
            update.OnMessage += InformUser;
            exit.OnMessage += InformUser;
        }


        // Properties
        public static AccountTable AccountTable
        {
            get { return accountTable; }
        }


        // Methods
        public void Start()
        {
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
                        select.GetSelected(userCommands);
                        break;
                    case "ADD":
                        add.AddNewAccount(userCommands);
                        break;
                    case "UPDATE":
                        update.UpdateAccountInfo(userCommands);
                        break;
                    case "DELETE":
                        delete.DeleteAccount(userCommands);
                        break;
                    case "EXIT":
                        exit.SaveAndExit();
                        break;
                    default:
                        ErrorMessage(userInput);
                        break;
                }
            }
        }

        private static void InformUser(string msg = "")
        {
            if (msg.Length != 0)
            {
                Console.WriteLine(msg);
            }
            Console.WriteLine("Нажмите любую клавишу что бы продолжить");
            Console.ReadKey();
        }

        private static void ErrorMessage(string userInput)
        {
            Console.WriteLine();
            PrintHelp();
            Console.WriteLine();
            InformUser("Некорректная комманда. Ошибка после '" + userInput + "'. Пожалуйста, проверьте синтаксис.");
        }

        private static void PrintHelp()
        {
            Console.WriteLine("Для управления каталогами используйте следующие команды");
            Console.WriteLine("\tSELECT id или SELECT *");
            Console.WriteLine("\tADD ('FirstName','LastName','Age','Position','Email','Salary'), " +
                              "('','','','','','') ...");
            Console.WriteLine("\tDELETE id");
            Console.WriteLine("\tUPDATE id SET поле = значение, поле = значение");
            Console.WriteLine("\tПоля: ");
            Console.WriteLine("\t\tFirstName");
            Console.WriteLine("\t\tLastName");
            Console.WriteLine("\t\tAge");
            Console.WriteLine("\t\tPosition");
            Console.WriteLine("\t\tEmail");
            Console.WriteLine("\t\tSalary");
            Console.WriteLine("\tEXIT");
        }
    }
}
