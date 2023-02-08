﻿using ErrorOr;
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

namespace FinanceManager.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler
        : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IAuth _auth;

        public LoginQueryHandler(IAuth auth)
        {
            _auth = auth;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            return await _auth.Login(request.Email, request.Password, request.RememberMe);
        }
    }
}
