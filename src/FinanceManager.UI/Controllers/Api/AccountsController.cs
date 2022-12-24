using FinanceManager.Application.Accounts.Commands.CreateAccount;
using FinanceManager.UI.Models;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.UI.Controllers.Api
{
    [Route("api/[controller]")]
    public class AccountsController : ApiControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public AccountsController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult ListAccounts()
        {
            return Ok(Array.Empty<string>());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(
            CreateAccountRequest request)
        {
            var command = _mapper.Map<CreateAccountCommand>(request);

            var createAccountResult = await _mediator.Send(command);

            return createAccountResult.Match(
                account => Ok(_mapper.Map<AccountResponse>(account)),
                errors => Problem(errors)
                );
        }
    }
}
