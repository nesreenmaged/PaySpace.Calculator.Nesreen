using PaySpace.Calculator.Domain.Entites;
using PaySpace.Calculator.Shared.DTOs;
using PaySpace.Calculator.Shared.Enums;
namespace PaySpace.Calculator.Services.Abstractions
{
    public interface IPostalCodeService : IBaseService<PostalCodeDto, PostalCode>
    {
        Task<CalculatorType?> GetCalculatorTypeByPostalCodeAsync(string code);
        Task<List<PostalCodeDto>> GetPostalCodesAsync();
    }
}