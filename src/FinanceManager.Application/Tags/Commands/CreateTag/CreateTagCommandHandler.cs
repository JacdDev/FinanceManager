using ErrorOr;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Persistence;
using FinanceManager.Application.Tags.Common;
using FinanceManager.Domain.AccountAggregate.ValueObjects;
using FinanceManager.Domain.Errors;
using FinanceManager.Domain.TagAggregate;
using MediatR;

namespace FinanceManager.Application.Tags.Commands.CreateTag
{
    public class CreateTagCommandHandler
        : IRequestHandler<CreateTagCommand, ErrorOr<TagResult>>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IAuth _auth;
        public CreateTagCommandHandler(IAccountRepository accountRepository, ITagRepository tagRepository, IAuth auth)
        {
            _accountRepository = accountRepository;
            _tagRepository = tagRepository;
            _auth = auth;
        }

        public async Task<ErrorOr<TagResult>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var user = await _auth.FindUserById(request.OwnerId);
            if (user.IsError)
            {
                return user.Errors;
            }

            var accountId = AccountId.Create(request.AccountId);
            var account = _accountRepository.GetFromUser(request.OwnerId).FirstOrDefault(account => account.Id == accountId);
            if (account is null)
            {
                return AccountErrors.PermisionDenied;
            }

            var tag = Tag.Create(request.Name, request.Color);
            tag.SetAccount(account);

            _tagRepository.Add(tag);

            return new TagResult(tag.Id?.Value.ToString() ?? "", tag.Name, tag.Color, tag.Account?.Id.Value.ToString() ?? "");
        }
    }
}
