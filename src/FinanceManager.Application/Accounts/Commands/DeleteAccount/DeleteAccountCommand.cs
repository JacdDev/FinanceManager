using ErrorOr;
using FinanceManager.Application.Accounts.Common;
using MediatR;

namespace FinanceManager.Application.Accounts.Commands.DeleteAccount
{
    public record DeleteAccountCommand(
        string UserId,
        string AccountId) : IRequest<ErrorOr<AccountResult>>;
}
