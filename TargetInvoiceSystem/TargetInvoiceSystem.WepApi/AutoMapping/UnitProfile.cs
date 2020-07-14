using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetInvoiceSystem.Core.Entities;
using TargetInvoiceSystem.WepApi.Dtos;

namespace TargetInvoiceSystem.WepApi.AutoMapping
{
    public class UnitProfile : Profile
    {
        public UnitProfile()
        {
            CreateMap<MainUnit, MainUnitDto>();
            CreateMap<MainUnitDto, MainUnit>();

            CreateMap<SubUnit, SubUnitDto>();
            CreateMap<SubUnitDto, SubUnit>();

            CreateMap<Unit, UnitOutputDto>()
                .ForMember(u => u.MainUnitName, opt => opt.MapFrom(ex => ex.MainUnit.Name))
                .ForMember(u => u.SubUnitName, opt => opt.MapFrom(ex => ex.SubUnit.Name));

            CreateMap<UnitInputDto, Unit>()
                .ForMember(u => u.MainUnit, opt => opt.MapFrom(uid => uid.MainUnitDto))
                .ForMember(u => u.SubUnit, opt => opt.MapFrom(uid => uid.SubUnitDto));
        }
    }
}
