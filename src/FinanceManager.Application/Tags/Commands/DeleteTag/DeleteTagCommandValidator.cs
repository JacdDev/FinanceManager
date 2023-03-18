using FinanceManager.Application.Tags.Commands.UpdateTag;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
