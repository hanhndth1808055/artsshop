using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalArtsShop.Models
{
    public class Notification : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public int Type { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public string Link { get; set; }
        public int Seen { get; set; }
    }
}