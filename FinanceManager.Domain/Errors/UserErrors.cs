using ErrorOr;

namespace FinanceManager.Domain.Errors
{
    public static class UserErrors
    {
        public readonly static Error DuplicateEmail = Error.Conflict(
            code: "DuplicateEmail",
            description: "User email already exists");
    }
}
