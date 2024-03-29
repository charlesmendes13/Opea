﻿using AutoMapper;
using Opea.Application.ViewModels;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Client, ClientViewModel>()              
                .ForMember(d => d.CompanySize, opt => opt.MapFrom(s => s.CompanySize))
                    .ForPath(d => d.CompanySize.Id, opt => opt.MapFrom(s => s.CompanySizeId))
                    .ForPath(d => d.CompanySize.Name, opt => opt.MapFrom(s => CompanySize.FromValue<CompanySize>(s.CompanySizeId).Name));

            CreateMap<CompanySize, CompanySizeViewModel>();
        }
    }
}
