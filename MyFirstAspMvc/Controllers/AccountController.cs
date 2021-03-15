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

        public ActionResult Contrat()
        {
            return View();
        }

        public ActionResult RecupereMotDePasse()
        {
            return View();
        }

        /*public ActionResult RecupereMotDePasse(ForgotModel models)
        {
            //envoyer un mail a l'adresse noter
            //le corps du mail doit contenir: un lien vers la page reset password
            //ecrire la logiaue de modifcation de mot de passe
        }*/
        public ActionResult Register()
        {
            return View();
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

            Session[nameof(User)] = user;

            return RedirectToAction("Index", "Home", new { username = user.Name });
            
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Register useCase = new Register
                (
                    new RegisterCommand
                    (
                        model.Email,
                        model.Name,
                        DateTime.Now,
                        true,
                        model.Password
                    )
                );
                var user = useCase.Execute();

                if (user == null)
                {
                    model.IsError = true;
                    model.Message = "An error occured please try again later";
                    return View(model);
                }
                return RedirectToAction("Login");
            }
            else
            {
                return View(model);
            }
        }
    }
}