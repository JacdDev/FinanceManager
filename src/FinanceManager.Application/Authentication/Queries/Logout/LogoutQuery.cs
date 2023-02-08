using ErrorOr;
using MediatR;

namespace FinanceManager.Application.Authentication.Queries.Logout
{
    public record LogoutQuery() : IRequest<ErrorOr<Unit>>;
}
