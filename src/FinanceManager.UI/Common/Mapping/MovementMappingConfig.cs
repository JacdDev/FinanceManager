using FinanceManager.Application.Movements.Commands.CreateMovement;
using FinanceManager.Application.Movements.Commands.DeleteMovement;
using FinanceManager.Application.Movements.Commands.UpdateMovement;
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

            config.NewConfig<UpdateMovementRequest, UpdateMovementCommand>();

            config.NewConfig<DeleteMovementRequest, DeleteMovementCommand>();

            config.NewConfig<MovementResult, MovementResponse>();
        }
    }
}
