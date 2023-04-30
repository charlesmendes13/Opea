using AutoMapper;
using Opea.Application.AutoMapper;
using Opea.Application.ViewModels;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Unit.Test.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfileTest
    {
        [Fact]
        public void ClientViewModel()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ViewModelToDomainMappingProfile>());
            var mapper = config.CreateMapper();

            var request = new ClientViewModel()
            {
                Id = 1,
                CompanyName = "Google",
                CompanySize = new CompanySizeViewModel()
                {
                    Id = 3
                }
            };

            var result = mapper.Map<ClientViewModel, Client>(request);

            Assert.NotNull(result);
        }

        [Fact]
        public void CompanySizeViewModel()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ViewModelToDomainMappingProfile>());
            var mapper = config.CreateMapper();

            var request = new CompanySizeViewModel()
            {
                Id = 1
            };

            var result = mapper.Map<CompanySizeViewModel, CompanySize>(request);

            Assert.NotNull(result);
        }
    }
}
