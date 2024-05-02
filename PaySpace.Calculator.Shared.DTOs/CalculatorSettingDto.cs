using PaySpace.Calculator.Shared.Enums;

namespace PaySpace.Calculator.Shared.DTOs
{
    public class CalculatorSettingDto : BaseDto
    {
        public CalculatorType Calculator { get; set; }

        public RateType RateType { get; set; }

        public decimal Rate { get; set; }

        public decimal From { get; set; }

        public decimal? To { get; set; }
    }
}
