using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Core.Entities
{
    public class Account
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Amount { get; set; }
        public IEnumerable<User> Users { get; set; } = null!;
        public IEnumerable<Movement> Movements { get; set; } = null!;

    }
}
