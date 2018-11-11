using CitySuggestions.Core.Interfaces;
using CitySuggestions.Core.Services;
using CitySuggestions.Infrastructure.Data.Geonames;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitySuggestions.WebAPI.Extensions
{
    public static class ConfigurationExtension
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader()
                                      .AllowCredentials()

                );
            });
        }

        public static void ConfigureUseCases(this IServiceCollection services)
        {
            services.AddScoped<ISuggestionService, SuggestionService>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICityRepository, GeonamesRepository>();
        }
    }
}
