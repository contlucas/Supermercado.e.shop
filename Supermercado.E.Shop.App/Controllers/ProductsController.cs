using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Supermercado.E.Shop.Context;

namespace Supermercado.E.Shop.App.Controllers
{
    [AllowAnonymous]
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            using (SupermercadoEShopDB db = new SupermercadoEShopDB())
            {
                return View(db.Product.ToList());
            }

        }
    }
}