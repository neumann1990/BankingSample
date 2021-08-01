using System;

namespace Banking.BankAccount
{
    public class IndividualInvestAccount : IInvestmentAccount, IAccount
    {
        public static decimal WithdrawalLimit = 500;

        public Guid Id { get; private set; } = Guid.NewGuid();
        public IOwner Owner { get; private set; }
        public decimal Balance { get; private set; }

        public IndividualInvestAccount() { }

        public IndividualInvestAccount(Guid id)
        {
            Id = id;
        }

        public IndividualInvestAccount(decimal balance)
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