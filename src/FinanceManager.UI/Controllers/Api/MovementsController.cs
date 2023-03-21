using FinanceManager.Application.Movements.Commands.CreateMovement;
using FinanceManager.Application.Movements.Commands.DeleteMovement;
using FinanceManager.Application.Movements.Commands.UpdateMovement;
using FinanceManager.UI.Models;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.UI.Controllers.Api
{
    [Route("api/[controller]")]
    public class MovementsController : ApiControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public MovementsController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovement(
            CreateMovementRequest request)
        {
            var command = _mapper.Map<CreateMovementCommand>(request);

            var createMovementResult = await _mediator.Send(command);

            return createMovementResult.Match(
                movement => Ok(_mapper.Map<MovementResponse>(movement)),
                errors => Problem(errors)
                );
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMovement(
            UpdateMovementRequest request)
        {
            var command = _mapper.Map<UpdateMovementCommand>(request);

            var updateMovementResult = await _mediator.Send(command);

            return updateMovementResult.Match(
                movement => Ok(_mapper.Map<MovementResponse>(movement)),
                errors => Problem(errors)
                );
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMovement(
            DeleteMovementRequest request)
        {
            var command = _mapper.Map<DeleteMovementCommand>(request);

            var deleteMovementResult = await _mediator.Send(command);

            return deleteMovementResult.Match(
                movement => Ok(_mapper.Map<MovementResponse>(movement)),
                errors => Problem(errors)
                );
        }
    }
}
