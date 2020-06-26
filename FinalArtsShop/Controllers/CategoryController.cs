using FinalArtsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalArtsShop.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Category
        public ActionResult Index(int id)
        {
            ViewCategoryClient viewCategoryClient;

            var CategoriesMenu = db.Categories.Where(c => c.Active == 1).ToList();
            var products = db.Products.AsQueryable();

            if (id != null && id != 0)
            {
                var cate = db.Categories.Where(c => c.Id == id && c.Active == 1).FirstOrDefault();
                ViewBag.CateName = cate.Name;
                if (cate.Parent == 0)
                {
                    products = products.Where(p => p.isActive == 1 && p.Category.Parent == id).Take(15);
                }
                else
                {
                    products = products.Where(p => p.isActive == 1 && p.CategoryID == id).Take(15);
                }
            }
            else
            {

            }

            viewCategoryClient = new ViewCategoryClient() {
                Products = products.ToList(),
                FeatureProducts = db.Products.Where(p => p.isFeature > 0).Take(3).ToList(),
                LatestProducts = getLastestProduct()
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