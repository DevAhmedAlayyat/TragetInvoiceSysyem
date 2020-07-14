using System;
using System.Collections.Generic;
using System.Data;
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
    public class MainUnitController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MainUnitController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMainUnits()
        {
            var mainUnits = await _unitOfWork.MainUnitService.GetAllAsync();
            return Ok(mainUnits);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMainUnitById([FromRoute] Guid id)
        {
            var mainUnit = await _unitOfWork.MainUnitService.GetByIdAsync(id);
            if (mainUnit == null)
                return BadRequest("Not Found");
            return Ok(mainUnit);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMainUnit([FromBody] MainUnitDto dto)
        {
            if (ModelState.IsValid)
            {
                var mainUnit = _mapper.Map<MainUnitDto, MainUnit>(dto);
                await _unitOfWork.MainUnitService.InsertAsync(mainUnit);
                await _unitOfWork.SaveChangesAsync();
                return Ok(dto);
            }
            return BadRequest("Some Fields Not Valid!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMainUnit([FromRoute] Guid id, [FromBody] MainUnitDto dto)
        {
            if (ModelState.IsValid)
            {
                if (id != dto.Id)
                    return NotFound("Unit Not Found!");

                var mainUnit = _mapper.Map<MainUnitDto, MainUnit>(dto);
                await _unitOfWork.MainUnitService.UpdateAsync(mainUnit);
                await _unitOfWork.SaveChangesAsync();
                return Ok(dto);
            }
            return BadRequest("Some Fields Not Valid!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMainUnit([FromRoute] Guid id)
        {
            var existUnit = await _unitOfWork.MainUnitService.GetByIdAsync(id);
            if(existUnit != null)
            {
                await _unitOfWork.MainUnitService.DeleteAsync(existUnit);
                await _unitOfWork.SaveChangesAsync();
                return Ok();
            }
            return BadRequest("Not Found!");
        }
    }
}
