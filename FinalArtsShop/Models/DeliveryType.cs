using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalArtsShop.Models
{
    public class DeliveryType : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Abbreviation { get; set; }
        public double Factor { get; set; } = 1;
        public int Active { get; set; } = 1;
    }
}