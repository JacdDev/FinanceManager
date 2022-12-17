using FinanceManager.Domain.UserAggregate;

namespace FinanceManager.Application.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);
    }
}
