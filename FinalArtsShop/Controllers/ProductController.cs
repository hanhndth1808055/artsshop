using FinalArtsShop.Models;
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


            ViewProductClient viewProductClient = new ViewProductClient() {
                Product = product,
                LatestProducts = latestProduct,
                shoppingCart = GetShoppingCart()
            };
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
    }
}