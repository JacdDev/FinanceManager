using ErrorOr;
using FinanceManager.Application.Authentication.Common;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Persistence;
using FinanceManager.Domain.UserAggregate.ValueObjects;
using MediatR;
using System.Transactions;

namespace FinanceManager.Application.Authentication.Commands.DeleteAccount
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IAuth _auth;
        private readonly IAccountRepository _accountRepository;
        private readonly IMovementRepository _movementRepository;
        private readonly ITagRepository _tagRepository;
        public DeleteAccountCommandHandler(IAuth auth, IAccountRepository accountRepository, IMovementRepository movementRepository, ITagRepository tagRepository)
        {
            _auth = auth;
            _accountRepository = accountRepository;
            _movementRepository = movementRepository;
            _tagRepository = tagRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(DeleteAccountCommand command, CancellationToken cancellationToken)
        {
            ErrorOr<AuthenticationResult> result;
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var accounts = _accountRepository.GetFromUser(command.UserId).ToList();
                foreach (var account in accounts)
                {
                    if (account.Users.Count == 1)
                    {
                        _movementRepository.DeleteMany(account.Movements);
                        _tagRepository.DeleteMany(account.Tags);
                        _accountRepository.Delete(account);
                    }
                    else
                    {
                        account.removeUser(UserId.Create(command.UserId));
                        _accountRepository.Update(account);
                    }
                }

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
