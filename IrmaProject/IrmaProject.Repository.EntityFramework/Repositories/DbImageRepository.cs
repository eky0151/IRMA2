using IrmaProject.Domain.Entities;
using IrmaProject.Repository.EntityFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using IrmaProject.Repository.EntityFramework.Database;
using Microsoft.EntityFrameworkCore;

namespace IrmaProject.Repository.EntityFramework.Repositories
{
    public class DbImageRepository : GenericEfRepository<Image>, IDbImageRepository
    {
        public DbImageRepository(PicBookDbContext context): base(context)
        {
        }

        public async Task<Guid> AddImage(Image image)
        {
            await Create(image);
            return image.Id;
        }

        public async Task<IEnumerable<Guid>> GetImageIdsByAlbumId(Guid albumId)
        {
            var imageIds = Context.Set<Image>().Include(x => x.Album).Where(x => x.Album.Id == albumId).Select(x => x.Id).ToList();
            return imageIds;

        }

        public async Task<IEnumerable<Image>> GetImagesByAlbumId(Guid albumId)
        {
            var images = Context.Set<Image>().Include(x => x.Album).Where(x => x.Album.Id == albumId).ToList();
            return images;
        }
    }
}
