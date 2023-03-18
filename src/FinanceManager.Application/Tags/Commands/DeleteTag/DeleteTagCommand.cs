using ErrorOr;
using FinanceManager.Application.Tags.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Tags.Commands.DeleteTag
{
    public record DeleteTagCommand(
        string UserId,
        string TagId) : IRequest<ErrorOr<TagResult>>;
}
