using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalArtsShop.Models
{
    public class Product
    {
        public string Id { get; set; }
        public int IdType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public double PromotionPrice { get; set; }
        public string Thumbnail { get; set; }
        public string Image { get; set; }
        public int Unit { get; set; }
        public int New { get; set; }
        public int Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Feature { get; set; }
        public int SellIndex { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}