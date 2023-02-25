using ErrorOr;
using FinanceManager.Application.Authentication.Commands.ChangeEmail;
using FinanceManager.Application.Authentication.Common;
using FinanceManager.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Authentication.Commands.DeleteAccount
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IAuth _auth;
        public DeleteAccountCommandHandler(IAuth auth)
        {
            _auth = auth;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(DeleteAccountCommand command, CancellationToken cancellationToken)
        {
            var result = await _auth.DeleteAccount(command.Email);

            return result.Match<ErrorOr<AuthenticationResult>>(
                authResult => new AuthenticationResult(command.Email),
                errors => errors
            );
        }
    }
}
