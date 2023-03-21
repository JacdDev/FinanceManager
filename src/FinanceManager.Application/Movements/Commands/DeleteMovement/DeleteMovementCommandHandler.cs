using ErrorOr;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Movements.Common;
using FinanceManager.Application.Persistence;
using FinanceManager.Application.Tags.Common;
using FinanceManager.Domain.Errors;
using FinanceManager.Domain.MovementAggregate.ValueObjects;
using FinanceManager.Domain.UserAggregate.ValueObjects;
using MediatR;

namespace FinanceManager.Application.Movements.Commands.DeleteMovement
{
    public class DeleteMovementCommandHandler
        : IRequestHandler<DeleteMovementCommand, ErrorOr<MovementResult>>
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IAuth _auth;
        public DeleteMovementCommandHandler(IMovementRepository movementRepository, IAuth auth)
        {
            _movementRepository = movementRepository;
            _auth = auth;
        }

        public async Task<ErrorOr<MovementResult>> Handle(DeleteMovementCommand request, CancellationToken cancellationToken)
        {
            var user = await _auth.FindUserById(request.UserId);
            if (user.IsError)
            {
                return user.Errors;
            }

            var movementId = MovementId.Create(request.MovementId);
            var movement = _movementRepository.Get(movementId);

            if (movement is null)
            {
                return MovementErrors.MovementNotFound;
            }

            var userId = UserId.Create(request.UserId);
            if (!(movement.Account?.Users.Contains(userId) ?? false))
            {
                return AccountErrors.PermisionDenied;
            }

            if (movement.IsIncoming)
            {
                movement.Account.SetAmount(movement.Account.Amount - movement.Amount);
            }
            else
            {
                movement.Account.SetAmount(movement.Account.Amount + movement.Amount);
            }

            _movementRepository.Delete(movement);

            return new MovementResult(
                movement.Id?.Value.ToString() ?? "",
                movement.Concept,
                movement.Amount,
                movement.IsIncoming,
                movement.ExecutionDate,
                movement.Tags.Select(tag => new TagResult(
                    tag.Id?.Value.ToString() ?? "",
                    tag.Name,
                    tag.Color,
                    tag.Account?.Id.Value.ToString() ?? ""
                    )),
                movement.Account?.Id.Value.ToString() ?? "");
        }
    }
}
