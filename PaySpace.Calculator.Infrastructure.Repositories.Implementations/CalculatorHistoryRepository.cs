using PaySpace.Calculator.Domain.Entites;
using PaySpace.Calculator.Domain.Repositiores.Abstractions;
using PaySpace.Calculator.Infrastructure.DataAccess;


namespace PaySpace.Calculator.Infrastructure.Repositories.Implementations
{
    public class CalculatorHistoryRepository : BaseRepository<CalculatorHistory>, ICalculatorHistoryRepository
    {
        public CalculatorHistoryRepository(CalculatorContext calculatorContext) : base(calculatorContext)
        {
        }
    }
}
