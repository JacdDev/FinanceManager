using ErrorOr;
using FinanceManager.Application.Accounts.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Accounts.Commands.UpdateAccount
{
    public record UpdateAccountCommand(
        string OwnerId,
        string AccountId,
        string Name,
        string Description) : IRequest<ErrorOr<AccountResult>>;
}
