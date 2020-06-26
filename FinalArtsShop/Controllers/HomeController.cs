using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalArtsShop.Models;

namespace FinalArtsShop.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private const string ShoppingCartName = "ShoppingCartName";
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Index()
        {
            var keyChainCategory = db.Categories.Where(c => c.Abbreviation == "KC").FirstOrDefault();

            var products = db.Products.Where(p => p.CategoryID == keyChainCategory.Id).ToList();

            ViewBag["ShoppingCart"] = Session[ShoppingCartName];

            return View("~/Views/Home/Home.cshtml", products);
        }

        public ActionResult Product()
        {
            return View("~/Views/Home/Product.cshtml");
        }

        public ActionResult ProductDetail()
        {
            return View("~/Views/Home/ProductDetail.cshtml");
        }

        public ActionResult Cart()
        {
            return View("~/Views/Home/Cart.cshtml");
        }

        public ActionResult Checkout()
        {
            return View("~/Views/Home/Checkout.cshtml");
        }

        public ActionResult Account()
        {
            return View("~/Views/Home/Account.cshtml");
        }

        public ActionResult Contact()
        {
            return View("~/Views/Home/Contact.cshtml");
        }

        public ActionResult WishList()
        {
            return View("~/Views/Home/WishList.cshtml");
        }
    }
}