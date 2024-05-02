

using Mapster;
using Microsoft.Extensions.Caching.Memory;
using PaySpace.Calculator.Domain.Entites;
using PaySpace.Calculator.Domain.Repositiores.Abstractions;
using PaySpace.Calculator.Services.Abstractions;
using PaySpace.Calculator.Shared.DTOs;
using PaySpace.Calculator.Shared.Enums;

namespace PaySpace.Calculator.Services.Implementations
{
    public sealed class PostalCodeService : BaseService<PostalCodeDto, PostalCode>, IPostalCodeService
    {
        private readonly IPostalCodeRepository _repository;
        private readonly IMemoryCache _memoryCache;


        // The Dependency Inversion Principle
        public PostalCodeService(IPostalCodeRepository repository, IMemoryCache memoryCache) : base(repository)
        {
            _repository = repository;
            _memoryCache = memoryCache;
        }
        public async Task<List<PostalCodeDto>> GetPostalCodesAsync()
        {
            return await _memoryCache.GetOrCreateAsync("PostalCodes", async _ => (await _repository.GetAllAsync()).Adapt<List<PostalCodeDto>>())!;
        }
        public async Task<CalculatorType?> GetCalculatorTypeByPostalCodeAsync(string code)
        {
            return await _memoryCache.GetOrCreateAsync($"PostalCodes:{code}", async _ => await _repository.GetCalculatorTypeAsync(code))!;

        }
    }
}