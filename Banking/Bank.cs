using Banking.BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banking
{
    public interface IBank {
        string Id { get; set; }
        string Name { get; set; }
        IEnumerable<IAccount> Accounts { get; set; }
    }

    public class Bank : IBank
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<IAccount> Accounts { get; set; }

        public void Execute(ITransaction transaction)
        {
            var sourceAccount = Accounts.SingleOrDefault(a => a.Id == transaction.SourceAccountId);

            if(sourceAccount == null)
            {
                throw new KeyNotFoundException($"SourceAccount {transaction.SourceAccountId} not found");
            }

            switch (transaction.TransactionType)
            {
                case TransactionType.Withdrawal:
                    sourceAccount.Withdrawal(transaction.Amount);
                    break;
                case TransactionType.Deposit:
                    sourceAccount.Deposit(transaction.Amount);
                    break;
                case TransactionType.Transfer:
                    var destAccount = Accounts.SingleOrDefault(a => a.Id == transaction.DestAccountId);
                    if (destAccount == null)
                    {
                        throw new KeyNotFoundException($"SourceAccount {transaction.SourceAccountId} not found");
                    }

                    sourceAccount.Transfer(-transaction.Amount);
                    destAccount.Transfer(transaction.Amount);
                    break;
                default:
                    throw new ArgumentException("Unknown transaction type");
            }
        }
    }
}
