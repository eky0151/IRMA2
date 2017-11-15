using IrmaProject.Domain.Entities;
using IrmaProject.Repository.EntityFramework.Database;
using IrmaProject.Repository.EntityFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IrmaProject.Common.Constant;

namespace IrmaProject.Repository.EntityFramework.Repositories
{
    public class UserRepository : GenericEfRepository<Account>, IUserRepository
    {
          public UserRepository(PicBookDbContext context) : base(context)
          {
          }

        public async Task<Guid> CreateUser(Account account)
        {
            await Create(account);
            return account.Id;
        }

        public async Task<Account> FindByFacebookIdentifier(string userIdentifier)
        {
            var users = await GetByFilter(u => u.FacebookUserId.Equals(userIdentifier));
            if (users.Count() == 0)
                return null;
            return users.FirstOrDefault();
        }

        public async Task<Account> FindByIdentifier(Guid userIdendifier)
        {
            var user = await GetById(userIdendifier);
            if (user == null)
                throw new ArgumentException();
            return user;
        }

        public async Task<Account> FindByName(string userName)
        {
            var users = await GetByFilter(x => x.Name.Equals(userName));
            if (users.Count() == 0)
                throw new ArgumentException();
            return users.First();
        }

        public async Task<string> GetProfilePictureById(Guid accountId, string pictureSizeType)
        {
            return (await FindByIdentifier(accountId)).ProfileImageUrl + pictureSizeType;
        }
    }
}
