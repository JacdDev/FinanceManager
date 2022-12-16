using FinanceManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Domain.Tag.ValueObjects
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

        public override IEnumerable<object> GetEquialityComponents()
        {
            yield return Value;
        }
    }
}
