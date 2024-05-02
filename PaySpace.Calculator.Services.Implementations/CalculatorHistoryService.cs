using PaySpace.Calculator.Domain.Entites;
using PaySpace.Calculator.Domain.Repositiores.Abstractions;
using PaySpace.Calculator.Services.Abstractions;
using PaySpace.Calculator.Shared.DTOs;

namespace PaySpace.Calculator.Services.Implementations
{
    //internal sealed class HistoryService(CalculatorContext context) : IHistoryService
    //{
    //    public async Task AddAsync(CalculatorHistory history)
    //    {
    //        history.Timestamp = DateTime.Now;

    //        await context.AddAsync(history);
    //        await context.SaveChangesAsync();
    //    }

    //    public Task<List<CalculatorHistory>> GetHistoryAsync()
    //    {
    //        return context.Set<CalculatorHistory>()
    //            .OrderByDescending(_ => _.Timestamp)
    //            .ToListAsync();
    //    }
    //}

    public class CalculatorHistoryService : BaseService<CalculatorHistoryDto, CalculatorHistory>, ICalculatorHistoryService
    {
        public CalculatorHistoryService(ICalculatorHistoryRepository repository) : base(repository)
        {

        }
    }
}