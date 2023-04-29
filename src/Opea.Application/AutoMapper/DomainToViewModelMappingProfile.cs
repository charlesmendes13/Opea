using AutoMapper;
using Opea.Application.ViewModels;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<CompanySize, CompanySizeViewModel>();
            CreateMap<Client, ClientViewModel>();
        }
    }
}
