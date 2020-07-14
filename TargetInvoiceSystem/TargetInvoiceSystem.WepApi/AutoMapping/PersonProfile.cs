using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetInvoiceSystem.Core.Entities;
using TargetInvoiceSystem.WepApi.Dtos;

namespace TargetInvoiceSystem.WepApi.AutoMapping
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();
        }
    }
}
