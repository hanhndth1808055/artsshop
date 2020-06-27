using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalArtsShop.Models
{
    public class ViewCheckoutClient
    {
        public List<City> Cities { get; set; }
        public List<District> Districts { get; set; }
        public ApplicationUser User { get; set; }
    }
}