using FinanceManager.Application.Authentication.Commands.Register;
using FinanceManager.Application.Authentication.Common;
using FinanceManager.UI.Models;
using Mapster;

namespace FinanceManager.UI.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Email, src => src.User.Email);
        }
    }
}
