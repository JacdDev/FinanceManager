using ErrorOr;
using FinanceManager.Application.Accounts.Common;
using MediatR;

namespace FinanceManager.Application.Accounts.Commands.UpdateAccount
{
    public record UpdateAccountCommand(
        string OwnerId,
        string AccountId,
        string Name,
        string Description) : IRequest<ErrorOr<AccountResult>>;
}
