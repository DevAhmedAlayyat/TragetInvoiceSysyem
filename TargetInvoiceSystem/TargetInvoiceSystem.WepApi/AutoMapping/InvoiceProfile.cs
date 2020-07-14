using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TargetInvoiceSystem.Core.Entities;
using TargetInvoiceSystem.WepApi.Dtos;

namespace TargetInvoiceSystem.WepApi.AutoMapping
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<InvoiceProduct, InvoiceProductDto>();
            CreateMap<InvoiceProductDto, InvoiceProduct>()
                .ForMember(ip => ip.ProductUnit, opt => opt.Ignore())
                .ForMember(ip => ip.Invoice, opt => opt.Ignore());

            CreateMap<Invoice, InvoiceOutputDto>()
                .ForMember(io => io.UserName, opt => opt.MapFrom(i => i.User.UserName))
                .ForMember(io => io.PersonName, opt => opt.MapFrom(i => i.Person.FullName))
                .ForMember(io => io.InvoiceProductOutputDtos, opt => opt.MapFrom(i => i.InvoiceProducts));

            CreateMap<InvoiceProduct, InvoiceProductOutputDto>()
                .ForMember(io => io.ProductName, opt => opt.MapFrom(ip => ip.ProductUnit.Product.Name))
                .ForMember(io => io.MainUnti, opt => opt.MapFrom(ip => ip.ProductUnit.Unit.MainUnit.Name))
                .ForMember(io => io.SubUnit, opt => opt.MapFrom(ip => ip.ProductUnit.Unit.SubUnit.Name))
                .ForMember(io => io.StockName, opt => opt.MapFrom(ip => ip.ProductUnit.Product.Stock.Name));

            CreateMap<Invoice, InvoiceInputDto>();
            CreateMap<InvoiceInputDto, Invoice>()
                .ForMember(ip => ip.User, opt => opt.Ignore())
                .ForMember(ip => ip.Person, opt => opt.Ignore());
        }
    }
}
