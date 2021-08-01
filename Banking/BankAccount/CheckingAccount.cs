using System;

namespace Banking.BankAccounts
{
    public class CheckingAccount : IAccount
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public IOwner Owner { get; set; }
        public decimal Balance { get; set; }

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

        public ITransaction Transfer(decimal amount, IAccount destAccount)
        {
            throw new System.NotImplementedException();
        }
    }
}