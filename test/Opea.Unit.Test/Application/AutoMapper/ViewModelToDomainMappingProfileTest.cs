using AutoMapper;
using Opea.Application.AutoMapper;
using Opea.Application.Commands;
using Opea.Application.ViewModels;

namespace Opea.Unit.Test.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfileTest
    {
        [Fact]
        public void CreateClientCommand()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ViewModelToDomainMappingProfile>());
            var mapper = config.CreateMapper();

            var request = new ClientViewModel()
            {
                CompanyName = "Google",
                CompanySize = new CompanySizeViewModel()
                {
                    Id = 3,
                    Name = "Grande"
                }
            };

            var result = mapper.Map<ClientViewModel, CreateClientCommand>(request);

            Assert.NotNull(result);
        }

        [Fact]
        public void UpdateClientCommand()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ViewModelToDomainMappingProfile>());
            var mapper = config.CreateMapper();

            var request = new ClientViewModel()
            {
                Id = 1,
                CompanyName = "Google",
                CompanySize = new CompanySizeViewModel()
                {
                    Id = 3,
                    Name = "Grande"
                }
            };

            var result = mapper.Map<ClientViewModel, UpdateClientCommand>(request);

            Assert.NotNull(result);
        }
    }
}
