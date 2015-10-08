using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Account_Manager
{
    public interface IDbOperations
    {
        // Properties
        string Path { get; }


        // Methods
        List<Account> Read();
        void Write(List<Account> accounts);
    }
}
