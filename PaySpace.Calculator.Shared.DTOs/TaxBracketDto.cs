namespace PaySpace.Calculator.Shared.DTOs
{
    public class TaxBracketDto
    {
        public decimal From { get; set; }
        public decimal To { get; set; }
        public decimal Rate { get; set; }

        public TaxBracketDto(decimal from, decimal to, decimal rate)
        {
            From = from;
            To = to;
            Rate = rate;
        }
    }
}
