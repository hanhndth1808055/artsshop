using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalArtsShop.Models
{
    public class Product
    {
        public string Id { get; set; }
        [ForeignKey("Category")]
        [Display(Name = "Category ID")]
        [Required]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Display(Name = "Unit Price")]
        [Required]
        public double UnitPrice { get; set; }
        public double PromotionPrice { get; set; }
        public string Thumbnail { get; set; }
        public string Image { get; set; }
        [Required]
        public int Unit { get; set; }
        public int isNew { get; set; }
        public int isActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int isFeature { get; set; }
        public int SellIndex { get; set; }
    }
}