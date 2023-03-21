using ErrorOr;
using FinanceManager.Application.Movements.Common;
using MediatR;

namespace FinanceManager.Application.Movements.Commands.UpdateMovement
{
    public record UpdateMovementCommand(
        string OwnerId,
        string MovementId,
        double Amount,
        string Concept,
        bool IsIncoming,
        DateTime ExecutionDate,
        IEnumerable<string> Tags) : IRequest<ErrorOr<MovementResult>>;
}
