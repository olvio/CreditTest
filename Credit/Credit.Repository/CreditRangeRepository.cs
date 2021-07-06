using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Credit.Repositories.Models;
using System.Linq;

namespace Credit.Repositories
{
    public class CreditRangeRepository : Repository<CreditRange>, ICreditRangeRepository
    {
        public CreditRangeRepository(CreditDefinitionsDemoContext creditDefinitionsDemoContext) : base(creditDefinitionsDemoContext)
        {
        }

        public Task<CreditRange> GetCreditRange(decimal amount)
        {
           return  GetAll().Where(x=>x.AmountFrom <= amount && amount < x.AmountTo).FirstOrDefaultAsync();
        }
    }
}
