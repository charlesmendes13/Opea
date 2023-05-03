using AutoMapper;
using Opea.Application.ViewModels;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Client, ClientViewModel>()
                .AfterMap((e, v) => v.CompanySizeName = CompanySize.FromValue<CompanySize>(e.CompanySizeId)?.Name);
        }
    }
}
