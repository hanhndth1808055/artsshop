using FinalArtsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static FinalArtsShop.Models.ShoppingCart;

namespace FinalArtsShop.Areas.Admin.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        public readonly String CartSessionName = "cart";
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Orders
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

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
                if (items.Count < 0)
                {
                    return HttpNotFound();
                }
                OrderItem orderItem;
                Order order;
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
                order = new Order()
                {

                };
                return RedirectToAction("");
            }

            return HttpNotFound();
        }
    }
}