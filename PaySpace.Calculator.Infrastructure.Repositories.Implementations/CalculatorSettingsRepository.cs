using Microsoft.EntityFrameworkCore;
using PaySpace.Calculator.Domain.Entites;
using PaySpace.Calculator.Domain.Repositiores.Abstractions;
using PaySpace.Calculator.Infrastructure.DataAccess;
using PaySpace.Calculator.Shared.Enums;

namespace PaySpace.Calculator.Infrastructure.Repositories.Implementations
{
    public class CalculatorSettingsRepository : BaseRepository<CalculatorSetting>, ICalculatorSettingsRepository
    {
        private readonly CalculatorContext _calculatorContext;
        public CalculatorSettingsRepository(CalculatorContext calculatorContext) : base(calculatorContext)
        {
            _calculatorContext = calculatorContext;
        }
        public async Task<List<CalculatorSetting>?> GetCalculatorSettingsAsync(CalculatorType calcType)
        {
            return (await _calculatorContext.Set<CalculatorSetting>().Where(x => x.Calculator == calcType).ToListAsync());
        }
    }
}
