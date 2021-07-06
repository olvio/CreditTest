using System.Threading.Tasks;
using Credit.Repositories.Models;

namespace Credit.Repositories
{
    public interface ICreditRangeRepository :  IRepository<CreditRange>
    {
        Task<CreditRange> GetCreditRange(decimal amount);
    }
}
