using FinanceManager.Application.Persistence;
using FinanceManager.Domain.TagAggregate.ValueObjects;
using FinanceManager.Domain.TagAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceManager.Domain.MovementAggregate;
using FinanceManager.Domain.MovementAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Infrastructure.Persistence.Repositories
{
    public class MovementRepository : IMovementRepository
    {
        private readonly FinanceManagerDbContext _dbContext;

        public MovementRepository(FinanceManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Movement movement)
        {
            _dbContext.Add(movement);
            _dbContext.SaveChanges();
        }

        public void Delete(Movement movement)
        {
            _dbContext.Remove(movement);
            _dbContext.SaveChanges();
        }

        public Movement? Get(MovementId movementId)
        {
            return _dbContext.Movements.Include("Account").FirstOrDefault(movement => movement.Id == movementId);
        }

        public void Update(Movement movement)
        {
            _dbContext.Update(movement);
            _dbContext.SaveChanges();
        }
    }
}
