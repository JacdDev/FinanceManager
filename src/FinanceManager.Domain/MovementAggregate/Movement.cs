using FinanceManager.Domain.AccountAggregate;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.MovementAggregate.ValueObjects;
using FinanceManager.Domain.TagAggregate;

namespace FinanceManager.Domain.MovementAggregate
{
    public class Movement : AggregateRoot<MovementId>
    {
        public Account? Account { get; private set; }
        public string Concept { get; }
        public double Amount { get; }
        public bool IsIncoming { get; }
        public DateTime ExecutionDate { get; }
        private readonly List<Tag> _tags = new();
        public IReadOnlyList<Tag> Tags => _tags.AsReadOnly();

        private Movement(
            MovementId id,
            string concept,
            double amount,
            bool isIncoming,
            DateTime executionDate) : base(id)
        {
            Concept = concept;
            Amount = amount;
            IsIncoming = isIncoming;
            ExecutionDate = executionDate;
        }

        public static Movement Create(
            string concept,
            double amount,
            bool isIncoming,
            DateTime executionDate)
        {
            return new Movement(
                MovementId.CreateUnique(),
                concept,
                amount,
                isIncoming,
                executionDate);
        }
    }
}
