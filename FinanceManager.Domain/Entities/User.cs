using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Core.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public IEnumerable<Account> Accounts { get; set; } = null!;
    }
}
