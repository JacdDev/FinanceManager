using ErrorOr;
using FinanceManager.Application.Accounts.Common;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Movements.Common;
using FinanceManager.Application.Persistence;
using FinanceManager.Application.Tags.Common;
using FinanceManager.Domain.AccountAggregate.ValueObjects;
using FinanceManager.Domain.Errors;
using FinanceManager.Domain.UserAggregate.ValueObjects;
using MediatR;
using System.Transactions;

namespace FinanceManager.Application.Accounts.Commands.DeleteAccount
{
    public class DeleteAccountCommandHandler
        : IRequestHandler<DeleteAccountCommand, ErrorOr<AccountResult>>
    {
        private readonly IMovementRepository _movementRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IAuth _auth;
        public DeleteAccountCommandHandler(IAccountRepository accountRepository, IAuth auth, IMovementRepository movementRepository, ITagRepository tagRepository)
        {
            _auth = auth;
            _accountRepository = accountRepository;
            _movementRepository = movementRepository;
            _tagRepository = tagRepository;
        }

        public async Task<ErrorOr<AccountResult>> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _auth.FindUserById(request.UserId);
            if (user.IsError)
            {
                return user.Errors;
            }

            var accountId = AccountId.Create(request.AccountId);
            var account = _accountRepository.GetFromUser(request.UserId).FirstOrDefault(account => account.Id == accountId);

            if (account is null)
            {
                return AccountErrors.PermisionDenied;
            }

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if (account.Users.Count == 1)
                {
                    _movementRepository.DeleteMany(account.Movements);
                    _tagRepository.DeleteMany(account.Tags);
                    _accountRepository.Delete(account);
                }
                else
                {
                    account.removeUser(UserId.Create(request.UserId));
                    _accountRepository.Update(account);
                }

                scope.Complete();
            }

            return new AccountResult(
                account.Id.Value.ToString(),
                account.Name,
                account.Description,
                account.Amount,
                account.Users.Select(user => user.Value.ToString()),
                account.Movements.Select(movement => new MovementResult(
                    movement.Id.Value.ToString(),
                    movement.Concept,
                    movement.Amount,
                    movement.IsIncoming,
                    movement.ExecutionDate,
                    movement.Tags.Select(tag => new TagResult(
                        tag.Id.Value.ToString(),
                        tag.Name,
                        tag.Color,
                        tag.Account?.Id.Value.ToString() ?? "")),
                    movement.Account?.Id.Value.ToString() ?? "")),
                account.Tags.Select(tag => new TagResult(
                    tag.Id.Value.ToString(),
                    tag.Name,
                    tag.Color,
                    tag.Account?.Id.Value.ToString() ?? "")
                )
            );
        }
    }
}
