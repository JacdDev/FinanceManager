using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Domain.Errors
{
    public static class AccountErrors
    {
        public readonly static Error PermisionDenied = Error.Custom(
            type: 401,
            code: "PermisionDenied",
            description: "User does not have permission");
    }
}
