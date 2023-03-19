using FinanceManager.Application.Accounts.Commands.CreateAccount;
using FinanceManager.Application.Accounts.Commands.ShareAccount;
using FinanceManager.Application.Accounts.Commands.UpdateAccount;
using FinanceManager.Application.Accounts.Common;
using FinanceManager.Application.Accounts.Queries.GetAccounts;
using FinanceManager.Application.Movements.Commands.CreateMovement;
using FinanceManager.Application.Movements.Common;
using FinanceManager.UI.Models;
using Mapster;

namespace FinanceManager.UI.Common.Mapping
{
    public class MovementMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {

            config.NewConfig<CreateMovementRequest, CreateMovementCommand>();

            config.NewConfig<MovementResult, MovementResponse>();

        }
    }
}
