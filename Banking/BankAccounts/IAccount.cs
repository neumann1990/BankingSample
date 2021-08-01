namespace Banking.BankAccounts
{
    public interface IAccount
    {
        string Id { get; set; }
        IOwner Owner { get; set; }
        decimal Balance { get; set; }

        ITransaction Deposit(decimal amount);
        ITransaction Withdrawal(decimal amount);
        ITransaction Transfer(decimal amount, IAccount destAccount);
    }
}