using Banking.BankAccount;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Banking.Tests
{
    public class IndividualInvestAccount_UT
    {
        [Theory]
        //Starting positive, ending positive balance
        [ClassData(typeof(IndividualInvest_Withdrawal_StartEndPos))]

        //Starting positive, ending negative balance
        [ClassData(typeof(IndividualInvest_Withdrawal_StartPosEndNeg))]

        //Starting negative, ending negative blanace 
        [ClassData(typeof(IndividualInvest_Withdrawal_StartEndNeg))]

        public void Withdrawal(decimal startBalance, decimal withdrawalAmount, decimal expectedEndBalance)
        {
            var account = new IndividualInvestAccount(startBalance);
            account.Withdrawal(withdrawalAmount);

            Assert.Equal(expectedEndBalance, account.Balance);
        }

        [Theory]
        [InlineData(0, 500.01)]
        [InlineData(501, 500.01)]
        [InlineData(100000000, 750)]
        [InlineData(100000000, 750000000)]
        [InlineData(0, 750000000)]
        public void Withdrawal_Over500(decimal startBalance, decimal withdrawalAmount)
        {
            var account = new IndividualInvestAccount(startBalance);
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdrawal(withdrawalAmount));
        }

        [Theory]
        [ClassData(typeof(Withdrawal_InvalidValues))]

        public void Withdrawal_InvalidValues(decimal startBalance, decimal withdrawalAmount)
        {
            var account = new IndividualInvestAccount(startBalance);
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdrawal(withdrawalAmount));
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
            var account = new IndividualInvestAccount(startBalance);
            account.Deposit(depositAmount);

            Assert.Equal(expectedEndBalance, account.Balance);
        }

        [Theory]
        [ClassData(typeof(Deposit_InvalidValues))]

        public void Deposit_InvalidValues(decimal startBalance, decimal depositAmount)
        {
            var account = new IndividualInvestAccount(startBalance);
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Deposit(depositAmount));
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
            var account = new IndividualInvestAccount(startBalance);

            account.Transfer(amount);

            Assert.Equal(expectedEndBalance, account.Balance);
        }
    }
}
