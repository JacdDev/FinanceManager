using ErrorOr;
using FinanceManager.Application.Movements.Common;
using MediatR;

namespace FinanceManager.Application.Movements.Commands.DeleteMovement
{
    public record DeleteMovementCommand(
        string UserId,
        string MovementId) : IRequest<ErrorOr<MovementResult>>;
}
