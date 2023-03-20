using FinanceManager.Application.Movements.Commands.CreateMovement;
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

            var createAccountResult = await _mediator.Send(command);

            return createAccountResult.Match(
                account => Ok(_mapper.Map<MovementResponse>(account)),
                errors => Problem(errors)
                );
        }
    }
}
