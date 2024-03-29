﻿using FluentValidation;

namespace FinanceManager.Application.Authentication.Commands.DeleteAccount
{
    public class DeleteAccountCommandValidator : AbstractValidator<DeleteAccountCommand>
    {
        public DeleteAccountCommandValidator()
        {
            RuleFor(v => v.UserId).NotEmpty().WithMessage("User ID is required");
        }
    }
}
