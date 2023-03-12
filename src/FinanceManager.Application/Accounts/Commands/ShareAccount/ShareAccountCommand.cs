using ErrorOr;
using FinanceManager.Application.Accounts.Common;
using MediatR;

namespace FinanceManager.Application.Accounts.Commands.ShareAccount
{
    public record ShareAccountCommand(
        string OwnerId,
        string AccountId,
        string Email) : IRequest<ErrorOr<AccountResult>>;
}
