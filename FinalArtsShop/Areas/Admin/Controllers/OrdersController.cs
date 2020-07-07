using FinalArtsShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static FinalArtsShop.Models.ShoppingCart;

namespace FinalArtsShop.Areas.Admin.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Orders
        public ActionResult Index(DateTime? start, DateTime? end)
        {
            ViewBag.PaymentStatusList = Enum.GetValues(typeof(PaymentStatusEnum)).Cast<PaymentStatusEnum>().ToList();
            ViewBag.FulfillmentStatusList = Enum.GetValues(typeof(FulfillmentStatusEnum)).Cast<FulfillmentStatusEnum>().ToList();
            var orders = db.Orders.AsQueryable();
            orders = orders.OrderByDescending(o => o.CreatedAt);

            if (start != null)
            {
                var startDate = start.GetValueOrDefault().Date;
                startDate = startDate.Date + new TimeSpan(0, 0, 0);
                orders = orders.Where(p => p.CreatedAt >= startDate);
            }

            if (end != null)
            {
                var endDate = end.GetValueOrDefault().Date;
                endDate = endDate.Date + new TimeSpan(23, 59, 59);
                orders = orders.Where(p => p.CreatedAt <= endDate);
            }

            return View(orders.ToList());
        }

        [HttpGet]
        public ActionResult Detail(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            var listOrderDetails = new List<OrderItem>();
            if(order.OrderItems != null)
            {
                listOrderDetails = order.OrderItems.ToList();
            }
            return View(listOrderDetails);
        }

        public JsonResult UpdatePaymentStatus(int paymentStatusVal, string idOrder)
        {
            var data = "";
            Order order = db.Orders.Find(idOrder);
            if (order != null)
            {
                order.PaymentStatus = (PaymentStatusEnum)Enum.GetValues(typeof(PaymentStatusEnum)).GetValue(paymentStatusVal);
                db.SaveChanges();
                data = order.PaymentStatus.ToString();
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateFullfillmentStatus(int fullfillmentStatusVal, string idOrder)
        {
            var data = "";
            Order order = db.Orders.Find(idOrder);
            if (order != null)
            {
                order.FulfillmentStatus = (FulfillmentStatusEnum)Enum.GetValues(typeof(FulfillmentStatusEnum)).GetValue(fullfillmentStatusVal);
                db.SaveChanges();
                data = order.FulfillmentStatus.ToString();
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}