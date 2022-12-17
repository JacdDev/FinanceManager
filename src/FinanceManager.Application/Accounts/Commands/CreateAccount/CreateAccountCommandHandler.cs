using ErrorOr;
using FinanceManager.Application.Accounts.Common;
using FinanceManager.Application.Persistence;
using FinanceManager.Domain.AccountAggregate;
using FinanceManager.Domain.UserAggregate.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandHandler
        : IRequestHandler<CreateAccountCommand, ErrorOr<AccountResult>>
    {
        private readonly IAccountRepository _accountRepository;

        public CreateAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<ErrorOr<AccountResult>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var account = Account.Create(request.Name, request.Description, request.Amount);
            account.addUser(UserId.Create(request.OwnerId));

            _accountRepository.Add(account);

            return new AccountResult(account);
        }
    }
}
