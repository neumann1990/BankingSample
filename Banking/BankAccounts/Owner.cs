namespace Banking.BankAccounts
{
    public interface IOwner
    {
        string Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }

    public class Owner : IOwner
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}