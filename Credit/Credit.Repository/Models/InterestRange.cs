using System;
using System.Collections.Generic;

namespace Credit.Repositories.Models
{
    public partial class InterestRange
    {
        public long Id { get; set; }
        public decimal AmountFrom { get; set; }
        public decimal AmountTo { get; set; }
        public decimal InterestRate { get; set; }
    }
}
