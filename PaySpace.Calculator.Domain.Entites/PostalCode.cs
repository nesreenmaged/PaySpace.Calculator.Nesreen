using PaySpace.Calculator.Shared.Enums;

namespace PaySpace.Calculator.Domain.Entites
{
    public sealed class PostalCode : BaseEntity
    {

        public string? Code { get; set; }

        public CalculatorType Calculator { get; set; }
    }
}