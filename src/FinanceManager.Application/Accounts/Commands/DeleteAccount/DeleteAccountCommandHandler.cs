using ErrorOr;
using FinanceManager.Application.Accounts.Common;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Persistence;
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

            _accountRepository.DeleteFromUser(request.UserId);

            return new AccountResult(account);
        }
    }
}
