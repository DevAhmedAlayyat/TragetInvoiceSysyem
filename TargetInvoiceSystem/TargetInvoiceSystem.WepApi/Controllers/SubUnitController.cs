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
    public class SubUnitController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubUnitController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubUnits()
        {
            var mainUnits = await _unitOfWork.SubUnitService.GetAllAsync();
            return Ok(mainUnits);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubUnitById([FromRoute] Guid id)
        {
            var mainUnit = await _unitOfWork.SubUnitService.GetByIdAsync(id);
            if (mainUnit == null)
                return BadRequest("Not Found");
            return Ok(mainUnit);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubUnit([FromBody] SubUnitDto dto)
        {
            if (ModelState.IsValid)
            {
                var subUnit = _mapper.Map<SubUnitDto, SubUnit>(dto);
                await _unitOfWork.SubUnitService.InsertAsync(subUnit);
                await _unitOfWork.SaveChangesAsync();
                return Ok(dto);
            }
            return BadRequest("Some Fields Not Valid!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubUnit([FromRoute] Guid id, [FromBody] SubUnitDto dto)
        {
            if (ModelState.IsValid)
            {
                if (id != dto.Id)
                    return NotFound("Unit Not Found!");

                var subUnit = _mapper.Map<SubUnitDto, SubUnit>(dto);
                await _unitOfWork.SubUnitService.UpdateAsync(subUnit);
                await _unitOfWork.SaveChangesAsync();
                return Ok(dto);
            }
            return BadRequest("Some Fields Not Valid!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubUnit([FromRoute] Guid id)
        {
            var existUnit = await _unitOfWork.SubUnitService.GetByIdAsync(id);
            if(existUnit != null)
            {
                await _unitOfWork.SubUnitService.DeleteAsync(existUnit);
                await _unitOfWork.SaveChangesAsync();
                return Ok();
            }
            return BadRequest("Not Found!");
        }
    }
}
