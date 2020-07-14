using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TargetInvoiceSystem.Core.Entities;
using TargetInvoiceSystem.Core.ServicesInterfaces;
using TargetInvoiceSystem.WepApi.Dtos;

namespace TargetInvoiceSystem.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UnitController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUnits()
        {
            var units = await _unitOfWork.UnitService.GetAllUnitsAsync();
            var unitsDto = _mapper.Map<UnitOutputDto[]>(units);
            return Ok(unitsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllUnits([FromRoute] Guid id)
        {
            var units = await _unitOfWork.UnitService.GetSubUnitsForMainUnitByIdAsync(id);
            var unitsDto = _mapper.Map<UnitOutputDto[]>(units);
            return Ok(unitsDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUnit([FromBody] UnitInputDto dto)
        {
            if (ModelState.IsValid)
            {
                var unit = _mapper.Map<Unit>(dto);
                await _unitOfWork.UnitService.InsertAsync(unit);
                await _unitOfWork.SaveChangesAsync();
                return Ok(dto);
            }
            return BadRequest("Some Fields Not Valid");
        }
    }
}
