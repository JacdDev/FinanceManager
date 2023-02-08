using ErrorOr;
using FinanceManager.Application.Accounts.Common;
using MediatR;

namespace FinanceManager.Application.Accounts.Commands.CreateAccount
{
    public record CreateAccountCommand(
        string OwnerId,
        string Name,
        string Description,
        double Amount) : IRequest<ErrorOr<AccountResult>>;
}
