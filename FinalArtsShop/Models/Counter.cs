using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalArtsShop.Models
{
    public class Counter
    {
        public int Id { get; set; }
        public int? CountProduct { get; set; }
        public int? CountInvoice { get; set; }
        public ActiveEnum Active { get; set; }
    }

    public enum ActiveEnum
    {
        Active = 1, Inactive = 0
    }
}