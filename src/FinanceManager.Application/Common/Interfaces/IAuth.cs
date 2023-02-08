using ErrorOr;
using FinanceManager.Application.Authentication.Common;
using FinanceManager.Domain.Errors;
using FinanceManager.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Common.Interfaces
{
    public interface IAuth
    {
        public Task<ErrorOr<AuthenticationResult>> Register(string email, string password, bool persistent);
        public Task<ErrorOr<AuthenticationResult>> Login(string email, string password, bool persistent);
        public Task Logout();
    }
}
