using ErrorOr;
using FinanceManager.Application.Accounts.Common;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Movements.Common;
using FinanceManager.Application.Persistence;
using FinanceManager.Application.Tags.Common;
using FinanceManager.Domain.AccountAggregate.ValueObjects;
using FinanceManager.Domain.Errors;
using MediatR;

namespace FinanceManager.Application.Accounts.Commands.DeleteAccount
{
    public class DeleteAccountCommandHandler
        : IRequestHandler<DeleteAccountCommand, ErrorOr<AccountResult>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAuth _auth;
        public DeleteAccountCommandHandler(IAccountRepository accountRepository, IAuth auth)
        {
            _accountRepository = accountRepository;
            _auth = auth;
        }

        public async Task<ErrorOr<AccountResult>> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _auth.FindUserById(request.UserId);
            if (user.IsError)
            {
                return user.Errors;
            }

            var accountId = AccountId.Create(request.AccountId);
            var account = _accountRepository.Get(request.UserId).FirstOrDefault(account => account.Id == accountId);

            if (account is null)
            {
                return AccountErrors.PermisionDenied;
            }

            _accountRepository.Delete(account);

            return new AccountResult(
                account.Id.Value.ToString(),
                account.Name,
                account.Description,
                account.Amount,
                account.Users.Select(user => user.Value.ToString()),
                account.Movements.Select(movement => new MovementResult()),
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
