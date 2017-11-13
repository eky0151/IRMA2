using IrmaProject.Domain.Entities;
using IrmaProject.Repository.EntityFramework.Database;
using IrmaProject.Repository.EntityFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaProject.Repository.EntityFramework.Repositories
{
    public class UserRepository : GenericCrudRepository<Account>, IUserRepository
    {
        public UserRepository(PicBookDbContext context)
        {
            Context = context;
        }
        public Task Create(Account entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Account> FindByIdentifier(Guid userIdendifier)
        {
            var users = await FindAll(a => a.Id.CompareTo(userIdendifier) == 0);
            return users.FirstOrDefault();
        }
    }
}
