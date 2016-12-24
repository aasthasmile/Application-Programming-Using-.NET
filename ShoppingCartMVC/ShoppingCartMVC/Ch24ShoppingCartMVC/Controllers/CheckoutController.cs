using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ch24ShoppingCartMVC.Models;

namespace Ch24ShoppingCartMVC.Controllers
{
    public class CheckoutController : Controller
    {
        Checkoutmodel cart = new Checkoutmodel();
        // GET: /Checkout/

        public ActionResult Index()
        {
            CheckoutViewModel model = (CheckoutViewModel)TempData["cart"];
            if (model == null)
                model = cart.GetCart();
            return View(model);
        }

    }
}
