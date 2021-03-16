using MyFirstAspMvc.Models;
using MyFirstAspMvc.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyFirstAspMvc.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index(HomeModel model)
        {
            return View(model);
        }

        public ActionResult Login(string returnUrl)
        {
            return View(new LoginModel { ReturnUrl = returnUrl});
        }

        public ActionResult Contrat()
        {
            return View();
        }

        public ActionResult RecupereMotDePasse()
        {
            return View();
        }

        /*[HttpPost]
        public ActionResult RecupereMotDePasse(ForgotModel models)
        {
            //envoyer mail à l'addresse indiqué (utilise votre smtp gmail)
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

            FormsAuthentication.SetAuthCookie(user.Email, false);
            var identity = (ClaimsIdentity)Thread.CurrentPrincipal.Identity;
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            Session[nameof(User)] = new RegisterModel
            (
                user.Email,
                user.Password,
                user.Password,
                user.Name
            );
            if (!string.IsNullOrEmpty(model.ReturnUrl))
                return Redirect(model.ReturnUrl);
            return RedirectToAction("Index", "Home");
            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session[nameof(User)] = null;
            return RedirectToAction("Index", "Home");
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