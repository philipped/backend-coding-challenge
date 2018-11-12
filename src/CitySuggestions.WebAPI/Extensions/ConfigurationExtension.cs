using CitySuggestions.Core.Interfaces;
using CitySuggestions.Core.Services;
using CitySuggestions.Infrastructure.Data.Geonames;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<IScoreService, ScoreService>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICityRepository, GeonamesJSONRepository>();
        }
    }
}
