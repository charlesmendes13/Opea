using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Unit.Test.Domain.AggragatesModel.ClientAggragate
{
    public class CompanySizeTest
    {
        [Fact]
        public void CompanySize()
        {
            var companySize = new CompanySize(3, "Google");

            Assert.NotNull(companySize);
        }
    }
}
