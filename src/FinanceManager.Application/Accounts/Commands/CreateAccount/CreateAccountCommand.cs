using ErrorOr;
using FinanceManager.Application.Accounts.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Accounts.Commands.CreateAccount
{
    public record CreateAccountCommand(
        string OwnerId,
        string Name,
        string Description,
        double Amount) : IRequest<ErrorOr<AccountResult>>;
}
