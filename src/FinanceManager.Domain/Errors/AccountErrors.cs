using ErrorOr;

namespace FinanceManager.Domain.Errors
{
    public static class AccountErrors
    {
        public readonly static Error PermisionDenied = Error.Custom(
            type: 401,
            code: "PermisionDenied",
            description: "User does not have permission");

        public readonly static Error DuplicateEmail = Error.Conflict(
            code: "DuplicateEmail",
            description: "User email already exists");
    }
}
