namespace FinanceManager.UI.Models
{
    public record ChangeEmailRequest(
        string OldEmail,
        string NewEmail,
        string Password);
}
