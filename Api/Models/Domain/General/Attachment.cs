using System;
using System.ComponentModel.DataAnnotations;
using Api.Models.Domain.Tenant;

namespace Api.Models.Domain.General
{
    public class Attachment : TenantModel<int>
    {
        [Required]
        public string Filename { get; set; }

        [Required]
        public double FileSize { get; set; }

        [Url]
        public string ThumbnailUrl { get; set; }

        [Required, Url]
        public string Url { get; set; }

        public string Hash { get; set; }

        [Required]
        public FileTypes Type { get; set; }

        public enum FileTypes 
        {
            Image = 1,
            Pdf = 2,
            WordDocument = 3,
            ExcelDocument = 4,
            Text = 5,
            Html = 6,
            Code = 7,
            Video = 8
        }

        public Attachment()
        {
        }
    }
}
