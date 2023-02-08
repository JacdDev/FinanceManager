namespace FinanceManager.UI.Models
{
    public record MovementResponse(
        string Id,
        string Concept,
        double Amount,
        bool IsIncoming,
        DateTime ExecutionDate,
        List<TagResponse> tags);
}
