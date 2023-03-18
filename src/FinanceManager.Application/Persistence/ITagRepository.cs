using FinanceManager.Domain.TagAggregate;
using FinanceManager.Domain.TagAggregate.ValueObjects;

namespace FinanceManager.Application.Persistence
{
    public interface ITagRepository
    {
        void Add(Tag tag);
        Tag? Get(TagId tagId);
        void Update(Tag tag);
        void Delete(Tag tag);
    }
}
