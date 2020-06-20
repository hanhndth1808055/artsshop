using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalArtsShop.Controllers
{
    public class TestThemeController : Controller
    {
        // GET: TestTheme
        public ActionResult IndexBackend()
        {
            return View("~/Views/Backend/Dashbroad.cshtml");
        }

        public ActionResult DemoForm()
        {
            return View("~/Views/Backend/DemoForm2.cshtml");
        }

        public ActionResult DemoDatatable()
        {
            return View("~/Views/Backend/DemoDatatable.cshtml");
        }

        public ActionResult IndexFrontend()
        {
            return View("~/Views/Frontend/Home.cshtml");
        }

        public ActionResult ProductFrontend()
        {
            return View("~/Views/Frontend/Product.cshtml");
        }

        public ActionResult ProductDetailFrontend()
        {
            return View("~/Views/Frontend/ProductDetail.cshtml");
        }

        public ActionResult CartFrontend()
        {
            return View("~/Views/Frontend/Cart.cshtml");
        }

        public ActionResult CheckoutFrontend()
        {
            return View("~/Views/Frontend/Checkout.cshtml");
        }

        public ActionResult AccountFrontend()
        {
            return View("~/Views/Frontend/Account.cshtml");
        }

        public ActionResult ContactFrontend()
        {
            return View("~/Views/Frontend/Contact.cshtml");
        }

        public ActionResult WishListFrontend()
        {
            return View("~/Views/Frontend/WishList.cshtml");
        }
    }
}