using FluentValidation;

namespace FinanceManager.Application.Authentication.Queries.Login
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(v => v.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(v => v.Email).EmailAddress().WithMessage("Invalid email format");

            RuleFor(v => v.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
