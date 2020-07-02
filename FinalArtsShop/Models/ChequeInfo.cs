using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalArtsShop.Models
{
    public class ChequeInfo : BaseEntity
    {
        public int Id { get; set; }
        [ForeignKey("Order")]
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Payer  { get; set; }
        public string ChequeCode { get; set; }
        public double Amount { get; set; }
        public string AmountByWord { get; set; }
        public string BankName { get; set; }
        public string Receiver { get; set; }
        public string Image { get; set; }
    }
}