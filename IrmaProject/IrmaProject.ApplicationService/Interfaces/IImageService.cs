using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IrmaProject.ApplicationService.Interfaces
{
    public interface IImageService
    {
        Task<Uri> UploadImage(byte[] imageBytes);
        Task<Guid> CreateAlbumWithUserId(Guid userId, string albumName);
    }
}
