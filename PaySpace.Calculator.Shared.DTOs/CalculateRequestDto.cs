using PaySpace.Calculator.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySpace.Calculator.Shared.DTOs
{
    public class CalculateRequestDto
    {
        public string? PostalCode { get; set; }
        public decimal Income { get; set; }

    }
}
