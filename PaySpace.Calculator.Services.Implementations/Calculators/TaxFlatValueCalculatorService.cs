using PaySpace.Calculator.Services.Abstractions.Calculators;
using PaySpace.Calculator.Shared.DTOs;

namespace PaySpace.Calculator.Services.Implementations.Calculators
{
    public sealed class TaxFlatValueCalculatorService : TaxBaseCalculatorService, ITaxFlatValueCalculatorService
    {
        private const int MaxAmountToUseRate = 200000;
        private const int MaxTax = 10000;
        public CalculateResultDto Calculate(CalculateInputsDto calculateInputDto)
        {

            ValidateSettings(calculateInputDto.CalculatorSettings);
            var taxRate = GetEffectiveTaxRate(calculateInputDto.CalculatorSettings);
            var calculateResultDto = GetCalculateResult(calculateInputDto);

            if (calculateInputDto.Income < MaxAmountToUseRate)
            {
                // Apply flat rate tax calculation for incomes below the specified threshold
                calculateResultDto.Tax = calculateInputDto.Income * (taxRate / 100);
            }
            else
            {
                // Apply flat tax value for incomes above the specified threshold
                calculateResultDto.Tax = MaxTax;
            }

            return calculateResultDto;
        }
    }
}