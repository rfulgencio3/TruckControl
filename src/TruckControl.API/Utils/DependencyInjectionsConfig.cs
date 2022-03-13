using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using TruckControl.API.Data;
using TruckControl.API.Data.Repositories;

namespace TruckControl.API.Utils
{
    public static class DependencyInjectionsConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            //Context
            services.AddSingleton<Context>();

            //Repositories
            services.AddScoped<ITruckRegisterRepository, TruckRegisterRepository>();

            //Enums
            services
                .AddControllersWithViews()
                .AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            return services;
        }
    }
}
