namespace FinanceManager.UI.Models
{
    public record UpdateTagRequest(
        string OwnerId,
        string TagId,
        string Name,
        string Color);
}
