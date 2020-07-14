using System.ComponentModel.DataAnnotations;

namespace TargetInvoiceSystem.WepApi.Dtos.Auth
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(4)]
        public string Password { get; set; }
    }
}
