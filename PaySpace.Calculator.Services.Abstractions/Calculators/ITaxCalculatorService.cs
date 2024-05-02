using PaySpace.Calculator.Shared.DTOs;

namespace PaySpace.Calculator.Services.Abstractions.Calculators
{
    // The Liskov Substitution Principle
    public interface ITaxCalculatorService
    {
        public CalculateResultDto Calculate(CalculateInputsDto calculateInputDto);
    }
}
