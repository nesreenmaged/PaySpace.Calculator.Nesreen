using PaySpace.Calculator.Services.Abstractions.Calculators;
using PaySpace.Calculator.Shared.DTOs;

namespace PaySpace.Calculator.Services.Implementations.Calculators
{
    public sealed class TaxProgressiveCalculatorService : TaxBaseCalculatorService, ITaxProgressiveCalculatorService
    {
        public CalculateResultDto Calculate(CalculateInputsDto calculateInputDto)
        {
            ValidateSettings(calculateInputDto.CalculatorSettings);

            var calculateResultDto = GetCalculateResult(calculateInputDto);
            decimal tax = 0;
            foreach (var setting in calculateInputDto.CalculatorSettings)
            {
                if (!setting.To.HasValue)
                {
                    setting.To = decimal.MaxValue;
                }
                if (calculateInputDto.Income >= setting.From)
                {
                    decimal taxableAmount = 0;
                    // handle the case that the income is greater than "to" by less than 1
                    if (calculateInputDto.Income > setting.To
                        && calculateInputDto.Income < setting.To + 1)
                    {
                        taxableAmount = calculateInputDto.Income - setting.From;
                    }
                    else
                    {
                        decimal fromPart = calculateInputDto.Income - setting.From;
                        decimal maxPart = setting.To.Value - setting.From;
                        taxableAmount = Math.Min(fromPart, maxPart);
                    }
                    tax += taxableAmount * (setting.Rate / 100);

                    // To minimize the loop
                    if (calculateInputDto.Income <= setting.To)
                    {
                        break;
                    }
                }
            }
            calculateResultDto.Tax = tax;
            return calculateResultDto;
        }
    }
}