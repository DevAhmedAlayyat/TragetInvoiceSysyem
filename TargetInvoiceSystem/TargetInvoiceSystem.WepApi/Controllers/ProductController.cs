using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TargetInvoiceSystem.Core.Entities;
using TargetInvoiceSystem.Core.ServicesInterfaces;
using TargetInvoiceSystem.WepApi.Dtos;

namespace TargetInvoiceSystem.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _unitOfWork.ProductService.GetAllProductsAsync();
            if (products.Count() == 0)
                return NotFound("Product Not Found!");
            var productsDto = _mapper.Map<ProductOutDto[]>(products);
            return Ok(productsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] Guid id)
        {
            var product = await _unitOfWork.ProductService.GetProductAsync(id);
            if (product == null)
                return NotFound("Product Not Found!");
            var productDto = _mapper.Map<ProductOutDto>(product);
            return Ok(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductInputDto dto) 
        {
            if (ModelState.IsValid)
            {
                var product = new ProductUnit
                {
                    Product = _mapper.Map<Product>(dto.ProductDto),
                    UnitId = dto.UnitDtoId,
                    BuyPrice = dto.BuyPrice,
                    SellPrice = dto.SellPrice
                };
                await _unitOfWork.ProductService.InsertAsync(product);
                await _unitOfWork.SaveChangesAsync();                
                return Ok(dto);
            }
            return BadRequest("Some Fields not Valid!");
        }
    }
}
