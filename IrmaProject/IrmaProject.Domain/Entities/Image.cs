using IrmaProject.Domain.Entities.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace IrmaProject.Domain.Entities
{
    public class Image : Entity
    {
        public Guid BlobImageId { get; set; }
        public string Name { get; set; }
        public string OriginalSizeUrl { get; set; }
        public string WebSizeUrl { get; set; }
        public string MobileSizeUrl { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool Public { get; set; }
        public bool Deleted { get; set; }

        public Album Album { get; set; }
        public ICollection<Rating> Rating { get; set; }
    }
}
