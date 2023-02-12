using ErrorOr;
using FinanceManager.Application.Settings.Common;
using MediatR;

namespace FinanceManager.Application.Settings.Commands.ChangePassword
{
    public record ChangePasswordCommand(
        string Email,
        string OldPassword,
        string NewPassword) : IRequest<ErrorOr<SettingsResult>>;
}
