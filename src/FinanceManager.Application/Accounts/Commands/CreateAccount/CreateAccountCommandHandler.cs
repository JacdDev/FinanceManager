using ErrorOr;
using FinanceManager.Application.Accounts.Common;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Movements.Common;
using FinanceManager.Application.Persistence;
using FinanceManager.Application.Tags.Common;
using FinanceManager.Domain.AccountAggregate;
using FinanceManager.Domain.UserAggregate.ValueObjects;
using MediatR;

namespace FinanceManager.Application.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandHandler
        : IRequestHandler<CreateAccountCommand, ErrorOr<AccountResult>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAuth _auth;
        public CreateAccountCommandHandler(IAccountRepository accountRepository, IAuth auth)
        {
            _accountRepository = accountRepository;
            _auth = auth;
        }

        public async Task<ErrorOr<AccountResult>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _auth.FindUserById(request.OwnerId);
            if (user.IsError)
            {
                return user.Errors;
            }

            var account = Account.Create(request.Name, request.Description, request.Amount);
            account.addUser(UserId.Create(request.OwnerId));

            _accountRepository.Add(account);

            return new AccountResult(
                account.Id.Value.ToString(), 
                account.Name, 
                account.Description, 
                account.Amount, 
                account.Users.Select(user=>user.Value.ToString()), 
                account.Movements.Select(movement=>new MovementResult()),
                account.Tags.Select(tag=>new TagResult(
                    tag.Id.Value.ToString(), 
                    tag.Name, 
                    tag.Color, 
                    tag.Account?.Id.Value.ToString()??"")
                )
            );
        }
    }
}
