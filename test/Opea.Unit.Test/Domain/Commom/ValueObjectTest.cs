using Opea.Domain.Commom;

namespace Opea.Unit.Test.Domain.Commom
{
    public class ValueObjectTest
    {
        [Fact]
        public void EqualOperator()
        {
            var valueObject = new Mock<ValueObject>();

            Assert.NotNull(valueObject);
        }
    }
}
