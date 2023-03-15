using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Persistence;
using FinanceManager.Infrastructure.Authentication;
using FinanceManager.Infrastructure.Persistence;
using FinanceManager.Infrastructure.Persistence.Repositories;
using FinanceManager.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddPersistence(configuration);

            services.AddAuth();

            return services;
        }

        private static IServiceCollection AddAuth(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<FinanceManagerDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/authentication/login";
                options.LogoutPath = "/authentication/logout";
                options.AccessDeniedPath = "/";
            });

            services.AddScoped<IAuth, IdentityAuth>();

            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<FinanceManagerDbContext>(options =>
            {
                options.UseMySql(configuration["ConnectionStrings:Database"], ServerVersion.AutoDetect(configuration["ConnectionStrings:Database"]));
            });
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITagRepository, TagRepository>();

            return services;
        }
    }
}
