using FinanceManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Domain.Account.ValueObjects
{
    public sealed class AccountId : ValueObject
    {
        public Guid Value { get; }

        private AccountId(Guid value)
        {
            Value = value;
        }

        public static AccountId CreateUnique()
        {
            return new AccountId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEquialityComponents()
        {
            yield return Value;
        }
    }
}
