using FinanceManager.Domain.Entities;

namespace FinanceManager.Application.Authentication.Common
{
    public record AuthenticationResult(User User, string AuthToken);
}
