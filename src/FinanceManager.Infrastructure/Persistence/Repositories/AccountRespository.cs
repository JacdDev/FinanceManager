﻿using FinanceManager.Application.Persistence;
using FinanceManager.Domain.AccountAggregate;
using FinanceManager.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Infrastructure.Persistence.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly FinanceManagerDbContext _dbContext;

        public AccountRepository(FinanceManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Account account)
        {
            _dbContext.Add(account);
            _dbContext.SaveChanges();
        }

        public void Delete(Account account)
        {
            _dbContext.Remove(account);
            _dbContext.SaveChanges();
        }

        public void DeleteFromUser(string userId)
        {
            var userIdObject = UserId.Create(userId);
            var accounts = _dbContext.Accounts.Where(account => account.Users.Any(user => user.Value == userIdObject.Value));
            foreach (var account in accounts)
            {
                if (account.Users.Count == 1)
                {
                    _dbContext.Remove(account);
                }
                else
                {
                    account.removeUser(userIdObject);
                }
            }

            _dbContext.SaveChanges();
        }

        public IEnumerable<Account> GetFromUser(string userId)
        {
            return _dbContext.Accounts.Include("Movements.Tags").Include("Tags").Where(account => account.Users.Any(user => user.Value.ToString() == userId));
        }

        public void Update(Account account)
        {
            _dbContext.Update(account);
            _dbContext.SaveChanges();
        }
    }
}
