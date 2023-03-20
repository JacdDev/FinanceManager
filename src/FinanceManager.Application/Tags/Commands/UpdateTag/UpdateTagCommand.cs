using ErrorOr;
using FinanceManager.Application.Tags.Common;
using MediatR;

namespace FinanceManager.Application.Tags.Commands.UpdateTag
{
    public record UpdateTagCommand(
        string OwnerId,
        string TagId,
        string Name,
        string Color) : IRequest<ErrorOr<TagResult>>;
}
