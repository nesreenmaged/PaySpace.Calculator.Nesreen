using PaySpace.Calculator.Shared.DTOs;
using System.Linq.Expressions;

namespace PaySpace.Calculator.Services.Abstractions
{
    public interface IBaseService<TDTO, TEntity> where TDTO : BaseDto
    {
        Task<TDTO> GetByIdAsync(int id);
        Task<List<TDTO>> GetAllAsync();
        Task<List<TDTO>> FindAsync(Expression<Func<TDTO, bool>> predicate);
        Task AddAsync(TDTO entity);
        Task AddRangeAsync(IEnumerable<TDTO> entities);
        void Update(TDTO entity);
        void Remove(TDTO entity);
        void RemoveRange(IEnumerable<TDTO> entities);
    }
}
