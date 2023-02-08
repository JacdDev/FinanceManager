using FinanceManager.Domain.Models;

namespace FinanceManager.Domain.TagAggregate.ValueObjects
{
    public sealed class TagId : ValueObject
    {
        public Guid Value { get; }

        private TagId(Guid value)
        {
            Value = value;
        }

        public static TagId CreateUnique()
        {
            return new TagId(Guid.NewGuid());
        }

        public static TagId Create(Guid value)
        {
            return new TagId(value);
        }
        public override IEnumerable<object> GetEquialityComponents()
        {
            yield return Value;
        }
    }
}
