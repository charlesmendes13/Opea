using Opea.Application.Queries;

namespace Opea.Unit.Test.Application.Queries
{
    public class GetAllClientQueryTest
    {
        [Fact]
        public void GetAllClientQuery()
        {
            var getAllClientQuery = new Mock<GetAllClientQuery>();

            Assert.NotNull(getAllClientQuery.Object);
        }
    }
}
