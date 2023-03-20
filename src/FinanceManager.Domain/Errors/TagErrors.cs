using ErrorOr;

namespace FinanceManager.Domain.Errors
{
    public static class TagErrors
    {

        public readonly static Error TagNotFound = Error.NotFound(
            code: "TagNotFound",
            description: "Tag does not exist");
    }
}
