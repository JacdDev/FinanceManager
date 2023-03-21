namespace FinanceManager.UI.Models
{
    public record UpdateMovementRequest(
        string OwnerId,
        string MovementId,
        double Amount,
        string Concept,
        bool IsIncoming,
        DateTime ExecutionDate,
        IEnumerable<string> Tags);
}
