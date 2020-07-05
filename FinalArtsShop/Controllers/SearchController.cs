using FinalArtsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalArtsShop.Controllers
{
    public class SearchController : ShoppingCartController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Search
        public ActionResult Search(string keyword, string sortBy, int? page, int? limit)
        {
            int defaultLimit = 9;
            int defaultPage = 1;
            ViewBag.SortBy = "Default";
            ViewCategoryClient viewCategoryClient;

            var CategoriesMenu = db.Categories.Where(c => c.Active == 1).ToList();
            var products = db.Products.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                products = db.Products.Where(p => p.isActive == 1 && p.Name.Contains(keyword) || p.Description.Contains(keyword) || p.Category.Name.Contains(keyword));
                ViewBag.Keyword = keyword;
            }
            else
            {
                ViewBag.Keyword = "";
            }


            if (!string.IsNullOrEmpty(sortBy))
            {
                ViewBag.SortBy = sortBy;
            }

            switch (sortBy)
            {
                case "Name":
                    products = products.OrderBy(p => p.Name);
                    break;
                case "Price":
                    products = products.OrderBy(p => p.UnitPrice);
                    break;
                case "Date":
                    products = products.OrderBy(p => p.CreatedAt);
                    break;
                default:
                    products = products.OrderByDescending(p => p.CreatedAt);
                    break;
            }

            if (page.HasValue)
            {
                defaultPage = page.Value;
            }

            if (limit.HasValue)
            {
                defaultLimit = limit.Value;
            }

            int totalItem = products.Count();
            double totalPage = Math.Ceiling((double)totalItem / defaultLimit);
            products = products.Skip((defaultPage - 1) * defaultLimit).Take(defaultLimit);
            ViewBag.totalItem = totalItem;
            ViewBag.totalPage = (int)totalPage;
            ViewBag.currentPage = defaultPage;
            ViewBag.limit = defaultLimit;

            viewCategoryClient = new ViewCategoryClient()
            {
                Products = products.ToList(),
                FeatureProducts = db.Products.Where(p => p.isFeature > 0).Take(3).ToList(),
                LatestProducts = getLastestProduct(),
                shoppingCart = GetShoppingCart()
            };

            return View(viewCategoryClient);
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
    }
}