using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalArtsShop.Models;

namespace FinalArtsShop.Controllers
{
    public class HomeController : ShoppingCartController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // public ShoppingCart shoppingCart = new ShoppingCart();

        private const string ShoppingCartName = "ShoppingCartName";
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Home()
        {
            List<Category> CategoriesMenu = new List<Category>();
            List<Category> CategoriesProduct = new List<Category>();
            List<Product> Products = new List<Product>();
            List<Product> NewProducts = new List<Product>();
            List<Product> FeatureProducts = new List<Product>();
            List<Product> LatestProducts = new List<Product>();

            CategoriesMenu = db.Categories.Where(c => c.Active == 1).ToList();
            CategoriesProduct = db.Categories.Where(c => c.Parent == 0 && c.Active == 1).Take(4).ToList();
            foreach (var cate in CategoriesProduct)
            {
                var count = 0;
                foreach (var cate2 in CategoriesMenu)
                {
                    if (cate2.Parent == cate.Id)
                    {
                        if (count < 8)
                        {
                            Products.AddRange(db.Products.Where(p => p.CategoryID == cate2.Id && p.isActive == 1).Take(2).ToList());
                            count += 2;
                        }
                    }
                }
            }

            ViewHomeClient viewHomeClient = new ViewHomeClient() {
                CategoriesProduct = CategoriesProduct,
                Products = Products,
                NewProducts = db.Products.Where(p => p.isNew == 1 && p.isActive == 1).Take(8).ToList(),
                FeatureProducts = db.Products.Where(p => p.isFeature == 1 && p.isActive == 1).Take(8).ToList(),
                shoppingCart = GetShoppingCart(),
                LatestProducts = getLastestProduct()
            };
            if (viewHomeClient != null)
            {
                ViewBag.Message = viewHomeClient;
                return View("~/Views/Home/Home.cshtml");
            }
            else
            {
                return View("~/Views/Home/Home.cshtml");
            }
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

        public ActionResult Product()
        {
            return View("~/Views/Home/Product.cshtml");
        }

        public ActionResult ProductDetail()
        {
            return View("~/Views/Home/ProductDetail.cshtml");
        }

        public ActionResult Cart()
        {
            return View("~/Views/Home/Cart.cshtml");
        }

        public ActionResult Checkout()
        {
            return View("~/Views/Home/Checkout.cshtml");
        }

        public ActionResult Account()
        {
            return View("~/Views/Home/Account.cshtml");
        }

        public ActionResult Contact()
        {
            return View("~/Views/Home/Contact.cshtml");
        }

        public ActionResult WishList()
        {
            return View("~/Views/Home/WishList.cshtml");
        }
    }
}