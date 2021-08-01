using System;

namespace Banking.BankAccount
{
    public interface IAccount
    {
        Guid Id { get; }
        IOwner Owner { get; }
        decimal Balance { get; }

        void Deposit(decimal amount);
        void Withdrawal(decimal amount);
        void Transfer(decimal amount);
    }
}