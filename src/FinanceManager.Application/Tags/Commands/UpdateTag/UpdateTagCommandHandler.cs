using ErrorOr;
using FinanceManager.Application.Accounts.Commands.UpdateAccount;
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

namespace FinanceManager.Application.Tags.Commands.UpdateTag
{
    public class UpdateTagCommandHandler
        : IRequestHandler<UpdateTagCommand, ErrorOr<TagResult>>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IAuth _auth;
        public UpdateTagCommandHandler(ITagRepository tagRepository, IAuth auth)
        {
            _tagRepository = tagRepository;
            _auth = auth;
        }

        public async Task<ErrorOr<TagResult>> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var user = await _auth.FindUserById(request.OwnerId);
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

            var userId = UserId.Create(request.OwnerId);
            if (!(tag.Account?.Users.Contains(userId) ?? false))
            {
                return AccountErrors.PermisionDenied;
            }

            tag.SetName(request.Name);
            tag.SetColor(request.Color);

            _tagRepository.Update(tag);

            return new TagResult(
                tag.Id.Value.ToString(),
                tag.Name,
                tag.Color,
                tag.Account?.Id.Value.ToString() ?? ""
            );
        }
    }
}
