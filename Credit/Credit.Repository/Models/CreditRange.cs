using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Credit.Repositories.Models
{
    public partial class CreditRange
    {
        public long Id { get; set; }
        public decimal AmountFrom { get; set; }
        public decimal AmountTo { get; set; }
        public bool IsAvailable { get; set; }
    }
}
