using System.ComponentModel.DataAnnotations;
using System;

namespace Credit
{
    public class CreditApplication
    {
        [Required]
        [Range(0.01, Double.PositiveInfinity)]
        public decimal RequiredAmount { get; set; }

        [Required]
        [Range(0.01, Double.PositiveInfinity)]
        public int RepaymentMonths { get; set; }

        [Required]
        [Range(0.00, Double.PositiveInfinity)]
        public decimal ExistingDebt { get; set; }
    }
}
