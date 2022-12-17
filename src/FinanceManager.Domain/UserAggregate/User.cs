using FinanceManager.Domain.Models;
using FinanceManager.Domain.UserAggregate.ValueObjects;
using FinanceManager.Domain.AccountAggregate.ValueObjects;

namespace FinanceManager.Domain.UserAggregate
{
    public class User : AggregateRoot<UserId>
    {
        public string Email { get; }
        public string Password { get; }
        private readonly List<AccountId> _accounts = new();
        public IReadOnlyList<AccountId> Accounts => _accounts.AsReadOnly();

        private User(
            UserId id,
            string email,
            string password) : base(id)
        {
            Email = email;
            Password = password;
        }

        public static User Create(
            string email,
            string password)
        {
            return new User(
                UserId.CreateUnique(),
                email,
                password);
        }
    }
}
