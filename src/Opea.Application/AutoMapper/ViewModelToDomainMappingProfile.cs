using AutoMapper;
using Opea.Application.ViewModels;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CompanySizeViewModel, CompanySize>();
            CreateMap<ClientViewModel, Client>()
                .ForMember(d => d.CompanySize, opt => opt.MapFrom(s => s.CompanySize))
                    .ForPath(d => d.CompanySize.Id, opt => opt.MapFrom(s => s.CompanySize.Id))
                    .ForPath(d => d.CompanySize.Name, opt => opt.MapFrom(s => CompanySize.FromValue<CompanySize>(s.CompanySize.Id).Name));
        }
    }
}
