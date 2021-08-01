using System;

namespace Banking.BankAccount
{
    public interface IOwner
    {
        Guid Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }

    public class Owner : IOwner
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}