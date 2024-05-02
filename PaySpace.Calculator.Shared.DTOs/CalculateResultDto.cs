using PaySpace.Calculator.Shared.Enums;

namespace PaySpace.Calculator.Shared.DTOs
{
    public sealed class CalculateResultDto : BaseDto
    {
        public CalculatorType Calculator { get; set; }

        public decimal Tax { get; set; }
    }
}