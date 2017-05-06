﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Supermercado.E.Shop.Context;

namespace Supermercado.E.Shop.App.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (SupermercadoEShopDB db = new SupermercadoEShopDB())
            {
                return View(db.Product.ToList());
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect(FormsAuthentication.LoginUrl);
        }
    }
}