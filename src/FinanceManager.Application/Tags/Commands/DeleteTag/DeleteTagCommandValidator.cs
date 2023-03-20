using FluentValidation;

namespace FinanceManager.Application.Tags.Commands.DeleteTag
{
    public class DeleteTagCommandValidator : AbstractValidator<DeleteTagCommand>
    {
        public DeleteTagCommandValidator()
        {
            RuleFor(v => v.UserId).NotEmpty().WithMessage("User ID is required");
            RuleFor(v => v.TagId).NotEmpty().WithMessage("Tag ID is required");
        }
    }
}
