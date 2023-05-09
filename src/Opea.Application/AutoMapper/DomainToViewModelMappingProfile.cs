using AutoMapper;
using Opea.Application.Commands;
using Opea.Application.ViewModels;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<CompanySize, CompanySizeViewModel>();

            CreateMap<Client, ClientViewModel>()              
                .ForMember(d => d.CompanySize, opt => opt.MapFrom(s => s.CompanySize))
                    .ForPath(d => d.CompanySize.Id, opt => opt.MapFrom(s => s.CompanySizeId))
                    .ForPath(d => d.CompanySize.Name, opt => opt.MapFrom(s => CompanySize.FromValue<CompanySize>(s.CompanySizeId).Name));

            CreateMap<Client, DeleteClientCommand>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.CompanyName, opt => opt.MapFrom(s => s.CompanyName))
                .ForMember(d => d.CompanySizeId, opt => opt.MapFrom(s => s.CompanySizeId));
        }
    }
}
