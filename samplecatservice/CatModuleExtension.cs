using Microsoft.Extensions.DependencyInjection;
using samplecatservice.Logics;
using samplecatservice.Repository;
using StackExchange.Redis;
using Microsoft.Extensions.Configuration;

namespace samplecatservice
{
    public static class CatModuleExtension
    {
        public static IServiceCollection AddCatModule(this IServiceCollection services
            , IConfiguration configuration)
        {
            var muxer = ConnectionMultiplexer.Connect(configuration["ConnectionStrings:Redis"].ToString());
            services.AddSingleton<IConnectionMultiplexer>(muxer);
            services.AddScoped<ICatLogics, CatLogics>();
            services.AddScoped<IRepository, CatRepository>();

            return services;
        }

    }
}
