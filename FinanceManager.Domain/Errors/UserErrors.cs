using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Domain.Errors
{
    public static class UserErrors
    {
        public readonly static Error DuplicateEmail = Error.Conflict(
            code: "UserErrors.DuplicateEmail",
            description: "User email already exists");
    }
}
