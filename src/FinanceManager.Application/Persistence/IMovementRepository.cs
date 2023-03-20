using FinanceManager.Domain.MovementAggregate;
using FinanceManager.Domain.MovementAggregate.ValueObjects;

namespace FinanceManager.Application.Persistence
{
    public interface IMovementRepository
    {
        void Add(Movement movement);
        Movement? Get(MovementId movementId);
        void Update(Movement movement);
        void Delete(Movement movement);
    }
}
