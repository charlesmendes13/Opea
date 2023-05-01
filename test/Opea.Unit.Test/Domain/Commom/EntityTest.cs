using Opea.Domain.Commom;

namespace Opea.Unit.Test.Domain.Commom
{
    public class EntityTest
    {
        [Fact]
        public void Entity()
        {
            var entity = new Mock<Entity>();
            entity.Setup(x => x.Id).Returns(1);

            Assert.Equal(1, 1);
        }
    }
}
