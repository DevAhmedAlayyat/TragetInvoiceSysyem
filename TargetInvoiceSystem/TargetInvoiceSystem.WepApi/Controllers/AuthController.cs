using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TargetInvoiceSystem.Core.Entities.Auth;
using TargetInvoiceSystem.Core.ServicesInterfaces;
using TargetInvoiceSystem.WepApi.Dtos.Auth;

namespace TargetInvoiceSystem.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AuthController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                var register = _mapper.Map<RegisterDto,Register>(registerDto);
                var response = await _unitOfWork.AuthRegister.RegisterAsync(register);
                if(response.IsSuccess)
                    return Ok(response);
                return BadRequest(response);
            }
            return BadRequest("Some Properties Not Valid!");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var login = _mapper.Map<LoginDto, Login>(loginDto);
                var response = await _unitOfWork.AuthLogin.LoginAsync(login);
                if (response.IsSuccess)
                    return Ok(response);
                return BadRequest(response);
            }
            return BadRequest("Some Properties Not Valid!");
        }
    }
}
