using ErrorOr;
using FinanceManager.Application.Authentication.Common;
using MediatR;

namespace FinanceManager.Application.Authentication.Commands.ChangePassword
{
    public record ChangePasswordCommand(
        string Email,
        string OldPassword,
        string NewPassword) : IRequest<ErrorOr<AuthenticationResult>>;
}
