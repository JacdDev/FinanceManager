using FinanceManager.Application.Authentication.Commands.Register;
using FinanceManager.Application.Authentication.Common;
using FinanceManager.Application.Authentication.Queries.Login;
using FinanceManager.UI.Models;
using Mapster;

namespace FinanceManager.UI.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();

            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>();
        }
    }
}
