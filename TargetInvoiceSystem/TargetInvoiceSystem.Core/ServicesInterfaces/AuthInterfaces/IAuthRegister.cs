using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TargetInvoiceSystem.Core.Entities.Auth;

namespace TargetInvoiceSystem.Core.ServicesInterfaces
{
    public interface IAuthRegister
    {
        Task<AuthResponse> RegisterAsync(Register entity);
    }
}
