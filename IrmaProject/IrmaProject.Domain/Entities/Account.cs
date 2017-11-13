﻿using IrmaProject.Domain.Entities.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace IrmaProject.Domain.Entities
{
    public class Account : Entity
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public string MobilNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImageUrl { get; set; }

        public ICollection<Album> Album { get; set; }
        public ICollection<Rating> Rating { get; set; }
    }
}