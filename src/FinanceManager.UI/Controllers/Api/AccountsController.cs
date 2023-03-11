using FinanceManager.Application.Accounts.Commands.CreateAccount;
using FinanceManager.Application.Accounts.Commands.ShareAccount;
using FinanceManager.Application.Accounts.Commands.UpdateAccount;
using FinanceManager.Application.Accounts.Queries.GetAccounts;
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
        public async Task<IActionResult> GetAccounts(
            GetAccountsRequest request)
        {
            var command = _mapper.Map<GetAccountsQuery>(request);

            var getAccountsResult = await _mediator.Send(command);

            return getAccountsResult.Match(
                account => Ok(_mapper.Map<IEnumerable<AccountResponse>>(account)),
                errors => Problem(errors)
                );
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

        [HttpPost]
        public async Task<IActionResult> UpdateAccount(
            UpdateAccountRequest request)
        {
            var command = _mapper.Map<UpdateAccountCommand>(request);

            var createAccountResult = await _mediator.Send(command);

            return createAccountResult.Match(
                account => Ok(_mapper.Map<AccountResponse>(account)),
                errors => Problem(errors)
                );
        }

        [HttpPost]
        public async Task<IActionResult> ShareAccount(
            ShareAccountRequest request)
        {
            var command = _mapper.Map<ShareAccountCommand>(request);

            var createAccountResult = await _mediator.Send(command);

            return createAccountResult.Match(
                account => Ok(_mapper.Map<AccountResponse>(account)),
                errors => Problem(errors)
                );
        }
    }
}
