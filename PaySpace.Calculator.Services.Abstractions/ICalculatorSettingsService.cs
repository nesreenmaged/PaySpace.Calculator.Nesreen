using PaySpace.Calculator.Domain.Entites;
using PaySpace.Calculator.Shared.DTOs;
using PaySpace.Calculator.Shared.Enums;

namespace PaySpace.Calculator.Services.Abstractions
{
    public interface ICalculatorSettingsService : IBaseService<CalculatorSettingDto, CalculatorSetting>
    {
        Task<List<CalculatorSettingDto>> GetCalculatorSettingsByTypeAsync(CalculatorType calculatorType);
    }
}