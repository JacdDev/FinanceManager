using FinanceManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Domain.Movement.ValueObjects
{
    public sealed class MovementId : ValueObject
    {
        public Guid Value { get; }

        private MovementId(Guid value)
        {
            Value = value;
        }

        public static MovementId CreateUnique()
        {
            return new MovementId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEquialityComponents()
        {
            yield return Value;
        }
    }
}
