using PaySpace.Calculator.Domain.Entites;
using PaySpace.Calculator.Shared.Enums;
namespace PaySpace.Calculator.Domain.Repositiores.Abstractions
{
    public interface IPostalCodeRepository : IBaseRepository<PostalCode>
    {
        Task<CalculatorType?> GetCalculatorTypeAsync(string postalCode);
    }
}
