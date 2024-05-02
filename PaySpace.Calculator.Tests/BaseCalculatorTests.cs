using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PaySpace.Calculator.Infrastructure.DataAccess;
using PaySpace.Calculator.Infrastructure.Repositories.Implementations;
using PaySpace.Calculator.Services;
using PaySpace.Calculator.Services.Abstractions;
using PaySpace.Calculator.Services.Abstractions.Calculators;
using PaySpace.Calculator.Services.Implementations;
using PaySpace.Calculator.Services.Implementations.Calculators;

namespace PaySpace.Calculator.Tests
{
    public class BaseCalculatorTests
    {
        protected ITaxCalculatorsMainService _calculatorService;
        protected ICalculatorSettingsService _calculatorSettingsService;
        protected IPostalCodeService _postalCodeService;
        protected CalculatorContext _context;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // Configure in-memory database context
            var options = new DbContextOptionsBuilder<CalculatorContext>()
             .UseInMemoryDatabase(databaseName: "TestDatabase")
             .Options;

            _context = new CalculatorContext(options);
            _context.AddRange(CalculatorContext.GetCalculatorSettings());
            _context.SaveChanges();
            var memorycache = new FakeMemoryCache();
            var calculatorSettingsRepo = new CalculatorSettingsRepository(_context);
            _calculatorSettingsService = new CalculatorSettingsService(calculatorSettingsRepo, memorycache);

            var postalCodeRepo = new PostalCodeRepository(_context);
            _postalCodeService = new PostalCodeService(postalCodeRepo, memorycache);
            _calculatorService = new TaxCalculatorsMainService(_postalCodeService, _calculatorSettingsService);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Dispose the in-memory database
            _context.Database.EnsureDeleted();  // Deletes the in-memory database
            _context.Dispose();  // Properly dispose the context to free up resources
        }
    }
}
