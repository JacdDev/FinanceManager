namespace FinanceManager.UI.Models
{
    public record DeleteMovementRequest(
        string UserId,
        string MovementId);
}
