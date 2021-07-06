using System.Threading.Tasks;
using Credit.Repositories;
using Credit.Repositories.Models;

namespace Credit.Services
{
    public class CreditInquiryService : ICreditInquiryService
    {
        private readonly IInterestRangeRepository _interestRangeRepository;
        private readonly ICreditRangeRepository _creditRangeRepository;

        public CreditInquiryService(IInterestRangeRepository interestRangeRepository, ICreditRangeRepository creditRangeRepository)
        {
            _interestRangeRepository = interestRangeRepository;
            _creditRangeRepository = creditRangeRepository;
        }

        public async Task<(decimal, bool)> CreditInquiry(decimal requiredAmount, decimal existingDebt)
        {
           
            var creditAvailibility = await _creditRangeRepository.GetCreditRange(requiredAmount);
            var interestRate = await _interestRangeRepository.GetInterestRange(requiredAmount + existingDebt);

            return DetermineResult(creditAvailibility, interestRate);
        }

        public (decimal, bool) DetermineResult(CreditRange creditRange, InterestRange interestRange)
        {
            (decimal, bool) result = (0, false);
            if (creditRange?.IsAvailable == true)
            {
                if (interestRange != null)
                {
                    result.Item1 = interestRange.InterestRate;
                    result.Item2 = creditRange.IsAvailable;
                }
            }

            return result;
        }
    }
}
