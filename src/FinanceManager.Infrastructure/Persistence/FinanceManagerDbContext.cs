using FinanceManager.Domain.AccountAggregate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Infrastructure.Persistence
{
    public class FinanceManagerDbContext : IdentityDbContext
    {
        public FinanceManagerDbContext(DbContextOptions<FinanceManagerDbContext> options)
            : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfigurationsFromAssembly(typeof(FinanceManagerDbContext).Assembly);

            base.OnModelCreating(builder);
        }  
    }
}
