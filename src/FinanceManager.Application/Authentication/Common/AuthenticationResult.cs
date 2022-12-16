using FinanceManager.Domain.User;

namespace FinanceManager.Application.Authentication.Common
{
    public record AuthenticationResult(User User, string AuthToken);
}
