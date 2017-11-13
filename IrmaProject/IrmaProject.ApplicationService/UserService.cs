using IrmaProject.ApplicationService.Interfaces;
using IrmaProject.Repository.EntityFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IrmaProject.ApplicationService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public Task EnsureUser(IReadOnlyCollection<Claim> claims)
        {
            throw new NotImplementedException();
        }
    }
}
