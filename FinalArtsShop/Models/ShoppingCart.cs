using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace FinalArtsShop.Models
{
    public class ShoppingCart
    {
        public Dictionary<string, CartItem> Items { get; set; }

        public double TotalPrice => Items.Values.Sum(i => i.TotalItemPrice);

        public ShoppingCart()
        {
            Items = new Dictionary<string, CartItem>();
        }
        public class CartItem
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

        public void Add(Product product, int quantity, bool isUpdate)
        {
            var cartItem = new CartItem()
            {
                ProductId = product.Id,
                Product = product,
                Price = (product.PromotionPrice == null || product.PromotionPrice == 0) ? product.UnitPrice : product.PromotionPrice,
                Name = product.Name,
                Quantity = quantity,
                Thumbnail = product.Thumbnail
            };

            var existKey = Items.ContainsKey(product.Id);
        
            if (existKey && !isUpdate)
            {
                var existingItem = Items[product.Id];
                cartItem.Quantity += existingItem.Quantity;
            }
        
            if (existKey)
            {
                Items[product.Id] = cartItem;
            }
            else
            {
                Items.Add(product.Id, cartItem);
            }
        }

        public void Add(Product product)
        {
            Add(product, 1, false);
        }
        
        public void Update(Product product, int quantity)
        {
            Add(product, quantity, true);
        }

        public void Delete(string productId)
        {
            if (Items.ContainsKey(productId))
            {
                Items.Remove(productId);
            }
        }

        public void Clear()
        {
            Items.Clear();
        }
    }
}