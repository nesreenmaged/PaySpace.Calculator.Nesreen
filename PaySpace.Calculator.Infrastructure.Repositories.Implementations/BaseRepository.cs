namespace PaySpace.Calculator.Infrastructure.Repositories.Implementations
{
    using Microsoft.EntityFrameworkCore;
    using PaySpace.Calculator.Domain.Entites;
    using PaySpace.Calculator.Domain.Repositiores.Abstractions;
    using PaySpace.Calculator.Infrastructure.DataAccess;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly CalculatorContext _calculatorContext;

        public BaseRepository(CalculatorContext calculatorContext)
        {
            _calculatorContext = calculatorContext;
        }

        public async Task AddAsync(T entity)
        {
            await _calculatorContext.Set<T>().AddAsync(entity);
            await _calculatorContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _calculatorContext.Set<T>().AddRangeAsync(entities);
            await _calculatorContext.SaveChangesAsync();
        }

        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _calculatorContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _calculatorContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _calculatorContext.Set<T>().FindAsync(id);
        }

        public void Remove(T entity)
        {
            _calculatorContext.Set<T>().Remove(entity);
            _calculatorContext.SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _calculatorContext.Set<T>().RemoveRange(entities);
            _calculatorContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _calculatorContext.Entry(entity).State = EntityState.Modified;
            _calculatorContext.SaveChanges();
        }
    }

}
