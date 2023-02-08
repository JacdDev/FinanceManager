using FinanceManager.Domain.Models;
using FinanceManager.Domain.UserAggregate.ValueObjects;
using FinanceManager.Domain.AccountAggregate.ValueObjects;

namespace FinanceManager.Domain.UserAggregate
{
    public class User : AggregateRoot<UserId>
    {
        private readonly List<AccountId> _accounts = new();
        public IReadOnlyList<AccountId> Accounts => _accounts.AsReadOnly();

        private User(UserId id) : base(id)
        {
        }

        public static User Create()
        {
            return new User(UserId.CreateUnique());
        }
    }
}
