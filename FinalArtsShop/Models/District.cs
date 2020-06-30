using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalArtsShop.Models
{
    public class District : BaseEntity
    {
        public int Id { get; set; }
        [ForeignKey("City")]
        public int? CityId { get; set; }
        public virtual City City { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Shipping Fee")]
        public double ShippingFee { get; set; }
        public int Active { get; set; } = 1;
    }
}