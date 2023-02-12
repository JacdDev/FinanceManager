using FinanceManager.Application.Settings.Commands.ChangeEmail;
using FinanceManager.Application.Settings.Commands.ChangePassword;
using FinanceManager.Application.Settings.Common;
using FinanceManager.UI.Models;
using Mapster;

namespace FinanceManager.UI.Common.Mapping
{
    public class SettingsMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ChangeEmailRequest, ChangeEmailCommand>();

            config.NewConfig<ChangePasswordRequest, ChangePasswordCommand>();

            config.NewConfig<SettingsResult, SettingsResponse>();
        }
    }
}
