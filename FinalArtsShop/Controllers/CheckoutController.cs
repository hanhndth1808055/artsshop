using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using FinalArtsShop.Areas.Admin.Controllers;
using FinalArtsShop.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.BuilderProperties;
using Stripe;
using Order = FinalArtsShop.Models.Order;
using OrderItem = FinalArtsShop.Models.OrderItem;

namespace FinalArtsShop.Controllers
{
    public class CheckoutController : Controller
    {
        // private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        // GET: Checkout
        public ActionResult Index()
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindByNameAsync(User.Identity.Name).Result;
            ViewCheckoutClient viewCheckoutClient = new ViewCheckoutClient()
            {
                User = user,
                Cities = HttpContext.GetOwinContext().Get<ApplicationDbContext>().Cities.ToList(),
                Districts = HttpContext.GetOwinContext().Get<ApplicationDbContext>().Districts.ToList(),
                DeliveryTypes = HttpContext.GetOwinContext().Get<ApplicationDbContext>().DeliveryTypes.ToList()
            };
            return View(viewCheckoutClient);
        }

        public ActionResult PlaceOrder(string email, string phoneNumber, int city, int district, string address, int deliveryType, string note, int optionsRadios)
        {
            var currentDistrict = HttpContext.GetOwinContext().Get<ApplicationDbContext>().Districts.Find(district);
            var currentDeliveryType = HttpContext.GetOwinContext().Get<ApplicationDbContext>().DeliveryTypes
                .Find(deliveryType);

            double shippingFee = currentDistrict.ShippingFee * currentDeliveryType.Factor;

            if (Session["ShoppingCartName"] != null)
            {

                ShoppingCart shoppingCart = Session["ShoppingCartName"] as ShoppingCart;

                Dictionary<string, ShoppingCart.CartItem> items;
                try
                {
                    items = shoppingCart.Items;
                }
                catch (Exception e)
                {
                    items = new Dictionary<string, ShoppingCart.CartItem>();
                }
                if (items.Count < 0)
                {
                    return HttpNotFound();
                }
                Order order;
                var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ApplicationUser user = userManager.FindByNameAsync(User.Identity.Name).Result;
                var stringId = items.Keys.FirstOrDefault() + currentDeliveryType.Abbreviation + GetRandomString(8);
                while(HttpContext.GetOwinContext().Get<ApplicationDbContext>().Orders.Where(p => p.Id == stringId).Any())
                {
                    stringId = items.Keys.FirstOrDefault() + currentDeliveryType.Abbreviation + GetRandomString(8);
                }
                order = new Order()
                {
                    Id = stringId,
                    Active = 1,
                    Address = address,
                    CityId = city,
                    City = HttpContext.GetOwinContext().Get<ApplicationDbContext>().Cities.Find(city),
                    ApplicationUser = user,
                    CustomerEmail = email,
                    CustomerName = user.FirstName + " " + user.LastName,
                    CustomerPhoneNumber = phoneNumber,
                    DeliveryTypeId = deliveryType,
                    DeliveryType = currentDeliveryType,
                    DistrictId = district,
                    District = currentDistrict,
                    FulfillmentStatus = FulfillmentStatusEnum.Pending,
                    PaymentStatus = PaymentStatusEnum.Pending,
                    PaymentMethod = optionsRadios == 1 ? PaymentMethodEnum.Paypal : (optionsRadios == 2 ? PaymentMethodEnum.VPP : (optionsRadios == 3 ? PaymentMethodEnum.Check : (optionsRadios == 4 ? PaymentMethodEnum.CreditCard : PaymentMethodEnum.Pending))),
                    Note = note,
                    Otp = "12345",
                    Status = 1,
                    UserId = user.Id,
                    LineItemsPrice = shoppingCart.TotalPrice,
                    ShippingFee = shippingFee,
                    TotalPrice = shoppingCart.TotalPrice + shippingFee
                };
                Dictionary<string, OrderItem> listOrderItem = new Dictionary<string, OrderItem>();
                OrderItem orderItem = null;
                foreach (ShoppingCart.CartItem item in items.Values)
                {
                    orderItem = new OrderItem
                    {
                        OrderId = order.Id,
                        Name = item.Name,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        Thumbnail = item.Thumbnail,
                        ProductId = item.ProductId,
                    };
                    listOrderItem.Add(orderItem.ProductId, orderItem);
                    orderItem = null;
                }

                if (ModelState.IsValid)
                {
                    HttpContext.GetOwinContext().Get<ApplicationDbContext>().Orders.Add(order);
                    HttpContext.GetOwinContext().Get<ApplicationDbContext>().SaveChanges();
                    foreach (var value in listOrderItem.Values)
                    {
                        value.OrderId = order.Id;
                        HttpContext.GetOwinContext().Get<ApplicationDbContext>().OrderItems.Add(value);
                        HttpContext.GetOwinContext().Get<ApplicationDbContext>().SaveChanges();
                    }
                }
                if (optionsRadios == 1)
                {
                    return paypalPayment(order);
                }
                else if (optionsRadios == 2)
                {
                    Session["ShoppingCartName"] = new ShoppingCart();
                    return VppPayment(order);
                }
                else if (optionsRadios == 3)
                {
                    Session["ShoppingCartName"] = new ShoppingCart();
                    return ChequePayment(order);
                }
                else if (optionsRadios == 4)
                {
                    Session["ShoppingCartName"] = new ShoppingCart();
                    return StripePayment(order);
                }

                Session["ShoppingCartName"] = new ShoppingCart();
                return RedirectToAction("Home", "Home");
            }

            return View();
        }
        
