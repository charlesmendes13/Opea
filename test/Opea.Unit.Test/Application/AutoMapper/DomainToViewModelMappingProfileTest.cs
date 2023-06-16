using AutoMapper;
using Opea.Application.AutoMapper;
using Opea.Application.ViewModels;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Unit.Test.Application.AutoMapper
{
    public class DomainToViewModelMappingProfileTest
    {
        [Fact]
        public void ClientViewModel()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<DomainToViewModelMappingProfile>());
            var mapper = config.CreateMapper();

            var client = new Mock<Client>("Google", 3);         

            var result = mapper.Map<Client, ClientViewModel>(client.Object);

            Assert.NotNull(result);
        }

        [Fact]
        public void CompanySizeViewModel()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<DomainToViewModelMappingProfile>());
            var mapper = config.CreateMapper();

            var client = new Mock<CompanySize>(3, "Grande");

            var result = mapper.Map<CompanySize, CompanySizeViewModel>(client.Object);

            Assert.NotNull(result);
        }
    }
}
