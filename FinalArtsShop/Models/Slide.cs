using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalArtsShop.Models
{
    public class Slide
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public string Image { get; set; }
        public int Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}