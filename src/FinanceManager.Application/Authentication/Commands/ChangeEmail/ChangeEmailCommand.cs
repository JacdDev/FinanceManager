using ErrorOr;
using FinanceManager.Application.Authentication.Common;
using MediatR;

namespace FinanceManager.Application.Authentication.Commands.ChangeEmail
{
    public record ChangeEmailCommand(
        string OldEmail,
        string NewEmail,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
