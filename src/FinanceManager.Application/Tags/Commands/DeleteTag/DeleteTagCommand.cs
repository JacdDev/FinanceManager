using ErrorOr;
using FinanceManager.Application.Tags.Common;
using MediatR;

namespace FinanceManager.Application.Tags.Commands.DeleteTag
{
    public record DeleteTagCommand(
        string UserId,
        string TagId) : IRequest<ErrorOr<TagResult>>;
}
