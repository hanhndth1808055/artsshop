using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalArtsShop.Models
{
    public class ViewProductClient
    {
        public List<Category> CategoriesMenu { get; set; }
        public List<Product> LatestProducts { get; set; }
        public Product Product { get; set; }
    }
}