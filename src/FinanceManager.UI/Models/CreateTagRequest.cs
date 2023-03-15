namespace FinanceManager.UI.Models
{
    public record CreateTagRequest(
        string OwnerId,
        string Name,
        string Color,
        string AccountId);
}
