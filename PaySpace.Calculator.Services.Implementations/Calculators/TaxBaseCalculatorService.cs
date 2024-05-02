using PaySpace.Calculator.Shared.DTOs;
namespace PaySpace.Calculator.Services.Implementations.Calculators
{
    public class TaxBaseCalculatorService
    { /// <summary>
      /// Validates the settings list to ensure it is not null or empty.
      /// </summary>
      /// <param name="settings">The list of calculator settings.</param>
        protected void ValidateSettings(List<CalculatorSettingDto> settings)
        {
            if (settings == null || !settings.Any())
                throw new ArgumentException("Settings list cannot be null or empty.");
        }

        /// <summary>
        /// Retrieves the effective tax rate from the settings.
        /// </summary>
        /// <param name="settings">The list of calculator settings.</param>
        /// <returns>The effective tax rate.</returns>
        protected decimal GetEffectiveTaxRate(List<CalculatorSettingDto> settings)
        {
            return settings.FirstOrDefault()?.Rate ?? throw new InvalidOperationException("Tax rate is missing in the settings.");
        }
        /// <summary>
        /// GetCalculateResult
        /// </summary>
        /// <param name="calculateRequest"></param>
        /// <returns></returns>
        public CalculateResultDto GetCalculateResult(CalculateInputsDto calculateRequest)
        {
            var result = new CalculateResultDto();
            if (calculateRequest.Calculation.HasValue)
            {
                result.Calculator = calculateRequest.Calculation.Value;
            }
            return result;
        }
    }
}
