using Banking.BankAccount;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Banking.Tests
{
    public class CheckingAccount_UT
    {
        [Theory]
        //Starting positive, ending positive balance
        [ClassData(typeof(Withdrawal_StartEndPos))]

        //Starting positive, ending negative balance
        [ClassData(typeof(Withdrawal_StartPosEndNeg))]

        //Starting negative, ending negative blanace 
        [ClassData(typeof(Withdrawal_StartEndNeg))]

        public void Withdrawal(decimal startBalance, decimal withdrawalAmount, decimal expectedEndBalance)
        {
            var checkingAccount = new CheckingAccount(startBalance);
            var transaction = checkingAccount.Withdrawal(withdrawalAmount);

            Assert.Equal(TransactionType.Withdrawal, transaction.TransactionType);
            Assert.Equal(withdrawalAmount, transaction.Amount);
            Assert.Equal(expectedEndBalance, checkingAccount.Balance);
        }

        [Theory]
        [ClassData(typeof(Withdrawal_InvalidValues))]

        public void Withdrawal_InvalidValues(decimal startBalance, decimal withdrawalAmount)
        {
            var checkingAccount = new CheckingAccount(startBalance);
            Assert.Throws<ArgumentException>(() => checkingAccount.Withdrawal(withdrawalAmount));
        }


        [Theory]
        //Starting positive, ending positive balance
        [ClassData(typeof(Deposit_StartEndPos))]

        //Starting positive, ending negative balance
        [ClassData(typeof(Deposit_StartNegEndPos))]

        //Starting negative, ending negative blanace 
        [ClassData(typeof(Deposit_StartEndNeg))]
        public void Deposit(decimal startBalance, decimal depositAmount, decimal expectedEndBalance)
        {
            var account = new CheckingAccount(startBalance);
            var transaction = account.Deposit(depositAmount);

            Assert.Equal(TransactionType.Deposit, transaction.TransactionType);
            Assert.Equal(depositAmount, transaction.Amount);
            Assert.Equal(expectedEndBalance, account.Balance);
        }

        [Theory]
        [ClassData(typeof(Deposit_InvalidValues))]

        public void Deposit_InvalidValues(decimal startBalance, decimal depositAmount)
        {
            var account = new CheckingAccount(startBalance);
            Assert.Throws<ArgumentException>(() => account.Deposit(depositAmount));
        }

        [Theory]
        //Source starting positive, ending positive balance
        [ClassData(typeof(Transfer_StartEndPos))]

        //Source starting positive, ending negative balance
        [ClassData(typeof(Transfer_StartNegEndPos))]

        //Source starting negative, ending negative blanace 
        [ClassData(typeof(Transfer_StartEndNeg))]
        public void Transfer(decimal startBalance,
                            decimal amount, 
                            decimal expectedEndBalance)
        {
            var account = new CheckingAccount(startBalance);

            var transaction = account.Transfer(amount);

            Assert.Equal(TransactionType.Transfer, transaction.TransactionType);
            Assert.Equal(amount, transaction.Amount);
            Assert.Equal(expectedEndBalance, account.Balance);
        }
    }
}
