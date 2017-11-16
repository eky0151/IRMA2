using IrmaProject.Domain.Entities.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace IrmaProject.Domain.Entities
{
    public class Album : Entity
    {
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public string Name { get; set; }
        public string UrlFriendlyName { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public Account Account { get; set; }
        public ICollection<Image> Image { get; set; }
    }
}
