using System.Linq;
using Credit.Repositories.Models;

namespace Credit
{
    public static class DbInitializer
    {
        public static void Initialize(CreditDefinitionsDemoContext context)
        {
            context.Database.EnsureCreated();

            if (context.CreditRanges.Any())
            {
                return;   // DB has been seeded
            }

            var creditranges = new CreditRange[]
            {
                new CreditRange { Id = 1, AmountFrom = 0, AmountTo = 2000, IsAvailable = false },
                new CreditRange { Id = 2, AmountFrom = 2000, AmountTo = 69000, IsAvailable = true },
                new CreditRange { Id = 3, AmountFrom = 69000m, AmountTo = 1000000000, IsAvailable = false } // this should be discussed, but unlikely someone with such amount of money would ask for some credit via API request

            };

            foreach (var cr in creditranges)
            {
                context.CreditRanges.Add(cr);
            }

            context.SaveChanges();

            var interestRanges = new InterestRange[]
            {
                new InterestRange { Id = 1, AmountFrom = 2000, AmountTo = 19999.99m, InterestRate = 3},
                new InterestRange { Id = 2, AmountFrom = 20000,  AmountTo = 39000m, InterestRate = 4},
                new InterestRange { Id = 3, AmountFrom = 40000, AmountTo = 59000, InterestRate = 5 },
                new InterestRange { Id = 4, AmountFrom = 60000, AmountTo = 1000000000, InterestRate = 7 } // this should be discussed, but unlikely someone with such amount of money would ask for some credit via API request
  
            };

            foreach (var ir in interestRanges)
            {
                context.InterestRanges.Add(ir);
            }
            context.SaveChanges();
        }
    }
}
