using FinanceManager.UI.Common.Interfaces;
using FinanceManager.UI.Common.Services;
using Mapster;
using MapsterMapper;
using System.Reflection;

namespace FinanceManager.UI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddMapping();
            services.AddMvc().AddRazorRuntimeCompilation();
            services.AddHttpClient<IResourcesService, ApiService>( c =>
            {
                c.BaseAddress = new Uri(configuration["ApiAddress"]);
            });

            return services;
        }

        private static IServiceCollection AddMapping(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            return services;
        }
    }
}
