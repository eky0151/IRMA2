using IrmaProject.Domain.Entities;
using IrmaProject.Repository.EntityFramework.Database;
using IrmaProject.Repository.EntityFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IrmaProject.Repository.EntityFramework.Repositories
{
    public class AlbumRepository: GenericEfRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(PicBookDbContext context): base(context)
        {
        }

        public async Task<Guid> CreateAlbum(Album album)
        {
            await Create(album);
            return album.Id;
        }

        public async Task<Album> GetAlbumById(Guid albumId)
        {
            return await GetById(albumId);
        }

        public async Task<Album> GetAlbumByName(string name)
        {
            var resList = (await GetByFilter(x => x.UrlFriendlyName == name));
            if(resList.Count() == 0)
            {
                throw new ArgumentException();
            }
            return resList.First();
        }

        public async Task<IEnumerable<Album>> GetAlbumsByAccountId(Guid accountId)
        {
            var albums = Context.Set<Album>().Include(x => x.Account).ToList();
            var album = albums.Where(x => x.Account.Id.Equals(accountId)).ToList();
            return album;
        }

        public async Task<bool> UpdateAlbumModifiedDate(Guid albumId)
        {
            var album = (await GetByFilter(x => x.Id.Equals(albumId))).First();
            album.UpdatedAt = DateTime.Now;
            await Update(album);
            return true;
             
        }
    }
}
