using MyFirstAspMvc.service;
using MyFirstAspMvc.service.Entities;
using MyFirstAspMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstAspMvc.services
{
    public class Register
    {
        public RegisterCommand Command { get; private set; }

        public Register(RegisterCommand command)
        {
            Command = command;
        }

        public User Execute()
        {
            Sql sql = new Sql("SqlServer");
            var parmaters = new Sql.Parameter[]
            {
                new Sql.Parameter("@Id", DBNull.Value, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput),
                new Sql.Parameter("@Email", Command.Email, System.Data.DbType.String),
                new Sql.Parameter("@Name", Command.Name, System.Data.DbType.String),
                new Sql.Parameter("@CreateDate", Command.CreatedDate, System.Data.DbType.DateTime),
                new Sql.Parameter("@Status", Command.Status, System.Data.DbType.Boolean),
                new Sql.Parameter("@Role", Command.Role, System.Data.DbType.Int32),
                new Sql.Parameter("@Password", Command.Password, System.Data.DbType.String)
            }; 
            sql.Execute("Sp_User_Insert", parmaters, true);

            var id = int.Parse(parmaters[0].Value.ToString());

            var reader = sql.Read("Sp_User_Select", new Sql.Parameter[]
            {
                new Sql.Parameter("@Id", id, System.Data.DbType.Int32),
                new Sql.Parameter("@Email", DBNull.Value),
                new Sql.Parameter("@Name", DBNull.Value),
                new Sql.Parameter("@CreateDate", DBNull.Value),
                new Sql.Parameter("@Status", DBNull.Value),
                new Sql.Parameter("@Role", DBNull.Value),
                new Sql.Parameter("@Password", DBNull.Value)
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
                                        reader["Name"].ToString(),
                                        reader["Status"].ToString().ToLower() == "true" ? true : false,
                                        (User.RoleOptions)int.Parse(reader["Role"].ToString())
                                   );
                }
                reader.Close();
            }
            return null;
        } 
    }

    public class RegisterCommand
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public User.RoleOptions Role { get; set; }
        public string Password { get; set; }

        public RegisterCommand()
        {

        }

        public RegisterCommand(string email, string name, DateTime createdDate, bool status, User.RoleOptions role, string password)
        {
            Email = email;
            Name = name;
            CreatedDate = createdDate;
            Status = status;
            Role = role;
            Password = password;
        }
    }
}