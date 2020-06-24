using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FinalArtsShop.Models
{
    public class Product
    {
        public string Id { get; set; }
        [ForeignKey("Category")]
        [Display(Name = "Category ID")]
        [Required]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Display(Name = "Unit Price")]
        [Required]
        public double UnitPrice { get; set; }
        public double PromotionPrice { get; set; }
        public string Thumbnail { get; set; }
        public string Image { get; set; }
        [Required]
        public int Unit { get; set; }
        public int isNew { get; set; }
        public int isActive { get; set; } = 1;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int isFeature { get; set; }
        public int SellIndex { get; set; }

        public string GetDefaultThumbnail()
        {
            if (this.Thumbnail != null && this.Thumbnail.Length > 0)
            {
                var arrayThumbnail = this.Thumbnail.Split(',');
                if (arrayThumbnail.Length > 0)
                {
                    return ConfigurationManager.AppSettings["CloudinaryPrefix"] + arrayThumbnail[0];
                }
            }
            return ConfigurationManager.AppSettings["DefaultImage"];
        }

        public string[] GetThumbnails()
        {
            if (this.Thumbnail != null && this.Thumbnail.Length > 0)
            {
                var arrayThumbnail = this.Thumbnail.Split(',');
                if (arrayThumbnail.Length > 0)
                {
                    return arrayThumbnail;
                }
            }
            return new string[0];
        }

        public string[] GetThubnailIds()
        {
            var ids = new List<String>();
            var thumbnails = GetThumbnails();
            foreach (var thumb in thumbnails)
            {
                var splittedThumb = thumb.Split('/');
                if (splittedThumb.Length != 4)
                {
                    continue;
                }
                ids.Add(splittedThumb[3].Split('.')[0]);

            }
            return ids.ToArray();
        }
    }
}
