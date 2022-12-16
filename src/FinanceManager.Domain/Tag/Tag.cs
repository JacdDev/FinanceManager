using FinanceManager.Domain.Models;
using FinanceManager.Domain.Tag.ValueObjects;
using FinanceManager.Domain.Account.ValueObjects;

namespace FinanceManager.Domain.Tag
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
