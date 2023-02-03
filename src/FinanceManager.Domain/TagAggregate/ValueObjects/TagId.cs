using FinanceManager.Domain.Models;
using FinanceManager.Domain.MovementAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
