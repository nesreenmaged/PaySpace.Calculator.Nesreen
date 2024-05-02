using PaySpace.Calculator.Shared.DTOs;

namespace PaySpace.Calculator.Services.Abstractions.Calculators
{
    public interface ITaxCalculatorsMainService
    {
        Task<CalculateResultDto> Calculate(CalculateRequestDto calculateRequest);
        Task<CalculateResultDto> Calculate(CalculateInputsDto calculateinput);
    }
}