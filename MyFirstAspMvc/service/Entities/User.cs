using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstAspMvc.service.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public User()
        {

        }
         
        public User(int id, string email, string password, string name)
        {
            Id = id;
            Email = email;
            Password = password;
            Name = name;
        }
    }
}