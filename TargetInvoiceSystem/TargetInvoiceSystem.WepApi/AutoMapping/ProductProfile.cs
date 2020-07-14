using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetInvoiceSystem.Core.Entities;
using TargetInvoiceSystem.WepApi.Dtos;

namespace TargetInvoiceSystem.WepApi.AutoMapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Stock, StockDto>();
            CreateMap<StockDto, Stock>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>()
                .ForMember(p => p.StockId, opt => opt.MapFrom(pd => pd.StockDtoId));

            CreateMap<ProductUnit, ProductOutDto>()
                .ForMember(p => p.StockName, opt => opt.MapFrom(p => p.Product.Stock.Name))
                .ForMember(p => p.MainUnti, opt => opt.MapFrom(p => p.Unit.MainUnit.Name))
                .ForMember(p => p.SubUnit, opt => opt.MapFrom(p => p.Unit.SubUnit.Name))
                .ForMember(p => p.Balance, opt => opt.MapFrom(p => p.Product.Balance));

            //CreateMap<ProductUnit, ProductInputDto>()
            //    .ForMember(pid => pid.ProductDto, opt => opt.MapFrom(pu => pu.Product))
            //    .ForMember(pid => pid.UnitDtoId, opt => opt.MapFrom(pu => pu.UnitId));

            //CreateMap<ProductInputDto, ProductUnit>();
        }
    }
}
