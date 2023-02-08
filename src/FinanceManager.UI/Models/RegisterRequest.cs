namespace FinanceManager.UI.Models
{
    public record RegisterRequest(
    string Email,
    string Password,
    bool RememberMe);
}
