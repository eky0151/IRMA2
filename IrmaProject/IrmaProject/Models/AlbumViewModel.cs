using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IrmaProject.Models
{
    public class AlbumViewModel : LayoutViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedAt { get; set; }
        public string ModifiedAt { get; set; }
        public int FilesCount { get; set; }
    }
}
