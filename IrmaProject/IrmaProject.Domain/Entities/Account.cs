using IrmaProject.Domain.Entities.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace IrmaProject.Domain.Entities
{
    public class Account : Entity
    {
        public string Email { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public string MobilNumber { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImageUrl { get; set; }
        public string FacebookUserId { get; set; }

        public ICollection<Album> Album { get; set; }
        public ICollection<Rating> Rating { get; set; }
    }
}
