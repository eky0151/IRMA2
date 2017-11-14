using System;
using System.Collections.Generic;
using System.Text;

namespace IrmaProject.Repository.AzureStorage.Model
{
    public class ImageUploadResult
    {
        public Guid ImageId { get; set; }
        public Uri ImageUri { get; set; }
    }
}
