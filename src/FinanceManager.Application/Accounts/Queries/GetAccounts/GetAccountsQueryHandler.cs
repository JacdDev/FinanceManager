using ErrorOr;
using FinanceManager.Application.Accounts.Commands.CreateAccount;
using FinanceManager.Application.Accounts.Common;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Persistence;
using FinanceManager.Domain.AccountAggregate;
using FinanceManager.Domain.UserAggregate.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Accounts.Queries.GetAccounts
{
    public class GetAccountsQueryHandler
        : IRequestHandler<GetAccountsQuery, ErrorOr<IEnumerable<AccountResult>>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAuth _auth;
        public GetAccountsQueryHandler(IAccountRepository accountRepository, IAuth auth)
        {
            _accountRepository = accountRepository;
            _auth = auth;
        }

        public async Task<ErrorOr<IEnumerable<AccountResult>>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            var user = await _auth.FindUserById(request.OwnerId);
            if (user.IsError)
            {
                return user.Errors;
            }

            return _accountRepository.Get(request.OwnerId).Select(account=> new AccountResult(account)).ToList();
        }
    }
}
