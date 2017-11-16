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
        public string Width { get; set; }
        public string Height { get; set; }
        public string UploadedAt { get; set; }
    }
}
