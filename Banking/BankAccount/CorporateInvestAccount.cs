using System;

namespace Banking.BankAccount
{
    public class CorporateInvestAccount : IInvestmentAccount, IAccount
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public IOwner Owner { get; private set; }
        public decimal Balance { get; private set; }

        public CorporateInvestAccount() { }

        public CorporateInvestAccount(Guid id)
        {
            Id = id;
        }

        public CorporateInvestAccount(decimal balance)
        {
            Balance = balance;
        }

        public void Deposit(decimal amount)
        {
            throw new System.NotImplementedException();
        }

        public void Transfer(decimal amount)
        {
            throw new System.NotImplementedException();
        }

        public void Withdrawal(decimal amount)
        {
            throw new System.NotImplementedException();
        }
    }
}