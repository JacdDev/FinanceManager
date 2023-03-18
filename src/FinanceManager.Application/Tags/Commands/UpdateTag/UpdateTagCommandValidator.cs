using FinanceManager.Application.Tags.Commands.CreateTag;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Tags.Commands.UpdateTag
{
    public class UpdateTagCommandValidator : AbstractValidator<UpdateTagCommand>
    {
        public UpdateTagCommandValidator()
        {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(v => v.OwnerId).NotEmpty().WithMessage("Owner ID is required");
            RuleFor(v => v.Color).NotEmpty().WithMessage("Color is required");
            RuleFor(v => v.TagId).NotEmpty().WithMessage("Tag ID is required");
        }
    }
}
