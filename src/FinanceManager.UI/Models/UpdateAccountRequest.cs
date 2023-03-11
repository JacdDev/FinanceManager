namespace FinanceManager.UI.Models
{
    public record UpdateAccountRequest(
        string OwnerId,
        string AccountId,
        string Name,
        string Description);
}
