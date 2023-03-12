using FinanceManager.Application.Accounts.Commands.CreateAccount;
using FinanceManager.Application.Accounts.Commands.DeleteAccount;
using FinanceManager.Application.Accounts.Commands.ShareAccount;
using FinanceManager.Application.Accounts.Commands.UpdateAccount;
using FinanceManager.Application.Accounts.Common;
using FinanceManager.Application.Accounts.Queries.GetAccounts;
using FinanceManager.UI.Models;
using Mapster;

namespace FinanceManager.UI.Common.Mapping
{
    public class AccountMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateAccountRequest, CreateAccountCommand>();

            config.NewConfig<GetAccountsRequest, GetAccountsQuery>();

            config.NewConfig<UpdateAccountRequest, UpdateAccountCommand>();

            config.NewConfig<ShareAccountRequest, ShareAccountCommand>();

            config.NewConfig<DeleteAccountRequest, DeleteAccountCommand>();

            config.NewConfig<AccountResult, AccountResponse>()
                .Map(dest => dest.Id, src => src.Account.Id.Value)
                .Map(dest => dest, src => src.Account);

        }
    }
}
