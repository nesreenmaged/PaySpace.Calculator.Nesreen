using NUnit.Framework;
using PaySpace.Calculator.Shared.DTOs;
using PaySpace.Calculator.Shared.Enums;

namespace PaySpace.Calculator.Tests
{
    [TestFixture]
    internal sealed class ProgressiveCalculatorTests : BaseCalculatorTests
    {

        [TestCase(-1, 0)]
        [TestCase(50, 5)]
        [TestCase(8350.1, 835.01)]
        [TestCase(8351, 835)]
        [TestCase(33951, 4674.85)]
        [TestCase(82251, 16749.60)]
        [TestCase(171550, 41753.32)]
        [TestCase(999999, 327681.79)]
        public async Task Calculate_Should_Return_Expected_Tax(decimal income, decimal expectedTax)
        {
            // Arrange 
            var input = new CalculateRequestDto() { Income = income, Calculation = CalculatorType.Progressive };

            // Act
            var result = await _calculatorService.Calculate(input);

            // Assert
            Assert.That(result.Tax == expectedTax, "Tax calculation is incorrect");
        }
    }
}