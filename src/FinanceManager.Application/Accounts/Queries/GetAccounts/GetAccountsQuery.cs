using ErrorOr;
using FinanceManager.Application.Accounts.Common;
using MediatR;

namespace FinanceManager.Application.Accounts.Queries.GetAccounts
{
    public record GetAccountsQuery(
        string OwnerId) : IRequest<ErrorOr<IEnumerable<AccountResult>>>;
}
