using System;

namespace Banking.BankAccount
{
    public class CheckingAccount : IAccount
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public IOwner Owner { get; private set; }
        public decimal Balance { get; private set; }

        public CheckingAccount() { }

        public CheckingAccount(decimal balance)
        {
            Balance = balance;
        }

        public ITransaction Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be a positive value");
            }

            Balance += amount;

            return new Transaction
            {
                TransactionType = TransactionType.Deposit,
                Amount = amount,
                SourceAccount = this
            };
        }

        public ITransaction Withdrawal(decimal amount)
        {
            if(amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be a positive value");
            }

            Balance -= amount;

            return new Transaction
            {
                TransactionType = TransactionType.Withdrawal,
                Amount = amount,
                SourceAccount = this
            };
        }

        public ITransaction Transfer(decimal amount)
        {
            Balance += amount;

            return new Transaction
            {
                TransactionType = TransactionType.Transfer,
                Amount = amount,
                SourceAccount = this
            };
        }
    }
}