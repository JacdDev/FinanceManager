using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Domain.Errors
{
    public static class TagErrors
    {

        public readonly static Error TagNotFound = Error.NotFound(
            code: "TagNotFound",
            description: "Tag does not exist");
    }
}
