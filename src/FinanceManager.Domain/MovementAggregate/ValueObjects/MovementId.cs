﻿using FinanceManager.Domain.Models;

namespace FinanceManager.Domain.MovementAggregate.ValueObjects
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

        public static MovementId Create(Guid value)
        {
            return new MovementId(value);
        }

        public override IEnumerable<object> GetEquialityComponents()
        {
            yield return Value;
        }
    }
}
