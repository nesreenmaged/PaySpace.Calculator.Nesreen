using PaySpace.Calculator.Shared.Enums;

namespace PaySpace.Calculator.Domain.Entites
{
    public sealed class CalculatorSetting : BaseEntity
    {
        public CalculatorType Calculator { get; set; }

        public RateType RateType { get; set; }

        public decimal Rate { get; set; }

        public decimal From { get; set; }

        public decimal? To { get; set; }
    }
}