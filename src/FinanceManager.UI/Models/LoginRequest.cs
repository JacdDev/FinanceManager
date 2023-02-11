namespace FinanceManager.UI.Models
{
    public record LoginRequest(
    string Email,
    string Password,
    bool RememberMe,
    string returnUrl);
}
