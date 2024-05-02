using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaySpace.Calculator.Domain.Repositiores.Abstractions;


namespace PaySpace.Calculator.Infrastructure.Repositories.Implementations
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICalculatorHistoryRepository, CalculatorHistoryRepository>();
            services.AddScoped<ICalculatorSettingsRepository, CalculatorSettingsRepository>();
            services.AddScoped<IPostalCodeRepository, PostalCodeRepository>();

        }


    }
}