using ErrorOr;
using FinanceManager.Application.Authentication.Common;
using MediatR;

namespace FinanceManager.Application.Authentication.Commands.DeleteAccount
{
    public record DeleteAccountCommand(
        string UserId) : IRequest<ErrorOr<AuthenticationResult>>;
}
