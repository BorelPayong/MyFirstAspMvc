﻿using MyFirstAspMvc.Models;
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

            return RedirectToAction("Index", "Home", new { username = user.Name });
            
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                //Save data
                return RedirectToAction("Login");
            }
            else
            {
                return View(model);
            }
        }
    }
}