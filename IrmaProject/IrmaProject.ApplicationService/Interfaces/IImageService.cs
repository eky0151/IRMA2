using IrmaProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IrmaProject.ApplicationService.Interfaces
{
    public interface IImageService
    {
        Task<Uri> UploadImage(Guid albumId, byte[] imageBytes);
        Task<Guid> CreateAlbumWithUserId(Guid userId, string albumName);
        Task<Album> FindAlbumById(Guid albumId);
        Task<IEnumerable<Album>> GetAlbumsByUserId(Guid userId);
    }
}
