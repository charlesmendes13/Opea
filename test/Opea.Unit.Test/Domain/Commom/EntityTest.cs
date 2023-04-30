using Opea.Domain.Commom;

namespace Opea.Unit.Test.Domain.Commom
{
    public class EntityTest
    {
        [Fact]
        public void Entity()
        {
            var entity = new Mock<Entity>()
            {
                CallBase = true
            };

            entity.Setup(x => x.Id).Returns(1);

            var id = 1;

            Assert.Equal(1, id);
        }
    }
}
