using Banking.BankAccount;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Banking.Tests
{
    public class Bank_UT
    {
        private readonly Bank _testObject;
        private readonly Mock<IAccount> _account0;
        private readonly Mock<IAccount> _account1;
        private readonly Mock<IAccount> _account2;
        private readonly List<Mock<IAccount>> _mockAccounts;

        public Bank_UT()
        {
            _account0 = new Mock<IAccount>();
            _account0.SetupGet(a => a.Id).Returns(Guid.Parse("e5ea78cd-6742-470b-97f6-9ec2cc307359"));

            _account1 = new Mock<IAccount>();
            _account1.SetupGet(a => a.Id).Returns(Guid.Parse("86f02dde-23ab-4f90-8e53-f61baf001fb5"));

            _account2 = new Mock<IAccount>();
            _account2.SetupGet(a => a.Id).Returns(Guid.Parse("0e6688eb-d05e-4413-8ac7-db86c5b38f41"));

            _mockAccounts = new List<Mock<IAccount>> { _account0, _account1, _account2 };

            _testObject = new Bank
            {
                Accounts = _mockAccounts.Select(m => m.Object)
            };
        }

        [Theory]
        [InlineData("e5ea78cd-6742-470b-97f6-9ec2cc307359", 100)]
        [InlineData("86f02dde-23ab-4f90-8e53-f61baf001fb5", -99.999999)]
        public void Execute_Withdrawal(string accountId, decimal amount)
        {
            var transaction = new Transaction
            {
                TransactionType = TransactionType.Withdrawal,
                SourceAccountId = Guid.Parse(accountId),
                Amount = amount
            };

            var mockAccount = _mockAccounts.Single(a => a.Object.Id == Guid.Parse(accountId));

            mockAccount.Setup(a => a.Withdrawal(amount));

            _testObject.Execute(transaction);

            mockAccount.VerifyAll();
        }

        [Theory]
        [InlineData("e5ea78cd-6742-470b-97f6-9ec2cc307359", 100)]
        [InlineData("0e6688eb-d05e-4413-8ac7-db86c5b38f41", -99.999999)]
        public void Execute_Deposit(string accountId, decimal amount)
        {
            var transaction = new Transaction
            {
                TransactionType = TransactionType.Deposit,
                SourceAccountId = Guid.Parse(accountId),
                Amount = amount
            };

            var mockAccount = _mockAccounts.Single(a => a.Object.Id == Guid.Parse(accountId));

            mockAccount.Setup(a => a.Deposit(amount));

            _testObject.Execute(transaction);

            mockAccount.VerifyAll();
        }

        [Theory]
        [InlineData("e5ea78cd-6742-470b-97f6-9ec2cc307359", "0e6688eb-d05e-4413-8ac7-db86c5b38f41", 100)]
        [InlineData("0e6688eb-d05e-4413-8ac7-db86c5b38f41", "86f02dde-23ab-4f90-8e53-f61baf001fb5", -99.999999)]
        public void Execute_Transfer(string sourceAccountId, string destAccountId, decimal amount)
        {
            var transaction = new Transaction
            {
                TransactionType = TransactionType.Transfer,
                SourceAccountId = Guid.Parse(sourceAccountId),
                DestAccountId = Guid.Parse(destAccountId),
                Amount = amount
            };

            var mockSourceAccount = _mockAccounts.Single(a => a.Object.Id == Guid.Parse(sourceAccountId));
            var mockDestAccount = _mockAccounts.Single(a => a.Object.Id == Guid.Parse(destAccountId));

            mockSourceAccount.Setup(a => a.Transfer(-amount));
            mockDestAccount.Setup(a => a.Transfer(amount));

            _testObject.Execute(transaction);

            mockSourceAccount.VerifyAll();
            mockDestAccount.VerifyAll();
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000000")]
        public void Execute_ThrowsOnUnknownSourceAccount(string sourceAccountId)
        {
            var transaction = new Transaction
            {
                TransactionType = TransactionType.Transfer,
                SourceAccountId = Guid.Parse(sourceAccountId),
            };

            Assert.Throws<KeyNotFoundException>(() => _testObject.Execute(transaction));
        }

        [Theory]
        [InlineData("e5ea78cd-6742-470b-97f6-9ec2cc307359", "00000000-0000-0000-0000-000000000000")]
        public void Execute_ThrowsOnUnknownDestAccount(string sourceAccountId, string destAccountId)
        {
            var transaction = new Transaction
            {
                TransactionType = TransactionType.Transfer,
                SourceAccountId = Guid.Parse(sourceAccountId),
                DestAccountId = Guid.Parse(destAccountId),
            };

            Assert.Throws<KeyNotFoundException>(() => _testObject.Execute(transaction));
        }
    }
}
