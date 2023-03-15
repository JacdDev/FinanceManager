using ErrorOr;
using FinanceManager.Application.Tags.Common;
using MediatR;

namespace FinanceManager.Application.Tags.Commands.CreateTag
{
    public record CreateTagCommand(
        string OwnerId,
        string Name,
        string Color,
        string AccountId) : IRequest<ErrorOr<TagResult>>;
}
