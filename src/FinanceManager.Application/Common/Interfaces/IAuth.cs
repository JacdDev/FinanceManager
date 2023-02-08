using ErrorOr;
using FinanceManager.Application.Authentication.Common;

namespace FinanceManager.Application.Common.Interfaces
{
    public interface IAuth
    {
        public Task<ErrorOr<AuthenticationResult>> Register(string email, string password, bool persistent);
        public Task<ErrorOr<AuthenticationResult>> Login(string email, string password, bool persistent);
        public Task Logout();
    }
}
