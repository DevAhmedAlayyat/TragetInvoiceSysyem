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
    public class PersonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {
            var persons = await _unitOfWork.PersonService.GetAllAsync();
            var personsDto = _mapper.Map<PersonDto[]>(persons);
            return Ok(personsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson([FromRoute] Guid id)
        {
            var person = await _unitOfWork.PersonService.GetByIdAsync(id);
            if (person == null)
                return NotFound("Person Not Found");
            var personDto = _mapper.Map<PersonDto>(person);
            return Ok(personDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] PersonDto dto)
        {
            if (ModelState.IsValid)
            {
                var person = _mapper.Map<Person>(dto);
                await _unitOfWork.PersonService.InsertAsync(person);
                await _unitOfWork.SaveChangesAsync();
                dto.Id = person.Id;
                return Ok(dto);
            }
            return BadRequest("Some Fields Not Valid.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson([FromRoute] Guid id, [FromBody] PersonDto dto)
        {
            if (id != dto.Id)
                return NotFound("No Person Found with that ID");
            if (ModelState.IsValid)
            {
                var person = _mapper.Map<Person>(dto);
                await _unitOfWork.PersonService.UpdateAsync(person);
                await _unitOfWork.SaveChangesAsync();
                return Ok(dto);
            }
            return BadRequest("Some Fields Not Valid");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson([FromRoute] Guid id)
        {
            var person = await _unitOfWork.PersonService.GetByIdAsync(id);
            if (person == null)
                return NotFound("Person Not Found");
            await _unitOfWork.PersonService.DeleteAsync(person);
            await _unitOfWork.SaveChangesAsync();
            return Ok("Person Deleted Successfuly.");
        }
    }
}
