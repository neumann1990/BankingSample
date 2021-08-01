using System;

namespace Banking.BankAccount
{
    public class CheckingAccount : IAccount
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public IOwner Owner { get; private set; }
        public decimal Balance { get; private set; }

        public CheckingAccount() { }

        public CheckingAccount(Guid id)
        {
            Id = id;
        }

        public CheckingAccount(decimal balance)
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
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Withdrawal amount must be a positive value");
            }

            Balance -= amount;
        }

        public void Transfer(decimal amount)
        {
            Balance += amount;
        }
    }
}