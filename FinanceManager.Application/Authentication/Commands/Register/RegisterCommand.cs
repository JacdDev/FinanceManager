using ErrorOr;
using FinanceManager.Application.Authentication.Common;
using MediatR;

namespace FinanceManager.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
    string Email,
    string Password,
    string ConfirmPassword) : IRequest<ErrorOr<AuthenticationResult>>;
}
