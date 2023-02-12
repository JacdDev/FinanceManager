namespace FinanceManager.UI.Models
{
    public record ChangePasswordRequest(
        string Email,
        string OldPassword,
        string NewPassword);
}
