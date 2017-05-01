using Supermercado.E.Shop.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Supermercado.E.Shop.Security;

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
            else
            {
                return View();
            }
        }
    }
}