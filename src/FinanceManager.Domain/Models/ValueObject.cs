using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Domain.Models
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public abstract IEnumerable<object> GetEquialityComponents();

        public bool Equals(ValueObject? other)
        {
            return Equals((object?)other);
        }

        public override bool Equals(object? obj)
        {
            if(obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            var valueObject = (ValueObject)obj;

            return GetEquialityComponents()
                .SequenceEqual(valueObject.GetEquialityComponents());
        }

        public static bool operator ==(ValueObject left, ValueObject right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !Equals(left, right);
        }

        public override int GetHashCode()
        {
            return GetEquialityComponents()
                .Select(x=>x?.GetHashCode() ?? 0)
                .Aggregate((x, y) => x ^ y);
        }
    }
}
