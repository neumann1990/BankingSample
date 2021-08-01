﻿namespace Banking.BankAccounts
{
    public class IndividualInvestAccount : IInvestmentAccount, IAccount
    {
        public static decimal WithdrawalLimit = 500;

        public string Id { get; set; }
        public IOwner Owner { get; set; }
        public decimal Balance { get; set; }

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