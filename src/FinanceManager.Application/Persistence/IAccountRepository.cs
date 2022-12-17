using FinanceManager.Domain.AccountAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Persistence
{
    public interface IAccountRepository
    {
        void Add(Account account);
    }
}
