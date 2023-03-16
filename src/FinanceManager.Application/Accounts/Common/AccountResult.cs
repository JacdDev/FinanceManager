using FinanceManager.Domain.AccountAggregate;
using FinanceManager.Domain.MovementAggregate;
using FinanceManager.Domain.TagAggregate;
using FinanceManager.Domain.UserAggregate.ValueObjects;
using FinanceManager.Domain.UserAggregate;
using FinanceManager.Application.Tags.Common;
using FinanceManager.Application.Movements.Common;

namespace FinanceManager.Application.Accounts.Common
{
    public record AccountResult(
        string Id,
        string Name,
        string Description,
        double Amount,
        IEnumerable<string> Users,
        IEnumerable<MovementResult> Movements,
        IEnumerable<TagResult> Tags);
}
