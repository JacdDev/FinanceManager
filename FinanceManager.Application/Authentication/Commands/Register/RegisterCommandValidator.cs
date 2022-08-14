using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Authentication.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(v => v.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(v => v.Email).EmailAddress().WithMessage("Invalid email format");

            RuleFor(v => v.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(v => v.Password).MinimumLength(8).WithMessage("Password length must be equal or greater than 8");
            RuleFor(v => v.Password).Matches("[A-Z]").WithMessage("Password must contain an uppercase letter");
            RuleFor(v => v.Password).Matches("[a-z]").WithMessage("Password must contain an lowercase letter");
            RuleFor(v => v.Password).Matches("[0-9]").WithMessage("Password must contain a number");
            RuleFor(v => v.Password).Matches("[^a-zA-Z0-9]").WithMessage("Password must contain a special character");

            RuleFor(v => v.ConfirmPassword).NotEmpty().WithMessage("Confirm password is required");
            RuleFor(v => v.ConfirmPassword).Equal(v => v.Password).WithMessage("Passwords must match");
        }
    }
}
