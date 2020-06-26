using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalArtsShop.Models
{
    public class ViewLayoutClient
    {
        public List<Category> CategoriesMenu { get; set; }
        private ApplicationDbContext db { get; set; }

        public ViewLayoutClient()
        {
            db = new ApplicationDbContext();
            CategoriesMenu = db.Categories.Where(c => c.Active == 1).ToList();
        }
    }
}