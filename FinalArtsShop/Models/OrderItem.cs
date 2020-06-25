﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalArtsShop.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        [ForeignKey("Product")]
        public string ProductId { get; set; }
        public string Name { get; set; }
        public virtual Product Product { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Thumbnail { get; set; }
        public double TotalItemPrice => Quantity * Price;
    }
}