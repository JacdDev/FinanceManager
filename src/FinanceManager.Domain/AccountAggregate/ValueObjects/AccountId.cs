﻿using FinanceManager.Domain.Models;

namespace FinanceManager.Domain.AccountAggregate.ValueObjects
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

        public static AccountId Create(Guid value)
        {
            return new AccountId(value);
        }

        public override IEnumerable<object> GetEquialityComponents()
        {
            yield return Value;
        }
    }
}
