using ErrorOr;
using FinanceManager.Application.Authentication.Common;
using FinanceManager.Application.Persistence;
using FinanceManager.Domain.Entities;
using FinanceManager.Domain.Errors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {

            // Validate the user does not exist
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return UserErrors.DuplicateEmail;
            }

            // Create user (generate unique ID) and persist to DB
            var user = new User
            {
                Email = command.Email,
                Password = command.Password
            };

            _userRepository.Add(user);

            await Task.CompletedTask;

            return new AuthenticationResult(user);
        }
    }
}
