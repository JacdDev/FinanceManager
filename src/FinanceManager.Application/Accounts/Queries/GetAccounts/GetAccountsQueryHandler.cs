using ErrorOr;
using FinanceManager.Application.Accounts.Common;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Movements.Common;
using FinanceManager.Application.Persistence;
using FinanceManager.Application.Tags.Common;
using MediatR;

namespace FinanceManager.Application.Accounts.Queries.GetAccounts
{
    public class GetAccountsQueryHandler
        : IRequestHandler<GetAccountsQuery, ErrorOr<IEnumerable<AccountResult>>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAuth _auth;
        public GetAccountsQueryHandler(IAccountRepository accountRepository, IAuth auth)
        {
            _accountRepository = accountRepository;
            _auth = auth;
        }

        public async Task<ErrorOr<IEnumerable<AccountResult>>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            var user = await _auth.FindUserById(request.OwnerId);
            if (user.IsError)
            {
                return user.Errors;
            }

            return _accountRepository.GetFromUser(request.OwnerId).Select(account => new AccountResult(
                account.Id.Value.ToString(),
                account.Name,
                account.Description,
                account.Amount,
                account.Users.Select(user => user.Value.ToString()),
                account.Movements.Select(movement => new MovementResult(
                    movement.Id.Value.ToString(),
                    movement.Concept,
                    movement.Amount,
                    movement.IsIncoming,
                    movement.ExecutionDate,
                    movement.Tags.Select(tag => new TagResult(
                        tag.Id.Value.ToString(),
                        tag.Name,
                        tag.Color,
                        tag.Account?.Id.Value.ToString() ?? "")),
                    movement.Account?.Id.Value.ToString() ?? "")),
                account.Tags.Select(tag => new TagResult(
                    tag.Id.Value.ToString(),
                    tag.Name,
                    tag.Color,
                    tag.Account?.Id.Value.ToString() ?? "")
                )
            )).ToList();
        }
    }
}
