using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalArtsShop.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string Message { get; set; }
        public string Link { get; set; }
        public int Seen { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}