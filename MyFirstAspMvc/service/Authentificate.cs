using MyFirstAspMvc.service;
using MyFirstAspMvc.service.Entities;
using MyFirstAspMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstAspMvc.services
{
    public class Authentificate
    {
        public AuthentificateCommand Command { get; private set; }

        public Authentificate(AuthentificateCommand command)
        {
            Command = command;
        }

        public User Execute()
        {
            Sql sql = new Sql("SqlServer");
            var reader = sql.Read("Sp_Authentificate_User", new Sql.Parameter[]
                {
                    new Sql.Parameter("@Email", Command.Email, System.Data.DbType.String),
                    new Sql.Parameter("@Password", Command.Password, System.Data.DbType.String)
                }, 
                true);

            if (reader != null)
            {
                while (reader.Read())
                {
                    return new User(
                                        int.Parse(reader["id"].ToString()),
                                        reader["Email"].ToString(),
                                        reader["Password"].ToString(),
                                        reader["Name"].ToString()
                                   );
                }
                reader.Close();
            }
            return null;
        } 
    }

    public class AuthentificateCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public AuthentificateCommand()
        {

        }

        public AuthentificateCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}