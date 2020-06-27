using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalArtsShop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace FinalArtsShop.Controllers
{
    public class CheckoutController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
;
        // GET: Checkout
        public ActionResult Index()
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindByNameAsync(User.Identity.Name).Result;
            ViewCheckoutClient viewCheckoutClient = new ViewCheckoutClient() {
                User = user,
                Cities = db.Cities.ToList(),
                Districts = db.Districts.ToList()
            };
            return View(viewCheckoutClient);
        }
    }
}