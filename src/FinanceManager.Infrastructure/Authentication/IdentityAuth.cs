using ErrorOr;
using FinanceManager.Application.Authentication.Common;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Domain.Errors;
using FinanceManager.Domain.UserAggregate;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Infrastructure.Authentication
{
    internal class IdentityAuth : IAuth
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public IdentityAuth(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<ErrorOr<AuthenticationResult>> Login(string email, string password, bool persistent)
        {
            if (await _signInManager.UserManager.FindByEmailAsync(email) == null)
            {
                return UserErrors.UserNotFound;
            }

            var result = await _signInManager.PasswordSignInAsync(email, password, persistent, false);
            if (result.Succeeded)
            {
                return new AuthenticationResult(email);
            }

            return UserErrors.IncorrectPassword;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<ErrorOr<AuthenticationResult>> Register(string email, string password, bool persistent)
        {
            if(await _signInManager.UserManager.FindByEmailAsync(email) != null)
            {
                return UserErrors.DuplicateEmail;
            }

            var identityUser = new IdentityUser { UserName = email, Email = email };
            var result = await _signInManager.UserManager.CreateAsync(identityUser, password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(identityUser, persistent);
                return new AuthenticationResult(email);
            }

            return Error.Failure();
        }
    }
}
