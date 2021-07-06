using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Credit.Repositories.Models;
using System.Linq;

namespace Credit.Repositories
{
    public class InterestRangeReporitory : Repository<InterestRange>, IInterestRangeRepository
    {
        public InterestRangeReporitory(CreditDefinitionsDemoContext creditDefinitionsDemoContext) : base(creditDefinitionsDemoContext)
        {
        }
        public Task<InterestRange> GetInterestRange(decimal amount)
        {
            return GetAll().Where(x => x.AmountFrom <= amount && amount < x.AmountTo).FirstOrDefaultAsync();
        }
    }
}
