using Banking.BankAccounts;
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
        [ClassData(typeof(WithdrawalTestData_StartEndPos))]

        //Starting positive, ending negative balance
        [ClassData(typeof(WithdrawalTestData_StartPosEndNeg))]

        //Starting negative, ending negative blanace 
        [ClassData(typeof(WithdrawalTestData_StartEndNeg))]

        public void Withdrawal(decimal startBalance, decimal withdrawalAmount, decimal expectedEndBalance)
        {
            var checkingAccount = new CheckingAccount { Balance = startBalance };
            var transaction = checkingAccount.Withdrawal(withdrawalAmount);

            Assert.Equal(withdrawalAmount, transaction.Amount);
            Assert.Equal(expectedEndBalance, checkingAccount.Balance);
            Assert.Equal(TransactionType.Withdrawal, transaction.TransactionType);
        }

        [Theory]
        [ClassData(typeof(WithdrawalTestData_InvalidValues))]

        public void Withdrawal_InvalidValues(decimal startBalance, decimal withdrawalAmount)
        {
            var checkingAccount = new CheckingAccount { Balance = startBalance };
            Assert.Throws<ArgumentException>(() => checkingAccount.Withdrawal(withdrawalAmount));
        }


        [Theory]
        //Starting positive, ending positive balance
        [ClassData(typeof(DepositTestData_StartEndPos))]

        //Starting positive, ending negative balance
        [ClassData(typeof(DepositTestData_StartNegEndPos))]

        //Starting negative, ending negative blanace 
        [ClassData(typeof(DepositTestData_StartEndNeg))]
        public void Deposit(decimal startBalance, decimal depositAmount, decimal expectedEndBalance)
        {
            var checkingAccount = new CheckingAccount { Balance = startBalance };
            var transaction = checkingAccount.Deposit(depositAmount);

            Assert.Equal(depositAmount, transaction.Amount);
            Assert.Equal(expectedEndBalance, checkingAccount.Balance);
            Assert.Equal(TransactionType.Deposit, transaction.TransactionType);
        }

        [Theory]
        [ClassData(typeof(DepositTestData_InvalidValues))]

        public void Deposit_InvalidValues(decimal startBalance, decimal depositAmount)
        {
            var checkingAccount = new CheckingAccount { Balance = startBalance };
            Assert.Throws<ArgumentException>(() => checkingAccount.Deposit(depositAmount));
        }
    }
}
