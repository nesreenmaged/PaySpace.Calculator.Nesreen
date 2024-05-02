using PaySpace.Calculator.Shared.DTOs;
using PaySpace.Calculator.Web.Services.Abstractions;
using System.Net.Http.Json;
namespace PaySpace.Calculator.Web.Services
{
    public class CalculatorHttpService : ICalculatorHttpService
    {

        private readonly HttpClient httpClient;

        public CalculatorHttpService(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient("PostalClient");
        }
        public async Task<List<PostalCodeDto>> GetPostalCodesAsync()
        {
            var response = await httpClient.GetAsync("api/calculator/posta1code");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Cannot fetch postal codes, status code: {response.StatusCode}");
            }

            return await response.Content.ReadFromJsonAsync<List<PostalCodeDto>>() ?? [];
        }

        public async Task<List<CalculatorHistoryDto>> GetHistoryAsync()
        {
            var response = await httpClient.GetAsync("api/calculator/history");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Cannot fetch history, status code: {response.StatusCode}");
            }

            return await response.Content.ReadFromJsonAsync<List<CalculatorHistoryDto>>() ?? [];

        }

        public async Task<CalculateResultDto> CalculateTaxAsync(CalculateRequestDto calculationRequest)
        {
            if (calculationRequest == null)
                throw new ArgumentNullException(nameof(calculationRequest), "Calculation request cannot be null.");

            var jsonContent = JsonContent.Create(calculationRequest);

            var response = await httpClient.PostAsync("api/calculator/calculate-tax", jsonContent);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Cannot Calculate , status code: {response.StatusCode}");
            }

            var result = await response.Content.ReadFromJsonAsync<CalculateResultDto>();
            if (result == null)
            {
                throw new InvalidOperationException("Failed to parse the response into CalculateResultDto.");
            }

            return result;
        }
    }
}