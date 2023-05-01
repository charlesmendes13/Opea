using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Unit.Test.Domain.AggragatesModel.ClientAggragate
{
    public class CompanySizeTest
    {
        [Fact]
        public void CompanySize()
        {
            var companySize = new Mock<CompanySize>(1, "Small");

            Assert.NotNull(companySize);
        }
    }
}
