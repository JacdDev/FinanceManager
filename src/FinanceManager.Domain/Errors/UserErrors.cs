using ErrorOr;

namespace FinanceManager.Domain.Errors
{
    public static class UserErrors
    {
        public readonly static Error DuplicateEmail = Error.Conflict(
            code: "DuplicateEmail",
            description: "User email already exists");

        public readonly static Error UserNotFound = Error.NotFound(
            code: "UserNotFound",
            description: "User does not exist");

        public readonly static Error IncorrectPassword = Error.Validation(
            code: "IncorrectPassword",
            description: "Password is not correct");
    }
}
