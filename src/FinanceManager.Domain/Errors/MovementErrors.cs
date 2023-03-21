using ErrorOr;

namespace FinanceManager.Domain.Errors
{
    public static class MovementErrors
    {

        public readonly static Error MovementNotFound = Error.NotFound(
            code: "MovementNotFound",
            description: "Movement does not exist");
    }
}
