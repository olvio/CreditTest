using System.Threading.Tasks;

namespace Credit.Services
{
    public interface ICreditInquiryService
    {
        Task<(decimal,bool)> CreditInquiry(decimal requiredAmount, decimal existingDebt);
    }
}
