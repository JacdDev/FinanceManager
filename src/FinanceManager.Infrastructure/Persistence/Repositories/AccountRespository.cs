using FinanceManager.Application.Persistence;
using FinanceManager.Domain.AccountAggregate;

namespace FinanceManager.Infrastructure.Persistence.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly FinanceManagerDbContext _dbContext;

        public AccountRepository(FinanceManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Account account)
        {
            _dbContext.Add(account);
            _dbContext.SaveChanges();
        }
    }
}
