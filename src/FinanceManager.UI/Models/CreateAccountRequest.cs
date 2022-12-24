namespace FinanceManager.UI.Models
{
    public record CreateAccountRequest(
        string OwnerId,
        string Name,
        string Description,
        double Amount);
}
