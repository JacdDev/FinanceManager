using ErrorOr;
using FinanceManager.Application.Accounts.Common;
using FinanceManager.Application.Movements.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Movements.Commands.CreateMovement
{
    public record CreateMovementCommand(
        string OwnerId,
        double Amount,
        string Concept,
        bool IsIncoming,
        DateTime ExecutionDate,
        IEnumerable<string> Tags,
        string AccountId) : IRequest<ErrorOr<MovementResult>>;
}
