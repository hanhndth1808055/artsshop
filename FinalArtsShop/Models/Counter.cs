using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalArtsShop.Models
{
    public class Counter : BaseEntity
    {
        public int Id { get; set; }
        public int? CountProduct { get; set; }
        public ActiveEnum Active { get; set; }
    }

    public enum ActiveEnum
    {
        Active = 1, Inactive = 0
    }
}