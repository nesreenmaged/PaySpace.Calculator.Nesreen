using Mapster;
using PaySpace.Calculator.Domain.Exceptions;
using PaySpace.Calculator.Services.Abstractions;
using PaySpace.Calculator.Services.Abstractions.Calculators;
using PaySpace.Calculator.Shared.DTOs;
using PaySpace.Calculator.Shared.Enums;
using System.ComponentModel.DataAnnotations;


namespace PaySpace.Calculator.Services.Implementations.Calculators
{
    public class TaxCalculatorsMainService : ITaxCalculatorsMainService
    {
        private readonly IPostalCodeService _postalCodeService;
        private readonly ICalculatorSettingsService _settingsService;
        private readonly Dictionary<CalculatorType, ITaxCalculatorService> _calculatorServicesDictionary;

        public TaxCalculatorsMainService(
            IPostalCodeService postalCodeRepository,
            ICalculatorSettingsService settingsRepository)
        {
            _postalCodeService = postalCodeRepository;
            _settingsService = settingsRepository;
            _calculatorServicesDictionary = new Dictionary<CalculatorType, ITaxCalculatorService>
        {
            {CalculatorType.Progressive,  new TaxProgressiveCalculatorService() },
            {CalculatorType.FlatValue,  new TaxFlatValueCalculatorService() },
            {CalculatorType.FlatRate,  new TaxFlatRateCalculatorService() }
         };

        }

        public async Task<CalculateResultDto> Calculate(CalculateRequestDto calculateRequest)
        {
            var calcInput = new CalculateInputsDto() { 
                Income= calculateRequest.Income,
                PostalCode= calculateRequest .PostalCode,
                Calculation= calculateRequest.Calculation
            };

            // 1-Validate the request
            ValidateRequest(calcInput);

            // 2-Get calc type from postal code if calculation is null
            var calculatorType = calcInput.Calculation ?? await GetCalculatorTypeFromPostalCode(calcInput.PostalCode);

            //3-Get rate settings based on calc type 
            var settings = await GetCalculatorSettings(calculatorType);

            //4- get calc service based on calc type
            var calculatorService = GetCalculatorService(calculatorType);
            calcInput.Calculation = calculatorType;
            calcInput.CalculatorSettings = settings;
            //5- calc taxes based on settings 
            return calculatorService.Calculate(calcInput);
        }
        #region Private Methods
        private void ValidateRequest(CalculateInputsDto request)
        {
            if (request == null || (string.IsNullOrWhiteSpace(request.PostalCode) &&
                !request.Calculation.HasValue))
                throw new EmptyPostalCodeException();
        }

        private async Task<CalculatorType> GetCalculatorTypeFromPostalCode(string postalCode)
        {
            var calculatorType = await _postalCodeService.GetCalculatorTypeByPostalCodeAsync(postalCode);
            if (!calculatorType.HasValue)
                throw new InvalidPostalCodeException();

            return calculatorType.Value;
        }

        private async Task<List<CalculatorSettingDto>> GetCalculatorSettings(CalculatorType calculatorType)
        {
            var settings = (await _settingsService.GetCalculatorSettingsByTypeAsync(calculatorType)).Adapt<List<CalculatorSettingDto>>();
            if (settings == null || settings.Count == 0)
                throw new NoCalcSettingsException();

            return settings;
        }

        private ITaxCalculatorService GetCalculatorService(CalculatorType type)
        {
            if (!_calculatorServicesDictionary.TryGetValue(type, out var service))
                throw new NoCalcSettingsException();

            return service;
        }
        #endregion
    }
}
