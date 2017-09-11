using System;
namespace Api.Models.Domain.General
{
    public class Attachment
    {
        public string Filename { get; set; }
        public decimal FileSize { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Url { get; set; }
        public FileTypes Type { get; set; }
        public string Hash { get; set; }

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
