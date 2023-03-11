namespace FinanceManager.UI.Models
{
    public record ShareAccountRequest(
        string OwnerId,
        string AccountId,
        string Email);
}
