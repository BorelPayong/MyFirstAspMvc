using MyFirstWebApiMvc.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFirstWebApiMvc.Controllers
{
    public class AccountController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var useCase = new UserList();
                var users = useCase.Execute();
                return Ok(users);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
