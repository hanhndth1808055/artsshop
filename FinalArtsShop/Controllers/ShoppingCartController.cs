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
            ViewShoppingCart viewShoppingCart = new ViewShoppingCart()
            {
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
            ShoppingCart shoppingCart = new ShoppingCart();
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

        public JsonResult AddToCartWithAjax(string productId, int quantity)
        {
            var existingProduct = HttpContext.GetOwinContext().Get<ApplicationDbContext>().Products.FirstOrDefault(p => p.Id == productId);
            var data = "";
            if (existingProduct != null)
            {
                ShoppingCart shoppingCart = GetShoppingCart();
                shoppingCart.Add(existingProduct, quantity, false);
                SetShoppingCart(shoppingCart);
                foreach (var cartItem in shoppingCart.Items.Values)
                {
                    data += "<li>";
                    data += "<a class='aa-cartbox-img' href='#'><img src='/MarkUps-dailyShop/dailyShop/img/electronics/" + @cartItem.Product.Image + "'alt='img'></a>";
                    data += "<div class='aa-cartbox-info'>";
                    data += "<h4><a href='#'>" + @cartItem.Name + "</a></h4>";
                    data += "<p>" + @cartItem.Quantity + " x $" + @cartItem.Price + "</p>";
                    data += "</div>";
                    data += "<a class='aa-remove-product' href='/ShoppingCart/RemoveCartItem?productId=" + @cartItem.ProductId + "'><span class='fa fa-times'></span></a>";
                    data += "</li>";
                }
                data += "<input type='hidden' id='hiddenCartNum' value=" + shoppingCart.TotalItem + " />";
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoveItemWithAjax(string productId)
        {
            String[] dataArr = new string[4];
            var data = "";
            var dataForHeader = "";
            if (productId != null)
            {
                RemoveCartItem(productId);
                ShoppingCart shoppingCart = GetShoppingCart();
                SetShoppingCart(shoppingCart);
                foreach (var cartItem in shoppingCart.Items.Values)
                {
                    data += "<tr>";
                    data += "<td><a data-id='" + cartItem.ProductId + "class='removeItem'><fa class='fa fa-close'></fa></a></td>";
                    data += "<td><a href='#'><img src='https://res.cloudinary.com/daaycakkk/image/upload/c_limit,h_300,w_250/v1587872991/" + cartItem.Thumbnail + ".jpg' alt='img'></a></td>";
                    data += "<td><a class='aa-cart-title' href='#'>" + cartItem.Name + "</a></td>";
                    data += "<td>$" + cartItem.Price + "</td>";
                    data += "<td><input data-id='" + cartItem.ProductId + "' min ='1' class='aa-cart-quantity' type='number' value=" + cartItem.Quantity + "></td>";
                    data += "<td id='ItemPrice" + cartItem.ProductId + "'>$" + cartItem.TotalItemPrice + "</td>";
                    data += "</tr>";
                    dataForHeader += "<li>";
                    dataForHeader += "<a class='aa-cartbox-img' href='#'><img src='/MarkUps-dailyShop/dailyShop/img/electronics/" + @cartItem.Product.Image + "'alt='img'></a>";
                    dataForHeader += "<div class='aa-cartbox-info'>";
                    dataForHeader += "<h4><a href='#'>" + @cartItem.Name + "</a></h4>";
                    dataForHeader += "<p>" + @cartItem.Quantity + " x $" + @cartItem.Price + "</p>";
                    dataForHeader += "</div>";
                    dataForHeader += "<a class='aa-remove-product' href='/ShoppingCart/RemoveCartItem?productId=" + @cartItem.ProductId + "'><span class='fa fa-times'></span></a>";
                    dataForHeader += "</li>";
                }
                dataArr[0] = data;
                dataArr[1] = dataForHeader;
                dataArr[2] = "$" + shoppingCart.TotalPrice.ToString();
                dataArr[3] = shoppingCart.TotalItem.ToString();
            }
            return Json(dataArr, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateNumOfProductWithAjax(string productId, int quantity)
        {
            var existingProduct = HttpContext.GetOwinContext().Get<ApplicationDbContext>().Products.FirstOrDefault(p => p.Id == productId);
            String[] dataArr = new string[4];
            var dataForHeader = "";
            if (existingProduct != null)
            {
                ShoppingCart shoppingCart = GetShoppingCart();
                shoppingCart.Update(existingProduct, quantity);
                SetShoppingCart(shoppingCart);
                foreach (var cartItem in shoppingCart.Items.Values)
                {
                    dataForHeader += "<li>";
                    dataForHeader += "<a class='aa-cartbox-img' href='#'><img src='/MarkUps-dailyShop/dailyShop/img/electronics/" + @cartItem.Product.Image + "'alt='img'></a>";
                    dataForHeader += "<div class='aa-cartbox-info'>";
                    dataForHeader += "<h4><a href='#'>" + @cartItem.Name + "</a></h4>";
                    dataForHeader += "<p>" + @cartItem.Quantity + " x $" + @cartItem.Price + "</p>";
                    dataForHeader += "</div>";
                    dataForHeader += "<a class='aa-remove-product' href='/ShoppingCart/RemoveCartItem?productId=" + @cartItem.ProductId + "'><span class='fa fa-times'></span></a>";
                    dataForHeader += "</li>";
                }
                dataArr[0] = dataForHeader;
                dataArr[1] = "$" + shoppingCart.TotalPrice.ToString();
                dataArr[2] = shoppingCart.TotalItem.ToString();
                dataArr[3] = "$" + shoppingCart.Items[productId].TotalItemPrice.ToString();
            }
            return Json(dataArr, JsonRequestBehavior.AllowGet);


        }
    }
}