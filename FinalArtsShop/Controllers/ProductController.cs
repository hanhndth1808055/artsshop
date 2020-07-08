using FinalArtsShop.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FinalArtsShop.Controllers
{
    public class ProductController : ShoppingCartController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Product
        public ActionResult Index(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            var latestProduct = getLastestProduct();
            var check = true;
            foreach (var item in latestProduct)
            {
                if (item.Id == product.Id)
                {
                    check = false;
                    break;
                }
            }
            if (check == true)
            {
                latestProduct.Insert(0, product);
                setLastestProduct(latestProduct);
            }
            ViewProductClient viewProductClient = new ViewProductClient()
            {
                Product = product,
                LatestProducts = latestProduct,
                shoppingCart = GetShoppingCart()
            };
            var comment = db.Comments.Where(p => p.ProductId == id).OrderByDescending(p => p.CreatedAt).ToList();
            if(comment != null)
            {
                ViewBag.CommentData = comment;
            }
            else
            {
                ViewBag.CommentData = new Comment();
            }
            return View(viewProductClient);
        }

        public List<Product> getLastestProduct()
        {
            List<Product> LastestProduct = null;
            if (Session["LastestProduct"] != null)
            {
                LastestProduct = Session["LastestProduct"] as List<Product>;
            }
            if (Session["LastestProduct"] == null)
            {
                LastestProduct = new List<Product>();
            }
            return LastestProduct;
        }

        public void setLastestProduct(List<Product> LastestProduct)
        {
            Session["LastestProduct"] = LastestProduct;
        }

        [HttpPost]
        public JsonResult GetComment(string idProduct, int rate, string name, string message)
        {
            var data = "";
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindByNameAsync(User.Identity.Name).Result;
            var userId = (user != null) ? user.Id : null;
            if (idProduct != null)
            {
                Comment newComment = new Comment
                {
                    ProductId = idProduct,
                    Name = name,
                    Rate = rate,
                    Message = message,
                    CreatedAt = DateTime.Now,
                    UserId = userId,
                };
                db.Comments.Add(newComment);
                db.SaveChanges();
                var star = "";
                for (var i = 0; i < 5; i++)
                {
                    if (i < rate)
                    {
                        star += "<span class='fa fa-star'></span>";
                    }
                    else
                    {
                        star += "<span class='fa fa-star-o'></span>";
                    }
                }
                data += "<li>";
                data += "<div class='media'>";
                data += "<div class='media-left'>";
                data += "<a href='#'>";
                data += "<img class='media-object' src='https://cdn4.vectorstock.com/i/thumb-large/52/38/avatar-icon-vector-11835238.jpg' alt=''>";
                data += "</a>";
                data += "</div>";
                data += "<div class='media-body'>";
                data += "<h4 class='media-heading'><strong>" + name + "</strong> - <span> " + TimeZoneInfo.ConvertTimeFromUtc((DateTime)newComment.CreatedAt, TimeZoneInfo.Local).ToString("MM/dd/yyyy") + "</span></h4>";
                data += "<div class='aa-product-rating'>";
                data += star;
                data += "</div>";
                data += "<p>";
                data += message;
                data += "</p>";
                data += "</div>";
                data += "</div>";
                data += "</li>";
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}