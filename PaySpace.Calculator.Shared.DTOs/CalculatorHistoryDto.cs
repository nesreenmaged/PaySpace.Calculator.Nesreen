namespace PaySpace.Calculator.Shared.DTOs
{
    public class CalculatorHistoryDto : BaseDto
    {
        public string PostalCode { get; set; }

        public DateTime Timestamp { get; set; }

        public decimal Income { get; set; }

        public decimal Tax { get; set; }

        public string Calculator { get; set; }
    }
}
