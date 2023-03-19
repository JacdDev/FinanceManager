namespace FinanceManager.UI.Models
{
    public record CreateMovementRequest(
        string OwnerId,
        double Amount,
        string Concept,
        bool IsIncoming,
        DateTime ExecutionDate,
        IEnumerable<string> Tags,
        string AccountId);
}
