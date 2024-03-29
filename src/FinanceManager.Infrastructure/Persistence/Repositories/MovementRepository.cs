﻿using FinanceManager.Application.Persistence;
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

        public void DeleteMany(IEnumerable<Movement> movements)
        {
            _dbContext.RemoveRange(movements);
            _dbContext.SaveChanges();
        }

        public Movement? Get(MovementId movementId)
        {
            return _dbContext.Movements.Include("Account.Tags").Include("Tags").FirstOrDefault(movement => movement.Id == movementId);
        }

        public void Update(Movement movement)
        {
            _dbContext.Update(movement);
            _dbContext.SaveChanges();
        }
    }
}
