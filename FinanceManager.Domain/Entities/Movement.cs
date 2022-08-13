using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Core.Entities
{
    public class Movement
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Account Account { get; set; } = null!;
        public MovementType Type { get; set; } = null!;
        public string Concept { get; set; } = null!;
        public double Amount { get; set; }
        public bool IsIncoming { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<Property> properties { get; set; } = null!;
    }
}
