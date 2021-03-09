using MyFirstAspMvc.Models;
using MyFirstAspMvc.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstAspMvc.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index(HomeModel model)
        {
            return View(model);
        }

        public ActionResult Login()
        {
            return View( );
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            Authentificate useCase = new Authentificate(new AuthentificateCommand(model.Email, model.Password));
            var user = useCase.Execute();

            if (user == null)
            {
                model.IsError = true;
                model.Message = "Email or password is invalide";
                return View(model);
            }

            return RedirectToAction("Index", "Home", new { username = user.Name });
            
        }
    }
}