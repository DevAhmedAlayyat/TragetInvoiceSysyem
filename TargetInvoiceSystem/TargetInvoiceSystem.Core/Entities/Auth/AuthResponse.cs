using System;
using System.Collections.Generic;

namespace TargetInvoiceSystem.Core.Entities.Auth
{
    public class AuthResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public string Token { get; set; }
        public DateTime? TokenExpireDate { get; set; }
    }
}
