using ErrorOr;
using FinanceManager.Application.Authentication.Common;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Persistence;
using FinanceManager.Domain.User;
using FinanceManager.Domain.Errors;
using MediatR;

namespace FinanceManager.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            // Validate the user does not exist
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return UserErrors.DuplicateEmail;
            }

            // Create user (generate unique ID) and persist to DB
            var user = User.Create(command.Email, command.Password);

            _userRepository.Add(user);


            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
