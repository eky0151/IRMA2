using IrmaProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IrmaProject.Repository.EntityFramework.Interfaces
{
    public interface IDbImageRepository
    {
        Task<Guid> AddImage(Image image);
        Task<IEnumerable<Guid>> GetImageIdsByAlbumId(Guid albumId);
        Task<IEnumerable<Image>> GetImagesByAlbumId(Guid albumId);
    }
}
