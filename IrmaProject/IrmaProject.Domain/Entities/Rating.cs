using IrmaProject.Domain.Entities.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace IrmaProject.Domain.Entities
{
    public class Rating : Entity
    {
        public string Comment { get; set; }
        public double Value { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public Account Account { get; set; }
        public Image Image { get; set; }
    }
}
