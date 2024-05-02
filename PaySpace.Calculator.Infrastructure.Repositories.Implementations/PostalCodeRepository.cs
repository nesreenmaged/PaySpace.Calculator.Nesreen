using Microsoft.EntityFrameworkCore;
using PaySpace.Calculator.Domain.Entites;
using PaySpace.Calculator.Domain.Repositiores.Abstractions;
using PaySpace.Calculator.Infrastructure.DataAccess;
using PaySpace.Calculator.Shared.Enums;

namespace PaySpace.Calculator.Infrastructure.Repositories.Implementations
{
    public class PostalCodeRepository : BaseRepository<PostalCode>, IPostalCodeRepository
    {
        public readonly CalculatorContext _calculatorContext;
        public PostalCodeRepository(CalculatorContext calculatorContext) : base(calculatorContext)
        {
            _calculatorContext = calculatorContext;
        }

        public async Task<CalculatorType?> GetCalculatorTypeAsync(string postalCode)
        {
            return (await _calculatorContext.Set<PostalCode>().Where(x => x.Code == postalCode).FirstOrDefaultAsync())?.Calculator;
        }
    }
}
