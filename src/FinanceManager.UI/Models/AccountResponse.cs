namespace FinanceManager.UI.Models
{
    public record AccountResponse(
        string Id,
        string Name,
        string Description,
        double Amount,
        ICollection<TagResponse> Tags,
        ICollection<MovementResponse> Movements);
}
