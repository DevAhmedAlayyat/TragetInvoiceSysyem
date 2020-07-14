using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TargetInvoiceSystem.Core.Entities.Auth;
using TargetInvoiceSystem.Core.ServicesInterfaces;

namespace TargetInvoiceSystem.Infrastructure.Services
{
    public class AuthLogin : IAuthLogin
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthLogin(IConfiguration configuration, 
                         UserManager<IdentityUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }
        public async Task<AuthResponse> LoginAsync(Login entity)
        {
            var user = await _userManager.FindByEmailAsync(entity.Email);
            if (user == null)
                return new AuthResponse
                {
                    Message = "Invalid Email!",
                    IsSuccess = false
                };           
            var passCheck = await _userManager.CheckPasswordAsync(user, entity.Password);
            if (!passCheck)
                return new AuthResponse
                {
                    Message = "Invalid Password!",
                    IsSuccess = false
                };

            var userRoles = await _userManager.GetRolesAsync(user);

            IdentityResult result;

            if (userRoles.Count == 0)
            {
                result = await _userManager.AddToRoleAsync(user, "Cashier");
                if (result.Succeeded)
                    userRoles = await _userManager.GetRolesAsync(user);
            }

            var userClaims = new[]
            {
                new Claim("UserName", user.Email),
                new Claim("UserId", user.Id),
                new Claim("UserRole", userRoles[0])
            };

            var encryptionKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken
            (
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(encryptionKey, SecurityAlgorithms.HmacSha256)
            );

            var tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new AuthResponse
            {
                Message = "",
                IsSuccess = true,
                Token = tokenAsString,
                TokenExpireDate = token.ValidTo
            };
        }
    }
}
