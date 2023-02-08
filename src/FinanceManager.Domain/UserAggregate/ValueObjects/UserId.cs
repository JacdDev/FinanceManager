using FinanceManager.Domain.Models;

namespace FinanceManager.Domain.UserAggregate.ValueObjects
{
    public sealed class UserId : ValueObject
    {
        public Guid Value { get; }

        private UserId(Guid value)
        {
            Value = value;
        }

        public static UserId Create(string value)
        {
            return new UserId(Guid.Parse(value));
        }

        public static UserId Create(Guid value)
        {
            return new UserId(value);
        }

        public static UserId CreateUnique()
        {
            return new UserId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEquialityComponents()
        {
            yield return Value;
        }
    }
}
