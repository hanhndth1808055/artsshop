using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalArtsShop.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("Product")]
        public string ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }
        public string Message { get; set; }
        public int Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}