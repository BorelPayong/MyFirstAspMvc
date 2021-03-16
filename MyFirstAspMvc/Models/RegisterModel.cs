using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFirstAspMvc.Models
{
    public class RegisterModel : BaseModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }


        [Required]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }


        [Required]
        [StringLength(15, MinimumLength = 6)]
        public string Password { get; set; }


        //[Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public RegisterModel()
        {
        }

        public RegisterModel(string name, string email, string password, string confirmPassword)
        {
            Name = name;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }
    }
}