using System.Collections.Generic;

namespace Account_Manager
{
    public static class Test
    {
        public static void AddAccounts(Dictionary<uint, Account> emptyAccounts)
        {
            emptyAccounts.Add(0, new Account(0, "Doris", "Wilder", 23, "Sales Assistant", "d.wilder@mail.net", 85600));
            emptyAccounts.Add(1, new Account(1, "Finn", "Camacho", 47, "Suppoer Engineer", "f.camach@mail.net", 87500));
            emptyAccounts.Add(2, new Account(2, "Hope", "Fuents", null, null, null, null));
            emptyAccounts.Add(3, new Account(3, "Cara", "Stevens", 46, "Sales Assistant", "c.stevens@mail.net", 145600));
            emptyAccounts.Add(4, new Account(4, "Shad", "Decker", 51, "Regional Director", "s.decker@mail.net", 183000));
        }
    }
}
