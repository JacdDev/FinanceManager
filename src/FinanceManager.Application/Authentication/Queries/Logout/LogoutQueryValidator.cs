using FluentValidation;

namespace FinanceManager.Application.Authentication.Queries.Logout
{
    public class LogoutQueryValidator : AbstractValidator<LogoutQuery>
    {
        public LogoutQueryValidator()
        {
        }
    }
}
