﻿using Supermercado.E.Shop.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Supermercado.E.Shop.Security;
using Supermercado.E.Shop.Context;

namespace Supermercado.E.Shop.App.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (this.Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return Redirect(FormsAuthentication.GetRedirectUrl(User.Identity.Name, false));
                }

            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(UserModel model, string returnUrl)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    if (SecurityManagement.Authenticate(model.Username, model.Password))
                    {
                        FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);
                        if (this.Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        this.ModelState.AddModelError("", "Incorrect user name or password.");
                        return View(model);
                    }
                }
                catch (Exception ex)
                {
                    this.ModelState.AddModelError("", ex.Message);
                    return View(model);
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(UserRegisterModel model)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    using (SupermercadoEShopDB db = new SupermercadoEShopDB())
                    {
                        
                        var existUser = from u in db.User
                                        where u.Username.Equals(model.Username, StringComparison.CurrentCultureIgnoreCase) == true
                                        select u;

                        //The user exists so throws an exception
                        if (existUser.FirstOrDefault() != null)
                        {
                            throw new Exception("The username " + model.Username + " already exists");
                        }

                        Context.User user = new Context.User();
                        user.IDRol = (int)Security.Roles.Guest;
                        user.Username = model.Username;
                        user.Password = SecurityManagement.EncryptPassword(model.Password);
                        user.Email = model.Email;
                        user.CreatedDateTime = DateTime.Now;
                        user.State = "A";

                        db.User.Add(user);
                        db.SaveChanges();
                        return RedirectToAction("Login");
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}