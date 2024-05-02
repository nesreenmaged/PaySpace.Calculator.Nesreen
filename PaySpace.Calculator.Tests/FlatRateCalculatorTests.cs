using NUnit.Framework;
using PaySpace.Calculator.Shared.DTOs;
using PaySpace.Calculator.Shared.Enums;

namespace PaySpace.Calculator.Tests
{
    [TestFixture]
    internal sealed class FlatRateCalculatorTests : BaseCalculatorTests
    {

        [TestCase(999999, 174999.825)]
        [TestCase(1000, 175)]
        [TestCase(5, 0.875)]
        public async Task Calculate_Should_Return_Expected_Tax(decimal income, decimal expectedTax)
        {
            // Arrange
            var input = new CalculateRequestDto() { Income = income, Calculation = CalculatorType.FlatRate };
            // Act
            var result = await _calculatorService.Calculate(input);

            // Assert
            Assert.That(result.Tax == expectedTax, "Tax calculation is incorrect");
        }
    }
}
