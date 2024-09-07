using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.ImageDtos
{
    public class ResultImageDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? SignedUrl { get; set; }
        public string? SavedFileName { get; set; }
    }
}
