using Opea.Application.Queries;

namespace Opea.Unit.Test.Application.Queries
{
    public class GetAllClientQueryTest
    {
        [Fact]
        public void GetAllClientQuery()
        {
            var getAllClientQuery = new GetAllClientQuery();

            Assert.NotNull(getAllClientQuery);
        }
    }
}
