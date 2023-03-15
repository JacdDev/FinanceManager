using FinanceManager.Domain.TagAggregate;

namespace FinanceManager.Application.Persistence
{
    public interface ITagRepository
    {
        void Add(Tag tag);
    }
}
