using ErrorOr;
using FinanceManager.Application.Accounts.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Accounts.Commands.ShareAccount
{
    public record ShareAccountCommand(
        string OwnerId,
        string AccountId,
        string Email) : IRequest<ErrorOr<AccountResult>>;
}
