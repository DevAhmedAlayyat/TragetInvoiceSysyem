using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetInvoiceSystem.Core.Entities.Auth;
using TargetInvoiceSystem.WepApi.Dtos.Auth;

namespace TargetInvoiceSystem.WepApi.AutoMapping
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            // Register
            CreateMap<Register, RegisterDto>();
            CreateMap<RegisterDto, Register>();

            // Login
            CreateMap<Login, LoginDto>();
            CreateMap<LoginDto, Login>();
        }
    }
}
