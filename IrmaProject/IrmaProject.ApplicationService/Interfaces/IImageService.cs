using IrmaProject.Domain.Entities;
using IrmaProject.Dto.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IrmaProject.ApplicationService.Interfaces
{
    public interface IImageService
    {
        Task<ImageUploadResult> UploadImage(Guid albumId, byte[] imageBytes);
        Task<Guid> CreateAlbumWithUserId(Guid userId, string albumName);
        Task<Guid> AddImage(Image image);
        Task<Album> FindAlbumById(Guid albumId);
        Task<Album> FindAlbumByName(string albumName);
        Task<IEnumerable<Album>> GetAlbumsByUserId(Guid userId);
        Task<IEnumerable<Album>> GetAlbumsByUsername(string username);
        Task<int> GetAlbumFilesCountById(Guid albumId);
        Task<Dictionary<Guid, int>> GetAlbumsFilesCountByIds(IEnumerable<Guid> ids);
        Task<IEnumerable<Image>> GetImagesByAlbumId(Guid albumId);
        Task<IEnumerable<Image>> GetImagesByAlbumName(string albumName);
    }
}
