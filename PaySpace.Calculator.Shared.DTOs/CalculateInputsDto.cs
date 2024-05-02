using PaySpace.Calculator.Shared.Enums;

namespace PaySpace.Calculator.Shared.DTOs
{
    public sealed class CalculateInputsDto
    {
        public CalculatorType? Calculation { get; set; }
        public string? PostalCode { get; set; }
        public decimal Income { get; set; }
        public List<CalculatorSettingDto> CalculatorSettings { get; set; } = new List<CalculatorSettingDto>();
    }
}