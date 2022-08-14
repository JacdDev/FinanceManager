using ErrorOr;
using FinanceManager.Application.Authentication.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
    string Email,
    string Password,
    string ConfirmPassword) : IRequest<ErrorOr<AuthenticationResult>>;
}
