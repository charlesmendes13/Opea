using Opea.Domain.Commom;

namespace Opea.Unit.Test.Domain.Commom
{
    public class EnumerationTest
    {
        [Fact]
        public void Enumeration()
        {
            var enumeration = new Mock<Enumeration>();

            Assert.NotNull(enumeration);
        }
    }
}
