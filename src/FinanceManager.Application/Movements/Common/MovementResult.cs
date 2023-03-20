using FinanceManager.Application.Tags.Common;

namespace FinanceManager.Application.Movements.Common
{
    public record MovementResult(
        string Id,
        string Concept,
        double Amount,
        bool IsIncoming,
        DateTime ExecutionDate,
        IEnumerable<TagResult> Tags,
        string AccountId);
}
