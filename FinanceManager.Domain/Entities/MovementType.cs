using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Core.Entities
{
    public class MovementType
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public MovementType ParentType { get; set; } = null!;
        public string Name { get; set; } = null!;
        public IEnumerable<Movement> Movements { get; set; } = null!;

    }
}
