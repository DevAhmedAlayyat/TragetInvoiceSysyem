using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TargetInvoiceSystem.Core.Entities;
using TargetInvoiceSystem.Core.ServicesInterfaces;
using TargetInvoiceSystem.WepApi.Dtos;

namespace TargetInvoiceSystem.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StockController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStockNames()
        {
            var stocks = await _unitOfWork.StockService.GetAllAsync();
            var stockDto = _mapper.Map<StockDto[]>(stocks);
            return Ok(stockDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStockName(Guid id)
        {
            var stock = await _unitOfWork.StockService.GetByIdAsync(id);
            if (stock == null)
                return NotFound("No Stock For That ID!");

            var stockDto = _mapper.Map<StockDto>(stock);
            return Ok(stockDto);
        }

        [HttpPost]
        public async Task<IActionResult> InsertStock([FromBody] StockDto dto)
        {
            var stock = _mapper.Map<Stock>(dto);
            await _unitOfWork.StockService.InsertAsync(stock);
            await _unitOfWork.SaveChangesAsync();
            dto.Id = stock.Id;
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> InsertStock([FromRoute] Guid id, [FromBody] StockDto dto)
        {
            if (ModelState.IsValid)
            {
                if (id != dto.Id)
                    return NotFound("Stock Not Found!");

                var stock = _mapper.Map<Stock>(dto);
                await _unitOfWork.StockService.UpdateAsync(stock);
                await _unitOfWork.SaveChangesAsync();
                return Ok(dto);
            }
            return BadRequest("Some Fields Not Valid!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStock([FromRoute] Guid id)
        {
            var stock = await _unitOfWork.StockService.GetByIdAsync(id);
            if (stock == null)
                return NotFound("Stock Not Found!");

            await _unitOfWork.StockService.DeleteAsync(stock);
            await _unitOfWork.SaveChangesAsync();

            return Ok("Deleted Successfult.");
        }
    }
}
