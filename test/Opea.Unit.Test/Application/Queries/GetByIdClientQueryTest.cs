﻿using Opea.Application.Queries;

namespace Opea.Unit.Test.Application.Queries
{
    public class GetByIdClientQueryTest
    {
        [Fact]
        public void GetByIdClientQuery()
        {
            var getByIdClientQuery = new Mock<GetByIdClientQuery>(1);

            Assert.NotNull(getByIdClientQuery);
        }
    }
}
