using FinanceManager.Domain.Models;
using FinanceManager.Domain.TagAggregate.ValueObjects;
using FinanceManager.Domain.AccountAggregate.ValueObjects;

namespace FinanceManager.Domain.TagAggregate
{
    public class Tag : AggregateRoot<TagId>
    {
        public AccountId AccountId { get;}
        public string Name { get; }

        private Tag(TagId id, string name, AccountId accountId) : base(id)
        {
            AccountId = accountId;
            Name = name;
        }

        public static Tag Create(string name, AccountId accountId)
        {
            return new Tag(TagId.CreateUnique(), name, accountId);
        }
    }
}
