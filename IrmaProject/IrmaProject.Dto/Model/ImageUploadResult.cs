using System;
using System.Collections.Generic;
using System.Text;

namespace IrmaProject.Dto.Model
{
    public class ImageUploadResult
    {
        public Guid ImageId { get; set; }
        public Uri ImageUri { get; set; }
    }
}
