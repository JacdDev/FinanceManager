using FinanceManager.Application.Persistence;
using FinanceManager.Domain.TagAggregate;

namespace FinanceManager.Infrastructure.Persistence.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly FinanceManagerDbContext _dbContext;

        public TagRepository(FinanceManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Tag tag)
        {
            _dbContext.Add(tag);
            _dbContext.SaveChanges();
        }
    }
}
