using FinanceManager.Domain.AccountAggregate;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.MovementAggregate.ValueObjects;
using FinanceManager.Domain.TagAggregate;

namespace FinanceManager.Domain.MovementAggregate
{
    public class Movement : AggregateRoot<MovementId>
    {
        public Account? Account { get; private set; }
        public string Concept { get; private set; }
        public double Amount { get; private set; }
        public bool IsIncoming { get; private set; }
        public DateTime ExecutionDate { get; private set; }
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

        public void SetAccount(Account account)
        {
            Account = account;
        }

        public void SetAmount(double amount)
        {
            Amount = amount;
        }

        public void SetConcept(string concept)
        {
            Concept = concept;
        }

        public void SetIsIncoming(bool isIncoming)
        {
            IsIncoming = isIncoming;
        }

        public void SetExecutionDate(DateTime executionDate)
        {
            ExecutionDate = executionDate;
        }

        public void AddTag(Tag tag)
        {
            if (!_tags.Contains(tag))
            {
                _tags.Add(tag);
            }
        }

        public void RemoveTag(Tag tag)
        {
            if (_tags.Contains(tag))
            {
                _tags.Remove(tag);
            }
        }

        public void ClearTags()
        {
            _tags.Clear();
        }
    }
}
