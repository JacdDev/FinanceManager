using FinanceManager.Domain.Models;
using FinanceManager.Domain.AccountAggregate.ValueObjects;
using FinanceManager.Domain.UserAggregate.ValueObjects;
using FinanceManager.Domain.MovementAggregate.ValueObjects;

namespace FinanceManager.Domain.AccountAggregate
{
    public class Account : AggregateRoot<AccountId>
    {
        public string Name { get; }
        public string Description { get; }
        public double Amount { get; }
        private readonly List<UserId> _users = new();
        public IReadOnlyList<UserId> Users => _users.AsReadOnly();
        private readonly List<MovementId> _movements = new();
        public IReadOnlyList<MovementId> Movement => _movements.AsReadOnly();

        private Account(
            AccountId id,
            string name,
            string description,
            double amount) : base(id)
        {
            Name = name;
            Description = description;
            Amount = amount;
        }

        public static Account Create(
            string name,
            string description,
            double amount)
        {
            return new Account(
                AccountId.CreateUnique(),
                name,
                description,
                amount);
        }
    }
}
