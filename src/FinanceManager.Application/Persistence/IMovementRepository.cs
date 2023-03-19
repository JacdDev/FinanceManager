using FinanceManager.Domain.TagAggregate.ValueObjects;
using FinanceManager.Domain.TagAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceManager.Domain.MovementAggregate;
using FinanceManager.Domain.MovementAggregate.ValueObjects;

namespace FinanceManager.Application.Persistence
{
    public interface IMovementRepository
    {
        void Add(Movement movement);
        Movement? Get(MovementId movementId);
        void Update(Movement movement);
        void Delete(Movement movement);
    }
}
