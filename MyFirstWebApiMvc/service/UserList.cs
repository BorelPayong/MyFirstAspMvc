using MyFirstWebApiMvc.service.Entities;
using MyFirstWebApiMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstWebApiMvc.service
{
    public class UserList
    {
        public IEnumerable<User> Execute()
        {
            Sql sql = new Sql("SqlServer");
            var reader = sql.Read("Sp_User_Select", null, true);
            var list = new List<User>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    list.Add
                        (
                            new User(
                                        int.Parse(reader["id"].ToString()),
                                        reader["Email"].ToString(),
                                        reader["Password"].ToString(),
                                        reader["Name"].ToString(),
                                        reader["Status"].ToString().ToLower() == "true" ? true : false,
                                        (User.RoleOptions)int.Parse(reader["Role"].ToString())

                                    )
                        );
                }
                reader.Close();
            }
            return list;
        }
    }
}