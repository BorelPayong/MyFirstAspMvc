using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFirstAspMvc.Models
{
    public class RegisterModel
    {
        [Required]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 6)]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }


        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
        
        public bool IsError { get; set; } = false;
        public string Message { get; set; } = string.Empty;
    }
}