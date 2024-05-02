using PaySpace.Calculator.Shared.Enums;

namespace PaySpace.Calculator.Domain.Entites
{
    public sealed class CalculatorHistory : BaseEntity
    {
        public string? PostalCode { get; set; }

        public DateTime Timestamp { get; set; }

        public decimal Income { get; set; }

        public decimal Tax { get; set; }

        public CalculatorType Calculator { get; set; }
    }
}