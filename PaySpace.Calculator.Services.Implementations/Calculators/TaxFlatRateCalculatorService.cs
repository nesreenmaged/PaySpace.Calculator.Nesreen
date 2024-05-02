using PaySpace.Calculator.Services.Abstractions.Calculators;
using PaySpace.Calculator.Shared.DTOs;
namespace PaySpace.Calculator.Services.Implementations.Calculators
{
    public sealed class TaxFlatRateCalculatorService : TaxBaseCalculatorService, ITaxFlatRateCalculatorService
    {
        /// <summary>
        /// Calculates tax based on a flat rate.
        /// </summary>
        /// <param name="annualIncome">The taxpayer's annual income.</param>
        /// <param name="calculatorSettingList">Settings which include the flat tax rate.</param>
        /// <returns>A <see cref="CalculateResultDto"/> containing the calculated tax.</returns>
        public CalculateResultDto Calculate(CalculateInputsDto calculateInputDto)
        {
            ValidateSettings(calculateInputDto?.CalculatorSettings);
            var taxRate = GetEffectiveTaxRate(calculateInputDto.CalculatorSettings);
            var calculateResultDto = GetCalculateResult(calculateInputDto);
            calculateResultDto.Tax = calculateInputDto.Income * (taxRate / 100);
            return calculateResultDto;
        }


    }

}