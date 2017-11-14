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
    public class UserRepository : GenericEfRepository<Account>, IUserRepository
    {
          public UserRepository(PicBookDbContext context) : base(context)
          {
          }


        public async Task<Account> FindByFacebookIdentifier(string userIdentifier)
        {
            var users = await FindAll(u => u.FacebookUserId.Equals(userIdentifier));
            return users.FirstOrDefault();
        }

        public async Task<Account> FindByIdentifier(Guid userIdendifier)
        {
            var users = await FindAll(a => a.Id.CompareTo(userIdendifier) == 0);
            return users.FirstOrDefault();
        }

        public override async Task<Account> GetById(Guid id)
        {
              return await Context.Set<Account>().FirstOrDefaultAsync(x => x.Id == id);
    }
    }
}
