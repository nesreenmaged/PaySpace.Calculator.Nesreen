using PaySpace.Calculator.Shared.DTOs;


namespace PaySpace.Calculator.Web.Services.Abstractions
{
    public interface ICalculatorHttpService
    {
        Task<List<PostalCodeDto>> GetPostalCodesAsync();

        Task<List<CalculatorHistoryDto>> GetHistoryAsync();

        Task<CalculateResultDto> CalculateTaxAsync(CalculateRequestDto calculationRequest);
    }
}