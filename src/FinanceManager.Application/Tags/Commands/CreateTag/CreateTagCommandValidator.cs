using FluentValidation;

namespace FinanceManager.Application.Tags.Commands.CreateTag
{
    public class CreateTagCommandValidator : AbstractValidator<CreateTagCommand>
    {
        public CreateTagCommandValidator()
        {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(v => v.OwnerId).NotEmpty().WithMessage("Owner ID is required");
            RuleFor(v => v.Color).NotEmpty().WithMessage("Color is required");
            RuleFor(v => v.AccountId).NotEmpty().WithMessage("Account ID is required");
        }
    }
}
