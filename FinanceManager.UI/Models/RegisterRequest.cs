namespace FinanceManager.UI.Models
{
    public record RegisterRequest(
    string Email,
    string Password,
    string ConfirmPassword);
}
