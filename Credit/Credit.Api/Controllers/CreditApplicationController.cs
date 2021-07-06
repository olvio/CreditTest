using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Credit.Services;

namespace Credit.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditApplicationController : ControllerBase
    {
        private readonly ICreditInquiryService _creditInquiryService;

        public CreditApplicationController(ICreditInquiryService creditInquiryService)
        {
            _creditInquiryService = creditInquiryService;
        }

        [HttpPost]
        public async Task<CreditDecision> Post(CreditApplication creditApplication)
        {
            var response = new CreditDecision {  Decision = "No", InterestRate = null};

                var result = await _creditInquiryService.CreditInquiry(creditApplication.RequiredAmount,creditApplication.ExistingDebt);

            //return a decision and interest rate. It means that return is espected only as yes/no and just a rate (not calculated monthly payments and totals)

            if (result.Item1 > 0 && result.Item2 == true)
            {
                response.Decision = "Yes";
                response.InterestRate = (int)result.Item1;
            }

            return response;

        }
    }
}
