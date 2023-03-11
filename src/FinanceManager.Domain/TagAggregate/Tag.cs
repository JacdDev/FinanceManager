using FinanceManager.Domain.AccountAggregate;
using FinanceManager.Domain.AccountAggregate.ValueObjects;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.MovementAggregate;
using FinanceManager.Domain.MovementAggregate.ValueObjects;
using FinanceManager.Domain.TagAggregate.ValueObjects;

namespace FinanceManager.Domain.TagAggregate
{
    public class Tag : AggregateRoot<TagId>
    {
        public Account? Account { get; private set; }
        public string Name { get; }
        public string Color { get; }
        private readonly List<Movement> _movements = new();
        public IReadOnlyList<Movement> Movements => _movements.AsReadOnly();

        private Tag(TagId id, string name, string color) : base(id)
        {
            Name = name;
            Color = color;
        }

        public static Tag Create(string name, string color)
        {
            return new Tag(TagId.CreateUnique(), name, color);
        }
    }
}
