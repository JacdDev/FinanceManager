using FinanceManager.Domain.Models;
using FinanceManager.Domain.TagAggregate.ValueObjects;
using FinanceManager.Domain.AccountAggregate.ValueObjects;

namespace FinanceManager.Domain.TagAggregate
{
    public class Tag : AggregateRoot<TagId>
    {
        public AccountId AccountId { get;}
        public string Name { get; }
        public string Color { get; }

        private Tag(TagId id, string name, string color, AccountId accountId) : base(id)
        {
            AccountId = accountId;
            Name = name;
            Color = color;
        }

        public static Tag Create(string name, string color, AccountId accountId)
        {
            return new Tag(TagId.CreateUnique(), name, color, accountId);
        }
    }
}
