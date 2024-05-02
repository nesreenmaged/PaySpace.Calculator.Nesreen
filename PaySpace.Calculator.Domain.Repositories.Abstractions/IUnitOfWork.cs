using PaySpace.Calculator.Domain.Entites;


namespace PaySpace.Calculator.Domain.Repositiores.Abstractions
{
    public interface IUnitOfWork
    {
        IBaseRepository<CalculatorHistory> HistoryRepository { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
