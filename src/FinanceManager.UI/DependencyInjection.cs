using FinanceManager.UI.Common.Interfaces;
using FinanceManager.UI.Common.Services;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Reflection;

namespace FinanceManager.UI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddMapping();
            services.AddMvc()
                .AddControllersAsServices()
                .AddRazorRuntimeCompilation()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);

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
