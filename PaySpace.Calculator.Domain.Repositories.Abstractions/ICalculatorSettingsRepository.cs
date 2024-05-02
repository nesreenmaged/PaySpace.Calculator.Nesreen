using PaySpace.Calculator.Domain.Entites;
using PaySpace.Calculator.Shared.Enums;

namespace PaySpace.Calculator.Domain.Repositiores.Abstractions
{
    public interface ICalculatorSettingsRepository : IBaseRepository<CalculatorSetting>
    {
        Task<List<CalculatorSetting>?> GetCalculatorSettingsAsync(CalculatorType calcType);
    }
}
