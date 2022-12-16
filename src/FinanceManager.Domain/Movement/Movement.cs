using FinanceManager.Domain.Models;
using FinanceManager.Domain.Movement.ValueObjects;
using FinanceManager.Domain.Account.ValueObjects;
using FinanceManager.Domain.Tag.ValueObjects;

namespace FinanceManager.Domain.Movement
{
    public class Movement : AggregateRoot<MovementId>
    {
        public AccountId AccountId { get; }
        public string Concept { get; }
        public double Amount { get; }
        public bool IsIncoming { get; }
        public DateTime Date { get; }
        private readonly List<TagId> _tags = new();
        public IReadOnlyList<TagId> Tags => _tags.AsReadOnly();

        private Movement(
            MovementId id, 
            AccountId accountId, 
            string concept, 
            double amount, 
            bool isIncoming, 
            DateTime date) : base(id)
        {
            AccountId = accountId;
            Concept = concept;
            Amount = amount;
            IsIncoming = isIncoming;
            Date = date;
        }

        public static Movement Create(
            AccountId accountId,
            string concept,
            double amount,
            bool isIncoming,
            DateTime date)
        {
            return new Movement(
                MovementId.CreateUnique(), 
                accountId,
                concept,
                amount,
                isIncoming,
                date);
        }
    }
}
