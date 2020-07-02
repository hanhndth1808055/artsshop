using FinalArtsShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            ViewBag.PaymentStatusList = Enum.GetValues(typeof(PaymentStatusEnum)).Cast<PaymentStatusEnum>().ToList();
            ViewBag.FulfillmentStatusList = Enum.GetValues(typeof(FulfillmentStatusEnum)).Cast<FulfillmentStatusEnum>().ToList();
            return View(db.Orders.OrderByDescending(order => order.Id).ToList());
        }

        public JsonResult UpdatePaymentStatus(int paymentStatusVal, string idOrder)
        {
            var data = "";
            Order order = db.Orders.Find(idOrder);
            order.PaymentStatus = (PaymentStatusEnum)Enum.GetValues(typeof(PaymentStatusEnum)).GetValue(paymentStatusVal);
            db.SaveChanges();
            //var updateSelected = "";
            //foreach(var status in Enum.GetValues(typeof(PaymentStatusEnum)).Cast<PaymentStatusEnum>().ToList())
            //{
            //    if ((Int32)status == paymentStatusVal)
            //    {
            //        updateSelected = "selected";
            //    }
            //    data += "<option " + updateSelected + " value ='"+ (Int32)status +"'>" + status + "</option>";
            //    updateSelected = "";
            //}
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateFullfillmentStatus(int fullfillmentStatusVal, string idOrder)
        {
            var data = "";
            Order order = db.Orders.Find(idOrder);
            order.FulfillmentStatus = (FulfillmentStatusEnum)Enum.GetValues(typeof(FulfillmentStatusEnum)).GetValue(fullfillmentStatusVal);
            db.SaveChanges();
            return Json(data, JsonRequestBehavior.AllowGet);
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
                return RedirectToAction("");
            }

            return HttpNotFound();
        }
    }
}