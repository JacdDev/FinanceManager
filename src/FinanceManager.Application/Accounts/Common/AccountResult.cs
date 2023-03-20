using FinanceManager.Application.Movements.Common;
using FinanceManager.Application.Tags.Common;

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
