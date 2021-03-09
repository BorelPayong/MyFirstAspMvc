using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstAspMvc.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool IsError { get; set; } = false;
    }
}