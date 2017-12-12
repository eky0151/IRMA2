using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IrmaProject.Models
{
    public class ImageViewModel: LayoutViewModel
    {
        public string Name { get; set; }
        public string UrlFriendlyImageName { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string UploadedAt { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
    }
}
