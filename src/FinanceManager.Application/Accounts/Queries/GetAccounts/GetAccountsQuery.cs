using ErrorOr;
using FinanceManager.Application.Accounts.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Accounts.Queries.GetAccounts
{
    public record GetAccountsQuery(
        string OwnerId) : IRequest<ErrorOr<IEnumerable<AccountResult>>>;
}
