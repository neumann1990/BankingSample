using System;

namespace Banking.BankAccounts
{
    public class CorporateInvestAccount : IInvestmentAccount, IAccount
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public IOwner Owner { get; private set; }
        public decimal Balance { get; private set; }

        public ITransaction Deposit(decimal amount)
        {
            throw new System.NotImplementedException();
        }

        public ITransaction Transfer(decimal amount, IAccount destAccount)
        {
            throw new System.NotImplementedException();
        }

        public ITransaction Withdrawal(decimal amount)
        {
            throw new System.NotImplementedException();
        }
    }
}