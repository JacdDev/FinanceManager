using ErrorOr;
using FinanceManager.Application.Authentication.Common;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Persistence;
using MediatR;
using System.Transactions;

namespace FinanceManager.Application.Authentication.Commands.DeleteAccount
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IAuth _auth;
        private readonly IAccountRepository _accountRepository;
        public DeleteAccountCommandHandler(IAuth auth, IAccountRepository accountRepository)
        {
            _auth = auth;
            _accountRepository = accountRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(DeleteAccountCommand command, CancellationToken cancellationToken)
        {
            ErrorOr<AuthenticationResult> result;
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                _accountRepository.DeleteFromUser(command.UserId);
                result = await _auth.DeleteAccount(command.UserId);

                if (!result.IsError)
                {
                    scope.Complete();
                }
            }

            return result;
        }
    }
}
