using FinanceManager.Application.Accounts.Commands.CreateAccount;
using FinanceManager.Application.Accounts.Common;
using FinanceManager.UI.Models;
using Mapster;

namespace FinanceManager.UI.Common.Mapping
{
    public class AccountMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateAccountRequest, CreateAccountCommand>();

            config.NewConfig<AccountResult, AccountResponse>()
                .Map(dest => dest.Id, src => src.Account.Id.Value)
                .Map(dest => dest, src => src.Account);

        }
    }
}
