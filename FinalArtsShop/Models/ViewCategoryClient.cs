using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalArtsShop.Models
{
    public class ViewCategoryClient : ViewLayoutClient
    {
        public List<Product> Products { get; set; }
        public List<Product> FeatureProducts { get; set; }
        public List<Product> LatestProducts { get; set; }
    }
}