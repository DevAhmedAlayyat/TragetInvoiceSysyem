using System;
using System.Text;

namespace TargetInvoiceSystem.Core.Entities.Auth
{
    public class Register
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
