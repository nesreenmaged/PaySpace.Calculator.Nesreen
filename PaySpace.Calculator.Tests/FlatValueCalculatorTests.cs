using NUnit.Framework;
using PaySpace.Calculator.Shared.DTOs;
using PaySpace.Calculator.Shared.Enums;

namespace PaySpace.Calculator.Tests
{
    [TestFixture]
    internal sealed class FlatValueCalculatorTests : BaseCalculatorTests
    {


        [TestCase(199999, 9999.95)]
        [TestCase(100, 5)]
        [TestCase(200000, 10000)]
        [TestCase(6000000, 10000)]
        public async Task Calculate_Should_Return_Expected_Tax(decimal income, decimal expectedTax)
        {
            //Arrange 
            var input = new CalculateRequestDto() { Income = income, Calculation = CalculatorType.FlatValue };

            // Act
            var result = await _calculatorService.Calculate(input);

            // Assert
            Assert.That(result.Tax == expectedTax, "Tax calculation is incorrect");
        }
    }
}