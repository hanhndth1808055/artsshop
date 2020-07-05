using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalArtsShop.Models
{
    public class ViewPostClient : ViewLayoutClient
    {
        public Post Post { get; set; }
        public int IdPrev { get; set; }
        public int IdNext { get; set; }
        public List<Product> FeatureProducts { get; set; }
    }
}