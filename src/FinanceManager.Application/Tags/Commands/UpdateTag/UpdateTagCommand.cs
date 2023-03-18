using ErrorOr;
using FinanceManager.Application.Accounts.Common;
using FinanceManager.Application.Tags.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Tags.Commands.UpdateTag
{
    public record UpdateTagCommand(
        string OwnerId,
        string TagId,
        string Name,
        string Color) : IRequest<ErrorOr<TagResult>>;
}
