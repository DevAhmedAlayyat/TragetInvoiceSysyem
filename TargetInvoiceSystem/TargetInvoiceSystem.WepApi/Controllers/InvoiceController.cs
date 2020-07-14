using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TargetInvoiceSystem.Core.Entities;
using TargetInvoiceSystem.Core.ServicesInterfaces;
using TargetInvoiceSystem.WepApi.Dtos;

namespace TargetInvoiceSystem.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvoiceController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetInvoices()
        {
            var invoices = await _unitOfWork.InvoiceService.GetInvoicesAsync();
            if (invoices.Count() == 0)
                return NotFound();
            var invoicesDto = _mapper.Map<InvoiceOutputDto[]>(invoices);
            return Ok(invoicesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] Guid id)
        {
            var invoice = await _unitOfWork.InvoiceService.GetInvoiceAsync(id);
            if (invoice == null)
                return NotFound();
            var invoiceDto = _mapper.Map<InvoiceOutputDto>(invoice);
            return Ok(invoiceDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] InvoiceInputDto dto)
        {
            if (ModelState.IsValid)
            {
                var invoice = new Invoice
                {
                    InvoiceProducts = _mapper.Map<InvoiceProduct[]>(dto.InvoiceProducts),
                    UserId = dto.UserId,
                    PersonId = dto.PersonId,
                    Date = dto.Date,
                    Discount = dto.Discount,
                    NetPrice = dto.NetPrice,
                    TotalPrice = dto.TotalPrice,
                    TotalQty = dto.TotalQty
                };
                await _unitOfWork.InvoiceService.InsertAsync(invoice);
                await _unitOfWork.SaveChangesAsync();
                dto.Id = invoice.Id;
                return Ok(dto);
            }
            return BadRequest("Some Fields not Valid!");
        }
    }
}
