using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalArtsShop.Models;
using Microsoft.AspNet.Identity.Owin;

namespace FinalArtsShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        // private ApplicationDbContext db = new ApplicationDbContext();

        private const string ShoppingCartName = "ShoppingCartName";

        // GET: ShoppingCart
        public ActionResult ShowCart()
        {
            List<Category> CategoriesMenu = new List<Category>();
            List<Category> CategoriesProduct = new List<Category>();
            List<Product> Products = new List<Product>();
            List<Product> NewProducts = new List<Product>();
            List<Product> FeatureProducts = new List<Product>();
            List<Product> LatestProducts = new List<Product>();

            CategoriesMenu = HttpContext.GetOwinContext().Get<ApplicationDbContext>().Categories.Where(c => c.Active == 1).ToList();
            CategoriesProduct = HttpContext.GetOwinContext().Get<ApplicationDbContext>().Categories.Where(c => c.Parent == 0 && c.Active == 1).Take(4).ToList();
            foreach (var cate in CategoriesProduct)
            {
                var count = 0;
                foreach (var cate2 in CategoriesMenu)
                {
                    if (cate2.Parent == cate.Id)
                    {
                        if (count < 8)
                        {
                            Products.AddRange(HttpContext.GetOwinContext().Get<ApplicationDbContext>().Products.Where(p => p.CategoryID == cate2.Id && p.isActive == 1).Take(2).ToList());
                            count += 2;
                        }
                    }
                }
            }

            ViewHomeClient viewHomeClient = new ViewHomeClient()
            {
                CategoriesProduct = CategoriesProduct,
                Products = Products,
                NewProducts = HttpContext.GetOwinContext().Get<ApplicationDbContext>().Products.Where(p => p.isNew == 1 && p.isActive == 1).Take(8).ToList(),
                FeatureProducts = HttpContext.GetOwinContext().Get<ApplicationDbContext>().Products.Where(p => p.isFeature == 1 && p.isActive == 1).Take(8).ToList(),
                shoppingCart = GetShoppingCart(),
                LatestProducts = getLastestProduct()
            };
            ViewBag.Message = viewHomeClient;
            ViewShoppingCart viewShoppingCart = new ViewShoppingCart() {
                shoppingCart = GetShoppingCart()
            };

            return View(viewShoppingCart);
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
        public ShoppingCart GetShoppingCart()
        {
            ShoppingCart shoppingCart = null;
            if (Session[ShoppingCartName] != null)
            {
                try
                {
                    shoppingCart = Session[ShoppingCartName] as ShoppingCart;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart();
            }

            return shoppingCart;
        }

        // GET: ShoppingCart/Details/5
        public ActionResult AddToCart(string productId, int quantity)
        {
            var existingProduct = HttpContext.GetOwinContext().Get<ApplicationDbContext>().Products.FirstOrDefault(p => p.Id == productId);

            if (existingProduct == null)
            {
                return new HttpNotFoundResult();
            }

            ShoppingCart shoppingCart = GetShoppingCart();
            shoppingCart.Add(existingProduct, quantity, false);
            SetShoppingCart(shoppingCart);

            return RedirectToAction("ShowCart");
        }

        private void SetShoppingCart(ShoppingCart shoppingCart)
        {
            Session[ShoppingCartName] = shoppingCart;
        }

        public ActionResult ClearShoppingCart()
        {
            ViewShoppingCart viewShoppingCart = new ViewShoppingCart()
            {
                shoppingCart = GetShoppingCart()
            };

            Session[ShoppingCartName] = null;
            return View("ShowCart", viewShoppingCart);
        }

        public ActionResult RemoveCartItem(string productId)
        {
            ShoppingCart shoppingCart = GetShoppingCart();
            shoppingCart.Delete(productId);
            SetShoppingCart(shoppingCart);

            ViewShoppingCart viewShoppingCart = new ViewShoppingCart()
            {
                shoppingCart = GetShoppingCart()
            };
            return View("ShowCart", viewShoppingCart);
        }

        public ActionResult RemoveOneItem(string productId)
        {
            ViewShoppingCart viewShoppingCart;
            ShoppingCart shoppingCart = GetShoppingCart();
            if (!shoppingCart.Items.ContainsKey(productId))
            {
                viewShoppingCart = new ViewShoppingCart()
                {
                    shoppingCart = GetShoppingCart()
                };
                return View("ShowCart", viewShoppingCart);
            }
            if (shoppingCart.Items[productId].Quantity > 1)
            {
                shoppingCart.Items[productId].Quantity--;
            }
            else if (shoppingCart.Items[productId].Quantity == 1)
            {
                RemoveCartItem(productId);
            }
            SetShoppingCart(shoppingCart);

            viewShoppingCart = new ViewShoppingCart()
            {
                shoppingCart = GetShoppingCart()
            };
            return View("ShowCart", viewShoppingCart);
        }

       
    }
}