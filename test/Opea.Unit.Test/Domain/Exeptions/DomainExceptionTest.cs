using Opea.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opea.Unit.Test.Domain.Exeptions
{
    public class DomainExceptionTest
    {
        [Fact]
        public void DomainException()
        {
            var domainException = new DomainException();

            Assert.NotNull(domainException);
        }

        [Fact]
        public void DomainExceptionCompanyName()
        {
            var domainException = new DomainException("O Nome da Empresa não pode ser nulo ou vazio");

            Assert.NotNull(domainException);
        }

        [Fact]
        public void DomainExceptionCompanyNameError()
        {
            var domainException = new DomainException("O Nome da Empresa não pode ser nulo ou vazio", new Exception());

            Assert.NotNull(domainException);
        }
    }
}
