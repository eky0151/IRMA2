using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IrmaProject.Models
{
    public class ShowImagesViewModel: LayoutViewModel
    {
        public string AlbumId { get; set; }
        public IEnumerable<ImageViewModel> Images { get; set; }
    }
}
