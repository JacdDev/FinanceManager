using ErrorOr;
using FinanceManager.Application.Movements.Common;
using MediatR;

namespace FinanceManager.Application.Movements.Commands.CreateMovement
{
    public record CreateMovementCommand(
        string OwnerId,
        double Amount,
        string Concept,
        bool IsIncoming,
        DateTime ExecutionDate,
        IEnumerable<string> Tags,
        string AccountId) : IRequest<ErrorOr<MovementResult>>;
}
