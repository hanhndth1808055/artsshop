using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalArtsShop.Models
{
    public class Slide
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Priority { get; set; }
        [Required]
        public string Image { get; set; }
        public int Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}