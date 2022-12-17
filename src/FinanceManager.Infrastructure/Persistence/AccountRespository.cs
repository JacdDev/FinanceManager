using FinanceManager.Application.Persistence;
using FinanceManager.Domain.AccountAggregate;
using FinanceManager.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Infrastructure.Persistence
{
    public class AccountRepository : IAccountRepository
    {
        private static readonly List<Account> _accounts = new();
        public void Add(Account account)
        {
            _accounts.Add(account);
        }
    }
}
