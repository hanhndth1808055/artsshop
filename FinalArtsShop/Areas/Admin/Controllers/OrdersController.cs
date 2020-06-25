using FinalArtsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static FinalArtsShop.Models.ShoppingCart;

namespace FinalArtsShop.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        public readonly String CartSessionName = "cart";
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Orders
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            Product product = db.Products.Find("KC00001");
            ShoppingCart cart = new ShoppingCart();
            cart.Add(product);
            Session[CartSessionName] = cart.Items.ToString();
            if(Session[CartSessionName] != null)
            {
                var items = Session[CartSessionName] as Dictionary<string, CartItem>;
                foreach(CartItem item in items.Values){

                }
            }
           
            return null;
        }
    }
}