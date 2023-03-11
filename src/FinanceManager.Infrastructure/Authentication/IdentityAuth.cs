using ErrorOr;
using FinanceManager.Application.Authentication.Common;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Domain.Errors;
using FinanceManager.Domain.UserAggregate.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace FinanceManager.Infrastructure.Authentication
{
    internal class IdentityAuth : IAuth
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public IdentityAuth(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<ErrorOr<AuthenticationResult>> ChangeEmail(string oldEmail, string newEmail, string password)
        {
            var identityUser = await _signInManager.UserManager.FindByEmailAsync(oldEmail);
            if (identityUser == null)
            {
                return UserErrors.UserNotFound;
            }

            if (!await _signInManager.UserManager.CheckPasswordAsync(identityUser, password))
            {
                return UserErrors.IncorrectPassword;
            }

            if (await _signInManager.UserManager.FindByEmailAsync(newEmail) != null)
            {
                return UserErrors.DuplicateEmail;
            }

            var resultName = await _signInManager.UserManager.SetUserNameAsync(identityUser, newEmail);
            if (resultName.Succeeded)
            {
                var resultEmail = await _signInManager.UserManager.SetEmailAsync(identityUser, newEmail);
                if (resultEmail.Succeeded)
                {
                    await _signInManager.RefreshSignInAsync(identityUser);
                    return new AuthenticationResult(identityUser.Id, newEmail);
                }
                else
                {
                    //rollback
                    await _signInManager.UserManager.SetUserNameAsync(identityUser, oldEmail);
                }
            }

            return Error.Failure();
        }

        public async Task<ErrorOr<AuthenticationResult>> ChangePassword(string email, string oldPassword, string newPassword)
        {
            var identityUser = await _signInManager.UserManager.FindByEmailAsync(email);
            if (identityUser == null)
            {
                return UserErrors.UserNotFound;
            }

            if (!await _signInManager.UserManager.CheckPasswordAsync(identityUser, oldPassword))
            {
                return UserErrors.IncorrectPassword;
            }

            var result = await _signInManager.UserManager.ChangePasswordAsync(identityUser, oldPassword, newPassword);
            if (result.Succeeded)
            {
                return new AuthenticationResult(identityUser.Id, email);
            }

            return Error.Failure();
        }

        public async Task<ErrorOr<AuthenticationResult>> Login(string email, string password, bool persistent)
        {
            var identityUser = await _signInManager.UserManager.FindByEmailAsync(email);
            if (identityUser == null)
            {
                return UserErrors.UserNotFound;
            }

            if (!await _signInManager.UserManager.CheckPasswordAsync(identityUser, password))
            {
                return UserErrors.IncorrectPassword;
            }

            var result = await _signInManager.PasswordSignInAsync(email, password, persistent, false);
            if (result.Succeeded)
            {
                return new AuthenticationResult(identityUser.Id, email);
            }

            return Error.Failure();
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<ErrorOr<AuthenticationResult>> Register(string email, string password, bool persistent)
        {
            if (await _signInManager.UserManager.FindByEmailAsync(email) != null)
            {
                return UserErrors.DuplicateEmail;
            }

            var identityUser = new IdentityUser { UserName = email, Email = email };
            var result = await _signInManager.UserManager.CreateAsync(identityUser, password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(identityUser, persistent);
                return new AuthenticationResult(identityUser.Id, email);
            }

            return Error.Failure();
        }

        public async Task<ErrorOr<AuthenticationResult>> DeleteAccount(string userId)
        {
            var identityUser = await _signInManager.UserManager.FindByIdAsync(userId);
            if (identityUser == null)
            {
                return UserErrors.UserNotFound;
            }

            var result = await _signInManager.UserManager.DeleteAsync(identityUser);
            if (result.Succeeded)
            {
                await _signInManager.SignOutAsync();
                return new AuthenticationResult(identityUser.Id, identityUser.Email);
            }

            return Error.Failure();
        }

        public async Task<ErrorOr<AuthenticationResult>> FindUserById(string id)
        {
            var identityUser = await _signInManager.UserManager.FindByIdAsync(id);

            if(identityUser == null)
            {
                return UserErrors.UserNotFound;
            }

            return new AuthenticationResult(identityUser.Id, identityUser.Email);
        }

        public async Task<ErrorOr<AuthenticationResult>> FindUserByEmail(string email)
        {
            var identityUser = await _signInManager.UserManager.FindByEmailAsync(email);

            if (identityUser == null)
            {
                return UserErrors.UserNotFound;
            }

            return new AuthenticationResult(identityUser.Id, identityUser.Email);
        }
    }
}
