using Opea.Domain.Exceptions;

namespace Opea.Unit.Test.Domain.Exeptions
{
    public class DomainExceptionTest
    {
        [Fact]
        public void DomainException()
        {
            var domainException = new Mock<DomainException>();

            Assert.NotNull(domainException.Object);
        }

        [Fact]
        public void DomainExceptionCompanyName()
        {
            var domainException = new Mock<DomainException>("O Nome da Empresa não pode ser nulo ou vazio");

            Assert.NotNull(domainException.Object);
        }

        [Fact]
        public void DomainExceptionCompanyNameError()
        {
            var domainException = new Mock<DomainException>("O Nome da Empresa não pode ser nulo ou vazio", new Exception());

            Assert.NotNull(domainException.Object);
        }
    }
}
