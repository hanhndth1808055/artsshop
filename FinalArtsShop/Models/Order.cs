using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalArtsShop.Models
{
    public class Order
    {
        public string Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int Payment { get; set; }

        [ForeignKey("DeliveryType")]
        public int? DeliveryTypeId { get; set; }
        public virtual DeliveryType DeliveryType { get; set; }
        public int Status { get; set; }
        public int Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("City")]
        public int? CityId { get; set; }
        public virtual City City { get; set; }

        [ForeignKey("District")]
        public int? DistrictId { get; set; }
        public virtual District District { get; set; }
        public string Address { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmail { get; set; }
        public string Note { get; set; }
        public string Otp { get; set; }

        //Order Items
        public Dictionary<string, OrderItem> Items { get; set; }

        public double TotalPrice => Items.Values.Sum(i => i.TotalItemPrice);

        public Order()
        {
            Items = new Dictionary<string, OrderItem>();
        }
        public class OrderItem
        {
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
}