namespace Account_Manager
{
    public static class Test
    {
        public static void AddAccounts(AccountTable accounts)
        {
            if (accounts.GetAccount(1) == null &&
                accounts.GetAccount(2) == null &&
                accounts.GetAccount(3) == null &&
                accounts.GetAccount(4) == null &&
                accounts.GetAccount(5) == null
                )
            {
                accounts.Add(new Account("Doris", "Wilder", 23, "Sales Assistant", "d.wilder@mail.net", 85600));
                accounts.Add(new Account("Finn", "Camacho", 47, "Suppoer Engineer", "f.camach@mail.net", 87500));
                accounts.Add(new Account("Hope", "Fuents", null, null, null, null));
                accounts.Add(new Account("Cara", "Stevens", 46, "Sales Assistant", "c.stevens@mail.net", 145600));
                accounts.Add(new Account("Shad", "Decker", 51, "Regional Director", "s.decker@mail.net", 183000));
            }
        }
    }
}
