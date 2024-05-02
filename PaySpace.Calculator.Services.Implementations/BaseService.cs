using Mapster;
using PaySpace.Calculator.Domain.Entites;
using PaySpace.Calculator.Domain.Repositiores.Abstractions;
using PaySpace.Calculator.Services.Abstractions;
using PaySpace.Calculator.Shared.DTOs;
using System.Linq.Expressions;

namespace PaySpace.Calculator.Services.Implementations
{
    public class BaseService<TDTO, TEntity> : IBaseService<TDTO, TEntity>
    where TDTO : BaseDto
    where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task AddAsync(TDTO entity)
        {
            TEntity entityToAdd = entity.Adapt<TEntity>();
            await _baseRepository.AddAsync(entityToAdd);
        }

        public async Task AddRangeAsync(IEnumerable<TDTO> entities)
        {
            IEnumerable<TEntity> entitiesToAdd = entities.Adapt<IEnumerable<TEntity>>();
            await _baseRepository.AddRangeAsync(entitiesToAdd);
        }

        public async Task<List<TDTO>> FindAsync(Expression<Func<TDTO, bool>> predicate)
        {
            // You need to adjust this method to correctly map the predicate from TDTO to TEntity
            var entityPredicate = predicate.Adapt<Expression<Func<TEntity, bool>>>();
            var entities = await _baseRepository.FindAsync(entityPredicate);
            return entities.Adapt<List<TDTO>>();
        }

        public async Task<List<TDTO>> GetAllAsync()
        {
            var entities = await _baseRepository.GetAllAsync();
            return entities.Adapt<List<TDTO>>();
        }

        public async Task<TDTO> GetByIdAsync(int id)
        {
            var entity = await _baseRepository.GetByIdAsync(id);
            return entity.Adapt<TDTO>();
        }

        public void Remove(TDTO entity)
        {
            TEntity entityToRemove = entity.Adapt<TEntity>();
            _baseRepository.Remove(entityToRemove);
        }

        public void RemoveRange(IEnumerable<TDTO> entities)
        {
            IEnumerable<TEntity> entitiesToRemove = entities.Adapt<IEnumerable<TEntity>>();
            _baseRepository.RemoveRange(entitiesToRemove);
        }

        public void Update(TDTO entity)
        {
            TEntity entityToUpdate = entity.Adapt<TEntity>();
            _baseRepository.Update(entityToUpdate);
        }
    }
}
