﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalArtsShop.Models
{
    public class ViewHomeClient : ViewLayoutClient
    {
        public List<Category> CategoriesProduct { get; set; }
        public List<Product> Products { get; set; }
        public List<Product> NewProducts { get; set; }
        public List<Product> FeatureProducts { get; set; }
        public List<Product> LatestProducts { get; set; }
        public List<Post> ListPost { get; set; }
    }
}