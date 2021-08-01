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
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Deposit amount must be a positive value");
            }

            Balance += amount;
        }

        public void Withdrawal(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Withdrawal amount must be a positive value");
            }

            if(amount > WithdrawalLimit)
            {
                throw new ArgumentOutOfRangeException("Withdrawal amount cannot be over 500");
            }

            Balance -= amount;
        }

        public void Transfer(decimal amount)
        {
            Balance += amount;
        }
    }
}