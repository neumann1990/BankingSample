using Banking.BankAccounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking
{
    public interface IBank {
        string Id { get; set; }
        string Name { get; set; }
        IEnumerable<IAccount> Accounts { get; set; }
    }

    public class Bank : IBank
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<IAccount> Accounts { get; set; }
    }
}
