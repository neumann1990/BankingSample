namespace Banking.BankAccounts
{
    public interface ITransaction
    {
        string Id { get; set; } 
        decimal Amount { get; set; }
        IAccount SourceAccount { get; set; }
        IAccount DestAccount { get; set; }
    }

    public class Transaction : ITransaction
    {
        public string Id { get; set; }
        public decimal Amount { get; set; }
        public IAccount SourceAccount { get; set; }
        public IAccount DestAccount { get; set; }
    }
}