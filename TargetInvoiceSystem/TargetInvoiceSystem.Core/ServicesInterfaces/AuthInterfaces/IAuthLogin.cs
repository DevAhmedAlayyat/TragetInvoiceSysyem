using System.Threading.Tasks;
using TargetInvoiceSystem.Core.Entities.Auth;

namespace TargetInvoiceSystem.Core.ServicesInterfaces
{
    public interface IAuthLogin
    {
        Task<AuthResponse> LoginAsync(Login entity);
    }
}
