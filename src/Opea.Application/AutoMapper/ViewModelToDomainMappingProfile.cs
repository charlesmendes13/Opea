using AutoMapper;
using Opea.Application.Commands;
using Opea.Application.ViewModels;

namespace Opea.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClientViewModel, CreateClientCommand>()
                .ForMember(d => d.CompanyName, opt => opt.MapFrom(s => s.CompanyName))
                .ForMember(d => d.CompanySizeId, opt => opt.MapFrom(s => s.CompanySize.Id));

            CreateMap<ClientViewModel, UpdateClientCommand>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.CompanySize))
                .ForMember(d => d.CompanyName, opt => opt.MapFrom(s => s.CompanyName))
                .ForMember(d => d.CompanySizeId, opt => opt.MapFrom(s => s.CompanySize.Id));
        }
    }
}
