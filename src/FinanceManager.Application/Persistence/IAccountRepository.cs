using FinanceManager.Domain.AccountAggregate;

namespace FinanceManager.Application.Persistence
{
    public interface IAccountRepository
    {
        void Add(Account account);
    }
}
