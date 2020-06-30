using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalArtsShop.Models
{
    public class Follower : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Mail { get; set; }
    }
}