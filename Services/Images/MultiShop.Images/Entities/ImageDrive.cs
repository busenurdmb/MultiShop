using System.ComponentModel.DataAnnotations.Schema;

namespace MultiShop.Images.Entities
{
    public class ImageDrive
    {
        public int Id { get; set; }
        public string Title { get; set; }


        [NotMapped]
        public IFormFile Photo { get; set; }
        public string? SavedUrl { get; set; }

        [NotMapped]
        public string? SignedUrl { get; set; }
        public string? SavedFileName { get; set; }
    }
}
