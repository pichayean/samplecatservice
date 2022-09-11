using Microsoft.Extensions.DependencyInjection;
using samplecatservice.Logics;
using samplecatservice.Repository;

namespace samplecatservice
{
    public static class CatModuleExtension
    {
        public static IServiceCollection AddCatModule(this IServiceCollection services)
        {
            services.AddSingleton<CatRepository>();
            services.AddScoped<ICatLogics, CatLogics>();
            return services;
        }

    }
}
