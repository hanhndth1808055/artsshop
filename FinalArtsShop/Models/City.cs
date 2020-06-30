using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalArtsShop.Models
{
    public class City : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "City Name")]
        public string Name { get; set; }
        public int Active { get; set; } = 1;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}