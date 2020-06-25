using FinalArtsShop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        [HttpGet]
        public ActionResult Create()
        {
            //ShoppingCart cart = new ShoppingCart();
            //Session[CartSessionName] = cart.Items;
            if (Session[CartSessionName] != null)
            {
                Dictionary<string, CartItem> items;
                try
                {
                    items = Session[CartSessionName] as Dictionary<string, CartItem>;
                }
                catch (Exception e)
                {
                    items = new Dictionary<string, CartItem>();
                }
                OrderItem orderItem;
                foreach (CartItem item in items.Values)
                {
                    orderItem = new OrderItem
                    {
                        Name = item.Name,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        Thumbnail = item.Thumbnail,
                        ProductId = item.ProductId,
                    };
                }
                Order order = new Order()
                {

                };
            }
            return null;
        }
    }
}