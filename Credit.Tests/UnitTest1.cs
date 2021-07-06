using NUnit.Framework;
using Moq;
using Credit.Services;

namespace Credit.Tests
{
    public class Tests
    {
        [Test]
        public void ShouldReturnFalseWithNullValues()
        {
            var service = new CreditInquiryService(new Repositories.InterestRangeReporitory(new Repositories.Models.CreditDefinitionsDemoContext()), new Repositories.CreditRangeRepository(new Repositories.Models.CreditDefinitionsDemoContext()));
            var result =  service.DetermineResult(null, null);
            Assert.AreEqual(false, result.Item2);
        }

        [Test]
        public void ShouldReturnFalseWithNullCreditRange()
        {
            var service = new CreditInquiryService(new Repositories.InterestRangeReporitory(new Repositories.Models.CreditDefinitionsDemoContext()), new Repositories.CreditRangeRepository(new Repositories.Models.CreditDefinitionsDemoContext()));
            var result = service.DetermineResult(null, new Repositories.Models.InterestRange {  AmountFrom = 2000, AmountTo = 10000, InterestRate = 3});
            Assert.AreEqual(false, result.Item2);
        }

        [Test]
        public void ShouldReturnFalseWithNullInterestRate()
        {
            var service = new CreditInquiryService(new Repositories.InterestRangeReporitory(new Repositories.Models.CreditDefinitionsDemoContext()), new Repositories.CreditRangeRepository(new Repositories.Models.CreditDefinitionsDemoContext()));
            var result = service.DetermineResult(new Repositories.Models.CreditRange {   AmountFrom = 1000, AmountTo = 5000, IsAvailable = true }, null);
            Assert.AreEqual(false, result.Item2);
        }
    }
}