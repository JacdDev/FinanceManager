using ErrorOr;
using FinanceManager.Application.Accounts.Commands.UpdateAccount;
using FinanceManager.Application.Accounts.Common;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Persistence;
using FinanceManager.Domain.AccountAggregate.ValueObjects;
using FinanceManager.Domain.Errors;
using FinanceManager.Domain.UserAggregate.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Accounts.Commands.ShareAccount
{
    public class ShareAccountCommandHandler
        : IRequestHandler<ShareAccountCommand, ErrorOr<AccountResult>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAuth _auth;
        public ShareAccountCommandHandler(IAccountRepository accountRepository, IAuth auth)
        {
            _accountRepository = accountRepository;
            _auth = auth;
        }

        public async Task<ErrorOr<AccountResult>> Handle(ShareAccountCommand request, CancellationToken cancellationToken)
        {
            var owner = await _auth.FindUserById(request.OwnerId);
            if (owner.IsError)
            {
                return owner.Errors;
            }

            var accountId = AccountId.Create(request.AccountId);
            var account = _accountRepository.Get(request.OwnerId).FirstOrDefault(account => account.Id == accountId);

            if (account is null)
            {
                return AccountErrors.PermisionDenied;
            }

            var newUser = await _auth.FindUserByEmail(request.Email);
            if (newUser.IsError)
            {
                return newUser.Errors;
            }

            var userId = UserId.Create(newUser.Value.UserId);
            if (account.Users.Contains(userId))
            {
                return AccountErrors.DuplicateEmail;
            }

            account.addUser(userId);
            _accountRepository.Update(account);

            return new AccountResult(account);
        }
    }
}
