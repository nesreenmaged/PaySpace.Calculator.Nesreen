using Mapster;
using Microsoft.Extensions.Caching.Memory;
using PaySpace.Calculator.Domain.Entites;
using PaySpace.Calculator.Domain.Repositiores.Abstractions;
using PaySpace.Calculator.Services.Abstractions;
using PaySpace.Calculator.Services.Implementations;
using PaySpace.Calculator.Shared.DTOs;
using PaySpace.Calculator.Shared.Enums;

namespace PaySpace.Calculator.Services
{
    public sealed class CalculatorSettingsService : BaseService<CalculatorSettingDto, CalculatorSetting>, ICalculatorSettingsService
    {
        private readonly ICalculatorSettingsRepository _repository;
        private readonly IMemoryCache _memoryCache;
        public CalculatorSettingsService(ICalculatorSettingsRepository repository, IMemoryCache memoryCache) : base(repository)
        {
            _repository = repository;
            _memoryCache = memoryCache;
        }

        public async Task<List<CalculatorSettingDto>> GetCalculatorSettingsByTypeAsync(CalculatorType calculatorType)
        {
            var settings = await _memoryCache.GetOrCreateAsync($"CalculatorSetting:{calculatorType}", async entry =>
            {
                return (await _repository.FindAsync(s => s.Calculator == calculatorType)).OrderBy(x => x.From).Adapt<List<CalculatorSettingDto>>();
            });
            return settings;
        }
    }
}

