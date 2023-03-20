using ErrorOr;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Movements.Common;
using FinanceManager.Application.Persistence;
using FinanceManager.Application.Tags.Common;
using FinanceManager.Domain.AccountAggregate.ValueObjects;
using FinanceManager.Domain.Errors;
using FinanceManager.Domain.MovementAggregate;
using FinanceManager.Domain.TagAggregate.ValueObjects;
using MediatR;

namespace FinanceManager.Application.Movements.Commands.CreateMovement
{
    public class CreateMovementCommandHandler
        : IRequestHandler<CreateMovementCommand, ErrorOr<MovementResult>>
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IAuth _auth;
        public CreateMovementCommandHandler(IMovementRepository movementRepository, IAccountRepository accountRepository, ITagRepository tagRepository, IAuth auth)
        {
            _tagRepository = tagRepository;
            _movementRepository = movementRepository;
            _accountRepository = accountRepository;
            _auth = auth;
        }

        public async Task<ErrorOr<MovementResult>> Handle(CreateMovementCommand request, CancellationToken cancellationToken)
        {
            var user = await _auth.FindUserById(request.OwnerId);
            if (user.IsError)
            {
                return user.Errors;
            }

            var accountId = AccountId.Create(request.AccountId);
            var account = _accountRepository.GetFromUser(request.OwnerId).FirstOrDefault(account => account.Id == accountId);
            if (account is null)
            {
                return AccountErrors.PermisionDenied;
            }

            var movement = Movement.Create(request.Concept, request.Amount, request.IsIncoming, request.ExecutionDate);
            movement.SetAccount(account);

            foreach (var tagId in request.Tags)
            {
                var tag = _tagRepository.Get(TagId.Create(tagId));
                if (tag is null)
                {
                    return TagErrors.TagNotFound;
                }

                movement.AddTag(tag);
            }

            _movementRepository.Add(movement);

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
