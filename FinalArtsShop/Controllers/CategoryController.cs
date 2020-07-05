using FinalArtsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalArtsShop.Controllers
{
    public class CategoryController : ShoppingCartController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Category
        public ActionResult Index(int? id, string sortBy,float? minPrice, float? maxPrice, int?page, int? limit)
        {
            int defaultLimit = 9;
            int defaultPage = 1;
            ViewBag.SortBy = "Default";
            ViewCategoryClient viewCategoryClient;

            var CategoriesMenu = db.Categories.Where(c => c.Active == 1).ToList();
            var products = db.Products.AsQueryable();

            if (id != null && id != 0)
            {
                var cate = db.Categories.Where(c => c.Id == id && c.Active == 1).FirstOrDefault();
                ViewBag.CateName = cate.Name;
                if (cate.Parent == 0)
                {
                    products = products.Where(p => p.isActive == 1 && p.Category.Parent == id);
                }
                else
                {
                    products = products.Where(p => p.isActive == 1 && p.CategoryID == id);
                }
            }
            else
            {
                products = products.Where(p => p.isActive == 1);
            }

            if (minPrice > 0 && maxPrice > 0 && maxPrice > minPrice)
            {
                products = products.Where(p => p.UnitPrice >=  minPrice && p.UnitPrice <= maxPrice);
            }

            if (!string.IsNullOrEmpty(sortBy) )
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

            viewCategoryClient = new ViewCategoryClient() {
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