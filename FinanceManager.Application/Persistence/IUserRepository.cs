using FinanceManager.Domain.Entities;

namespace FinanceManager.Application.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);
    }
}
