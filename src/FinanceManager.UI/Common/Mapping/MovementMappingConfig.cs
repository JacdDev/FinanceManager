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
