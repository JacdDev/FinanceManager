namespace FinanceManager.UI.Models
{
    public record CreateAccountRequest(
        string Name,
        string Description,
        double Amount);
}
