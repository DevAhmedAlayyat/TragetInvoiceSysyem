using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using TargetInvoiceSystem.Core.Entities.Auth;
using TargetInvoiceSystem.Core.ServicesInterfaces;

namespace TargetInvoiceSystem.Infrastructure.Services
{
    public class AuthRegister : IAuthRegister
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthRegister(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AuthResponse> RegisterAsync(Register entity)
        {
            if (entity.Password != entity.ConfirmPassword)
                return new AuthResponse
                {
                    Message = "Confirm Password Miss Match!",
                    IsSuccess = false
                };

            var user = new IdentityUser
            {
                UserName = entity.Email,
                Email = entity.Email
            };

            var result = await _userManager.CreateAsync(user, entity.Password);

            if (result.Succeeded)
                return new AuthResponse
                {
                    Message = "User Created Successfuly.",
                    IsSuccess = true
                };

            return new AuthResponse
            {
                Message = "Some errors happened, user not created!",
                IsSuccess = false,
                Errors = result.Errors.Select(s => s.Description)
            };
        }
    }
}
