using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstAspMvc.Models
{
    public class RegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string ConfirmPassword { get; set; }
        public bool IsError { get; set; } = false;
        public string Message { get; set; } = string.Empty;
    }
}