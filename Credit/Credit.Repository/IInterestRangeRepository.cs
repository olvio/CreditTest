using System.Threading.Tasks;
using Credit.Repositories.Models;

namespace Credit.Repositories
{
    public interface IInterestRangeRepository :  IRepository<InterestRange>
    {
        Task<InterestRange> GetInterestRange(decimal amount);
    }
}
