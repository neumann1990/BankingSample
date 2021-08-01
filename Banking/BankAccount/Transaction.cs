using System;

namespace Banking.BankAccount
{
    public interface ITransaction
    {
        Guid Id { get; set; } 
        decimal Amount { get; set; }
        TransactionType TransactionType { get; set; }
        IAccount SourceAccount { get; set; }
        IAccount DestAccount { get; set; }
        DateTime DateInitiated { get; set; }
    }

    public class Transaction : ITransaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public IAccount SourceAccount { get; set; }
        public IAccount DestAccount { get; set; }
        public DateTime DateInitiated { get; set; } = DateTime.UtcNow;
    }
}