using IrmaProject.Domain.Entities;
using IrmaProject.Repository.EntityFramework.Database;
using IrmaProject.Repository.EntityFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IrmaProject.Repository.EntityFramework.Repositories
{
    public class UserRepository : GenericEfRepository<Account>, IAccountRepository
    {
        public UserRepository(PicBookDbContext ctx)
          : base(ctx)
        {
        }

        public async Task<string> GetProfilPictureById(Guid id)
        {
          var profil = await GetById(id);
          return profil.ProfileImageUrl;
        }

        public async Task<IReadOnlyCollection<Album>> GetAlbumsByUserId(Guid id)
        {
          var profil = await GetById(id);
          return profil.Album.ToList();
        }

        public async Task<Account> GetUserByName(string username)
        {
          return await Context.Set<Account>().FindAsync(username);
        }

        public override async Task<Account> GetById(Guid id)
        {
          return await Context.Set<Account>().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
