﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalArtsShop.Models;

namespace FinalArtsShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private const string ShoppingCartName = "ShoppingCartName";

        // GET: ShoppingCart
        public ActionResult ShowCart()
        {
            ViewShoppingCart viewShoppingCart = new ViewShoppingCart() {
                shoppingCart = GetShoppingCart()
            };
            return View(viewShoppingCart);
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
            var existingProduct = db.Products.FirstOrDefault(p => p.Id == productId);

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