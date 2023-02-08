using ErrorOr;
using FinanceManager.Application.Accounts.Commands.CreateAccount;
using FinanceManager.Application.Accounts.Common;
using FinanceManager.Application.Authentication.Commands.Register;
using FinanceManager.Application.Authentication.Common;
using FinanceManager.Application.Persistence;
using FinanceManager.Domain.AccountAggregate;
using FinanceManager.Domain.UserAggregate.ValueObjects;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Authentication.Queries.Logout
{
    public class LogoutQueryValidator : AbstractValidator<LogoutQuery>
    {
        public LogoutQueryValidator()
        {
        }
    }
}
