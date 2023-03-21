using FinanceManager.Domain.AccountAggregate.ValueObjects;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.MovementAggregate;
using FinanceManager.Domain.TagAggregate;
using FinanceManager.Domain.UserAggregate.ValueObjects;

namespace FinanceManager.Domain.AccountAggregate
{
    public class Account : AggregateRoot<AccountId>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Amount { get; private set; }
        private readonly List<UserId> _users = new();
        public IReadOnlyList<UserId> Users => _users.AsReadOnly();
        private readonly List<Movement> _movements = new();
        public IReadOnlyList<Movement> Movements => _movements.AsReadOnly();
        private readonly List<Tag> _tags = new();
        public IReadOnlyList<Tag> Tags => _tags.AsReadOnly();
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

        public void addUser(UserId userId)
        {
            if (!_users.Contains(userId))
            {
                _users.Add(userId);
            }
        }

        public void removeUser(UserId userId)
        {
            if (_users.Contains(userId))
            {
                _users.Remove(userId);
            }
        }

        public void SetAmount(double amount)
        {
            Amount = amount;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }
    }
}
