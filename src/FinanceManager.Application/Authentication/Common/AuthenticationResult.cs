using FinanceManager.Domain.UserAggregate;

namespace FinanceManager.Application.Authentication.Common
{
    public record AuthenticationResult(User User, string AuthToken);
}
