
using Microsoft.Extensions.DependencyInjection;
using PaySpace.Calculator.Services.Abstractions;
using PaySpace.Calculator.Services.Abstractions.Calculators;
using PaySpace.Calculator.Services.Implementations.Calculators;

namespace PaySpace.Calculator.Services.Implementations
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCalculatorServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));
            services.AddScoped<IPostalCodeService, PostalCodeService>();
            services.AddScoped<ICalculatorHistoryService, CalculatorHistoryService>();
            services.AddScoped<ICalculatorSettingsService, CalculatorSettingsService>();

            services.AddScoped<ITaxCalculatorsMainService, TaxCalculatorsMainService>();
            services.AddScoped<ITaxFlatRateCalculatorService, TaxFlatRateCalculatorService>();
            services.AddScoped<ITaxFlatValueCalculatorService, TaxFlatValueCalculatorService>();
            services.AddScoped<ITaxProgressiveCalculatorService, TaxProgressiveCalculatorService>();
            services.AddMemoryCache();
        }
    }
}