using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstWebApiMvc.service.Entities
{
    public class User
    {
        public enum RoleOptions
        {
            Admin,
            Customer,
            Provider
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public RoleOptions Role { get; set; }

        public User()
        {

        }

        public User(int id, string email, string password, string name, bool status, RoleOptions role)
        {
            Id = id;
            Email = email;
            Password = password;
            Name = name;
            Status = status;
            Role = role;
        }
    }
}