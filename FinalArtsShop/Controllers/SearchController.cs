using FinalArtsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalArtsShop.Controllers
{
    public class SearchController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Search
        public ActionResult Search(string keyword)
        {
            List<Product> products = null;
            ViewCategoryClient viewCategoryClient;
            if (!string.IsNullOrEmpty(keyword))
            {
                products = db.Products.Where(p => p.isActive == 1 && p.Name.Contains(keyword) || p.Description.Contains(keyword) || p.Category.Name.Contains(keyword)).ToList();
                viewCategoryClient = new ViewCategoryClient()
                {
                    CategoriesMenu = db.Categories.Where(c => c.Active == 1).ToList(),
                    Products = products,
                    FeatureProducts = db.Products.Where(p => p.isFeature > 0).Take(3).ToList(),
                    LatestProducts = getLastestProduct()
                };
            }
            else
            {
                viewCategoryClient = new ViewCategoryClient()
                {
                    CategoriesMenu = db.Categories.Where(c => c.Active == 1).ToList(),
                    FeatureProducts = db.Products.Where(p => p.isFeature > 0).Take(3).ToList(),
                    LatestProducts = getLastestProduct()
                };
            }
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