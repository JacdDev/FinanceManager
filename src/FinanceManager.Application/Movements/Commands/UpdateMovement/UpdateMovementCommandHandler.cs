using ErrorOr;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Movements.Common;
using FinanceManager.Application.Persistence;
using FinanceManager.Application.Tags.Common;
using FinanceManager.Domain.Errors;
using FinanceManager.Domain.MovementAggregate.ValueObjects;
using FinanceManager.Domain.TagAggregate.ValueObjects;
using FinanceManager.Domain.UserAggregate.ValueObjects;
using MediatR;

namespace FinanceManager.Application.Movements.Commands.UpdateMovement
{
    public class UpdateMovementCommandHandler
        : IRequestHandler<UpdateMovementCommand, ErrorOr<MovementResult>>
    {
        private readonly IMovementRepository _movementRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IAuth _auth;
        public UpdateMovementCommandHandler(IMovementRepository movementRepository, ITagRepository tagRepository, IAuth auth)
        {
            _movementRepository = movementRepository;
            _tagRepository = tagRepository;
            _auth = auth;
        }

        public async Task<ErrorOr<MovementResult>> Handle(UpdateMovementCommand request, CancellationToken cancellationToken)
        {
            var user = await _auth.FindUserById(request.OwnerId);
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

            var userId = UserId.Create(request.OwnerId);
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

            if (request.IsIncoming)
            {
                movement.Account.SetAmount(movement.Account.Amount + request.Amount);
            }
            else
            {
                movement.Account.SetAmount(movement.Account.Amount - request.Amount);
            }

            movement.SetAmount(request.Amount);
            movement.SetConcept(request.Concept);
            movement.SetExecutionDate(request.ExecutionDate);
            movement.SetIsIncoming(request.IsIncoming);
            movement.ClearTags();
            foreach (var tagId in request.Tags)
            {
                var tag = _tagRepository.Get(TagId.Create(tagId));
                if (tag is null || !movement.Account.Tags.Contains(tag))
                {
                    return TagErrors.TagNotFound;
                }

                movement.AddTag(tag);
            }

            _movementRepository.Update(movement);


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
                movement.Account?.Id.Value.ToString() ?? ""
            );
        }
    }
}