        public string GetRandomString(int length)
        {
            var random = new Random();
            const string pool = "0123456789";
            var builder = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }
            return builder.ToString();
        }

        private ActionResult StripePayment(Order order)
        {
            var stripePublishKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            ViewBag.StripePublishKey = stripePublishKey;
            ViewBag.Message = order;
            return View("~/Views/Checkout/ConfirmStripe.cshtml");
        }

        public ActionResult Charge(string stripeEmail, string stripeToken, decimal amount, string orderId)
        {
            var customers = new CustomerService();
            var charges = new Stripe.ChargeService();

            amount = (long)amount;

            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindByNameAsync(User.Identity.Name).Result;

            var customer = customers.Create(options: new Stripe.CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken,
                Name = user.UserName
            });

            var charge = charges.Create(new Stripe.ChargeCreateOptions
            {
                Amount = (long)amount,//charge in cents
                Description = "Sample Charge",
                Currency = "usd",
                Customer = customer.Id
            });

            if (charge.Status == "succeeded" && charge.Paid == true)
            {
                if (ModelState.IsValid)
                {
                    var order = HttpContext.GetOwinContext().Get<ApplicationDbContext>().Orders.Find(orderId);
                    order.PaymentStatus = PaymentStatusEnum.Paid;
                    HttpContext.GetOwinContext().Get<ApplicationDbContext>().Entry(order).State = EntityState.Modified;
                    HttpContext.GetOwinContext().Get<ApplicationDbContext>().SaveChanges();

                    ViewBag.Message = order;
                    ViewBag.Msg = "Payment is successful!";
                    return View("~/Views/Checkout/StripeCharge.cshtml");
                }
            }

            ViewBag.Msg = "Payment is not successful!";
            return View("~/Views/Checkout/StripeCharge.cshtml");
        }
        private ActionResult ChequePayment(Order order)
        {
            ViewBag.Message = order;
            ViewBag.OrderId = new SelectList(HttpContext.GetOwinContext().Get<ApplicationDbContext>().Orders.Where(o => o.Id == order.Id), "Id", "CreatedAt");
            return View("~/Views/Checkout/ConfirmCheque.cshtml");
        }

        private ActionResult VppPayment(Order order)
        {
            ViewBag.Message = order;
            return View("~/Views/Checkout/ConfirmVpp.cshtml");
        }

        private ActionResult paypalPayment(Order order)
        {
            ViewBag.Message = order;
            return View("~/Views/Checkout/Confirm.cshtml");
        }

        public int randomNum()
        {
            var random = new Random();
            var value = random.Next();
            return value;
        }

        [Authorize]
        public JsonResult ReturnOrderForAjax(string orderId)
        {
            var data = "";
            var order = HttpContext.GetOwinContext().Get<ApplicationDbContext>().Orders.Find(orderId);
            if (order != null)
            {
                if (order.ShippedAt == null)
                {
                    order.FulfillmentStatus = FulfillmentStatusEnum.Returned;
                    HttpContext.GetOwinContext().Get<ApplicationDbContext>().Entry(order).State = EntityState.Modified;
                    HttpContext.GetOwinContext().Get<ApplicationDbContext>().SaveChanges();
                    data = "success";
                }
                else
                {
                    var timeDiff = DateTime.Now.Subtract((DateTime)order.ShippedAt).TotalDays;
                    if (timeDiff < 7)
                    {
                        order.FulfillmentStatus = FulfillmentStatusEnum.Returning;
                        HttpContext.GetOwinContext().Get<ApplicationDbContext>().Entry(order).State = EntityState.Modified;
                        HttpContext.GetOwinContext().Get<ApplicationDbContext>().SaveChanges();
                        data = "success";
                    }
                }  
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChequeStore([Bind(Include = "Id,OrderId,Name,Address,City,State, ZipCode, Payer, ChequeCode, Amount, AmountByWord, BankName, Receiver, Image,CreatedAt,UpdatedAt")] ChequeInfo chequeInfo)
        {
            var orderId = chequeInfo.OrderId;

            if (ModelState.IsValid)
            {
                HttpContext.GetOwinContext().Get<ApplicationDbContext>().ChequeInfos.Add(chequeInfo);
                HttpContext.GetOwinContext().Get<ApplicationDbContext>().SaveChanges();
                ViewBag.Message = HttpContext.GetOwinContext().Get<ApplicationDbContext>().Orders.Find(orderId);
                return View("ChequeFinish");
            }

            Debug.WriteLine(orderId);
            ViewBag.OrderId = new SelectList(HttpContext.GetOwinContext().Get<ApplicationDbContext>().Orders.Where(o => o.Id == orderId), "Id", "CreatedAt");
            ViewBag.Message = HttpContext.GetOwinContext().Get<ApplicationDbContext>().Orders.Find(ViewBag.OrderId);
            return View("~/Views/Checkout/Confirm.cshtml");
        }

        public JsonResult getDistrictWithAjax(int idCity)
        {
            var data = "";
            if (idCity > 0)
            {
                var districts = HttpContext.GetOwinContext().Get<ApplicationDbContext>().Districts
                    .Where(d => d.CityId == idCity)
                    .Where(d => d.Active == 1)
                    .ToList();

                if (districts.Count() > 0)
                {
                    data += "<option selected value=''>Select Your District</option>";
                    foreach (var district in districts)
                    {
                        data += "<option data-num=" + district.ShippingFee + " value=" + district.Id + ">" + district.Name + "</option>";
                    }
                }
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getOrderItems(Dictionary<String, OrderItem> orderContent)
        {
            var data = "";
            foreach(var orderItem in orderContent.Values)
            {
                data += orderItem.Name;
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ClearCart()
        {
            var data = "";
            Session["ShoppingCartName"] = new ShoppingCart();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}