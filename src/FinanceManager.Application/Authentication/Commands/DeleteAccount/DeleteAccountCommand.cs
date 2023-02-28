using ErrorOr;
using FinanceManager.Application.Authentication.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Authentication.Commands.DeleteAccount
{
    public record DeleteAccountCommand(
        string UserId) : IRequest<ErrorOr<AuthenticationResult>>;
}
