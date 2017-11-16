using IrmaProject.Domain.Entities;
using IrmaProject.Repository.EntityFramework.Database;
using IrmaProject.Repository.EntityFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

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
            return (await FindAll(x => x.Name.Equals(name))).First();
        }

        public async Task<IEnumerable<Album>> GetAlbumsByAccountId(Guid accountId)
        {
            return await FindAll(x => x.Account.Id.Equals(accountId));
        }
    }
}
