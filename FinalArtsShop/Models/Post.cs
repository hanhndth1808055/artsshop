using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalArtsShop.Models
{
    public class Post : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [AllowHtml]
        [Required]
        public string Body { get; set; }
        [Required]
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public int View { get; set; }
        public int Like { get; set; }

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