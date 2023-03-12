using FluentValidation;

namespace FinanceManager.Application.Accounts.Queries.GetAccounts
{
    public class GetAccountsQueryValidator : AbstractValidator<GetAccountsQuery>
    {
        public GetAccountsQueryValidator()
        {
            RuleFor(v => v.OwnerId).NotEmpty().WithMessage("Owner ID is required");
        }
    }
}
