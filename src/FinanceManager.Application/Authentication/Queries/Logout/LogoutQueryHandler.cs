using ErrorOr;
using FinanceManager.Application.Accounts.Common;
using FinanceManager.Application.Authentication.Common;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Persistence;
using FinanceManager.Domain.AccountAggregate;
using FinanceManager.Domain.Errors;
using FinanceManager.Domain.UserAggregate.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Authentication.Queries.Logout
{
    public class LogoutQueryHandler
        : IRequestHandler<LogoutQuery, ErrorOr<Unit>>
    {
        private readonly IAuth _auth;

        public LogoutQueryHandler(IAuth auth)
        {
            _auth = auth;
        }

        public async Task<ErrorOr<Unit>> Handle(LogoutQuery request, CancellationToken cancellationToken)
        {
            await _auth.Logout();

            return new Unit();
        }
    }
}
