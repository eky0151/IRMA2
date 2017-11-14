using IrmaProject.ApplicationService.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IrmaProject.Domain.Entities;
using IrmaProject.Repository.EntityFramework.Repositories;
using IrmaProject.Repository.EntityFramework.Database;

namespace IrmaProject.ApplicationService
{
    public class UserService : UserRepository, IUserService
    {

        public UserService(PicBookDbContext ctx) : base(ctx)
        { }

        public Task EnsureUser(IReadOnlyCollection<Claim> claims)
        {
            throw new NotImplementedException();
        }

       
    }
}
