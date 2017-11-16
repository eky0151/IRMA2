using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IrmaProject.Models
{
    public class ShowAlbumsViewModel : LayoutViewModel
    {
        public Guid Userid { get; set; }
        public IEnumerable<AlbumViewModel> Albums { get; set; }
    }
}
