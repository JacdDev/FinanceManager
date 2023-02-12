using ErrorOr;
using FinanceManager.Application.Settings.Common;
using MediatR;

namespace FinanceManager.Application.Settings.Commands.ChangeEmail
{
    public record ChangeEmailCommand(
        string OldEmail,
        string NewEmail,
        string Password) : IRequest<ErrorOr<SettingsResult>>;
}
