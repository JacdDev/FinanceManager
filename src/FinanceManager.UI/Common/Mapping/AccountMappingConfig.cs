using FinanceManager.Application.Accounts.Commands.CreateAccount;
using FinanceManager.Application.Accounts.Common;
using FinanceManager.Application.Authentication.Commands.Register;
using FinanceManager.Application.Authentication.Common;
using FinanceManager.UI.Models;
using Mapster;

namespace FinanceManager.UI.Common.Mapping
{
    public class AccountMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateAccountRequest Request, string OwnerId), CreateAccountCommand>()
                .Map(dest => dest.OwnerId, src => src.OwnerId)
                .Map(dest => dest, src => src.Request);

            //config.NewConfig<AccountResult, AccountResponse>()
            //    .Map(dest => dest.Id, src => src.Account.Id.Value)
            //    .Map(dest => dest, src => src.Account.Name)
            //    .Map(dest => dest.Description, src => src.Account.Description)
            //    .Map(dest => dest.Amount, src => src.Account.Amount)
            //    .Map(dest => dest.Movements, src => src.Account.Movement);

            config.NewConfig<AccountResult, AccountResponse>()
                .Map(dest => dest.Id, src => src.Account.Id.Value)
                .Map(dest => dest, src => src.Account);

        }
    }
}
