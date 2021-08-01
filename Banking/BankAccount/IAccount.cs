using System;

namespace Banking.BankAccounts
{
    public interface IAccount
    {
        Guid Id { get; }
        IOwner Owner { get; }
        decimal Balance { get; }

        ITransaction Deposit(decimal amount);
        ITransaction Withdrawal(decimal amount);
        ITransaction Transfer(decimal transferAmountToDest, IAccount destAccount);
    }
}