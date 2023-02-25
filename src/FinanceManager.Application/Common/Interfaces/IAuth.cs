using ErrorOr;
using FinanceManager.Application.Authentication.Common;

namespace FinanceManager.Application.Common.Interfaces
{
    public interface IAuth
    {
        public Task<ErrorOr<AuthenticationResult>> Register(string email, string password, bool persistent);
        public Task<ErrorOr<AuthenticationResult>> Login(string email, string password, bool persistent);
        public Task<ErrorOr<AuthenticationResult>> ChangeEmail(string oldEmail, string newEmail, string password);
        public Task<ErrorOr<AuthenticationResult>> ChangePassword(string email, string oldPassword, string newPassword);
        public Task<ErrorOr<AuthenticationResult>> DeleteAccount(string email);
        public Task Logout();
    }
}
