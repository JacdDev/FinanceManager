﻿using FinanceManager.Domain.Models;
using FinanceManager.Domain.MovementAggregate.ValueObjects;
using FinanceManager.Domain.AccountAggregate.ValueObjects;
using FinanceManager.Domain.TagAggregate.ValueObjects;
using FinanceManager.Domain.TagAggregate;

namespace FinanceManager.Domain.MovementAggregate
{
    public class Movement : AggregateRoot<MovementId>
    {
        public AccountId AccountId { get; }
        public string Concept { get; }
        public double Amount { get; }
        public bool IsIncoming { get; }
        public DateTime ExecutionDate { get; }
        private readonly List<TagId> _tags = new();
        public IReadOnlyList<TagId> Tags => _tags.AsReadOnly();

        private Movement(
            MovementId id, 
            AccountId accountId, 
            string concept, 
            double amount, 
            bool isIncoming, 
            DateTime executionDate) : base(id)
        {
            AccountId = accountId;
            Concept = concept;
            Amount = amount;
            IsIncoming = isIncoming;
            ExecutionDate = executionDate;
        }

        public static Movement Create(
            AccountId accountId,
            string concept,
            double amount,
            bool isIncoming,
            DateTime executionDate)
        {
            return new Movement(
                MovementId.CreateUnique(), 
                accountId,
                concept,
                amount,
                isIncoming,
                executionDate);
        }
    }
}
