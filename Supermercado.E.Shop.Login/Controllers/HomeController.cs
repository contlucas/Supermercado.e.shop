using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Supermercado.E.Shop.Context;
using Supermercado.E.Shop.Security;

namespace Supermercado.E.Shop.Login.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (TempData["errorLogin"] != null)
            {
                ViewBag.ErrorMessage = TempData["errorLogin"];
                TempData["errorLogin"] = null;
            }

            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password, bool rememberme)
        {
            if (SecurityManagement.Authenticate(username, password))
            {
                return RedirectToAction("Logged");
            }
            else
            {
                TempData["errorLogin"] = "The username or password don't match";
                return RedirectToAction("Index");
            }
        }

        public ActionResult Logged()
        {
            return Content("Your token");
        }
    }
}