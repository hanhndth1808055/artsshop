﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalArtsShop.Models
{
    public class Order : BaseEntity
    {
        public string Id { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
        [ForeignKey("DeliveryType")]
        public int? DeliveryTypeId { get; set; }
        public virtual DeliveryType DeliveryType { get; set; }
        public int Status { get; set; }
        public int Active { get; set; }
        public FulfillmentStatusEnum FulfillmentStatus { get; set; }
        public PaymentStatusEnum PaymentStatus { get; set; }
        public ReturnStatusEnum ReturnStatus { get; set; }
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
        public DateTime? ShippedAt { get; set; }
        public DateTime? ReturnedAt { get; set; }

        //Order Items
        public Dictionary<string, OrderItem> Items { get; set; }

        public double TotalPrice { get; set; }

        public Order()
        {
            Items = new Dictionary<string, OrderItem>();
        }
    }

    public enum ReturnStatusEnum
    {
        Void = 0,
        Returning = 1,
        Returned = 2,
        Failed = 3
    }

    public enum PaymentMethodEnum
    {
        Void = 0,
        Paypal = 1,
        VPP = 2,
        Check = 3,
        DD = 4,
        Pending = 5
    }

    public enum PaymentStatusEnum
    {
        Void = 0,
        Paid = 1,
        Unpaid = 2,
        Pending = 3
    }

    public enum FulfillmentStatusEnum
    {
        Void = 0,
        Pending = 1,
        Fulfilled = 2,
        NotReturned = 3,
        Returned = 4,
        NeverReturn = 5
    }
}