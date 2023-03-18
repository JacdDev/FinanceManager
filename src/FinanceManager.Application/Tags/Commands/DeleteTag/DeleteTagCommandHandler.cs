using ErrorOr;
using FinanceManager.Application.Accounts.Common;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Movements.Common;
using FinanceManager.Application.Persistence;
using FinanceManager.Application.Tags.Common;
using FinanceManager.Domain.AccountAggregate.ValueObjects;
using FinanceManager.Domain.Errors;
using FinanceManager.Domain.TagAggregate.ValueObjects;
using FinanceManager.Domain.UserAggregate.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Tags.Commands.DeleteTag
{
    public class DeleteTagCommandHandler
        : IRequestHandler<DeleteTagCommand, ErrorOr<TagResult>>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IAuth _auth;
        public DeleteTagCommandHandler(ITagRepository tagRepository, IAuth auth)
        {
            _tagRepository = tagRepository;
            _auth = auth;
        }

        public async Task<ErrorOr<TagResult>> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            var user = await _auth.FindUserById(request.UserId);
            if (user.IsError)
            {
                return user.Errors;
            }

            var tagId = TagId.Create(request.TagId);
            var tag = _tagRepository.Get(tagId);

            if (tag is null)
            {
                return TagErrors.TagNotFound;
            }

            var userId = UserId.Create(request.UserId);
            if (!(tag.Account?.Users.Contains(userId) ?? false))
            {
                return AccountErrors.PermisionDenied;
            }

            _tagRepository.Delete(tag);

            return new TagResult(
                tag.Id.Value.ToString(),
                tag.Name,
                tag.Color,
                tag.Account?.Id.Value.ToString() ?? ""
            );
        }
    }
}
