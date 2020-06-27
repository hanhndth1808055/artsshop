using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using FinalArtsShop.Areas.Admin.Controllers;
using FinalArtsShop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.BuilderProperties;

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
            ViewCheckoutClient viewCheckoutClient = new ViewCheckoutClient() {
                User = user,
                Cities = HttpContext.GetOwinContext().Get<ApplicationDbContext>().Cities.ToList(),
                Districts = HttpContext.GetOwinContext().Get<ApplicationDbContext>().Districts.ToList()
            };
            return View(viewCheckoutClient);
        }

        public ActionResult PlaceOrder(string email, string phoneNumber, int city, int district, string address, int deliveryType, string note, int optionsRadios)
        {
            // Debug.WriteLine("abc" + email);
            // Debug.WriteLine("abc" + phoneNumber);
            // Debug.WriteLine("abc" + city);
            // Debug.WriteLine("abc" + district);
            // Debug.WriteLine("abc" + deliveryType);
            // Debug.WriteLine("abc" + note);
            // Debug.WriteLine("abc" + optionsRadios);

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

                Dictionary<string, OrderItem> listOrderItem = new Dictionary<string, OrderItem>();
                Order order;
                OrderItem orderItem = null;

                foreach (ShoppingCart.CartItem item in items.Values)
                {
                    orderItem = new OrderItem
                    {
                        Name = item.Name,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        Thumbnail = item.Thumbnail,
                        ProductId = item.ProductId,
                    };

                    listOrderItem.Add(orderItem.ProductId, orderItem);

                    orderItem = null;
                }

                var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ApplicationUser user = userManager.FindByNameAsync(User.Identity.Name).Result;

                order = new Order()
                {
                    Id = listOrderItem.Values.FirstOrDefault().ProductId + randomNum(),
                    Active = 1,
                    Items = listOrderItem,
                    Address = address,
                    CityId = city,
                    City = HttpContext.GetOwinContext().Get<ApplicationDbContext>().Cities.Find(city),
                    ApplicationUser = user,
                    CustomerEmail = email,
                    CustomerName = user.FirstName + " " + user.LastName,
                    CustomerPhoneNumber = phoneNumber,
                    DeliveryTypeId = deliveryType,
                    DeliveryType = HttpContext.GetOwinContext().Get<ApplicationDbContext>().DeliveryTypes.Find(deliveryType),
                    DistrictId = district,
                    District = HttpContext.GetOwinContext().Get<ApplicationDbContext>().Districts.Find(district),
                    FulfillmentStatus = FulfillmentStatusEnum.Pending,
                    PaymentStatus = PaymentStatusEnum.Pending,
                    PaymentMethod = optionsRadios == 1 ? PaymentMethodEnum.Paypal : (optionsRadios == 2 ? PaymentMethodEnum.VPP : (optionsRadios == 3 ? PaymentMethodEnum.Check : (optionsRadios == 4 ? PaymentMethodEnum.DD : PaymentMethodEnum.Pending))),
                    Note = note,
                    Otp = "12345",
                    Status = 1,
                    UserId = user.Id,
                    isReturn = 0,
                    TotalPrice = shoppingCart.TotalPrice
                };
                Debug.WriteLine("Order Id " + order.Id);
                if (ModelState.IsValid)
                {
                    foreach (var value in listOrderItem.Values)
                    {
                        HttpContext.GetOwinContext().Get<ApplicationDbContext>().OrderItems.Add(value);
                        HttpContext.GetOwinContext().Get<ApplicationDbContext>().SaveChanges();
                    }
                    HttpContext.GetOwinContext().Get<ApplicationDbContext>().Orders.Add(order);
                    HttpContext.GetOwinContext().Get<ApplicationDbContext>().SaveChanges();
                }

                return RedirectToAction("Home", "Home");
            }

            // return HttpNotFound();
            return View();
        }

        public int randomNum()
        {
            var random = new Random();
            var value = random.Next();
            return value;
        }
    }

}