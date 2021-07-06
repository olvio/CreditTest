
namespace Credit
{
    public class CreditDecision
    {
        public int? InterestRate { get; set; } //probably should be decimal, but in the description table there are only ints
        public string Decision { get; set; }
    }
}
