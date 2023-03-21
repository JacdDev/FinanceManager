using FinanceManager.Application.Persistence;
using FinanceManager.Domain.TagAggregate;
using FinanceManager.Domain.TagAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

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

        public void Delete(Tag tag)
        {
            _dbContext.Remove(tag);
            _dbContext.SaveChanges();
        }
        public void DeleteMany(IEnumerable<Tag> tags)
        {
            _dbContext.RemoveRange(tags);
            _dbContext.SaveChanges();
        }

        public Tag? Get(TagId tagId)
        {
            return _dbContext.Tags.Include("Account").FirstOrDefault(tag => tag.Id == tagId);
        }

        public void Update(Tag tag)
        {
            _dbContext.Update(tag);
            _dbContext.SaveChanges();
        }
    }
}
