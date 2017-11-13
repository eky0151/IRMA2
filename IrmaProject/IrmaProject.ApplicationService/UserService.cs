using IrmaProject.ApplicationService.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IrmaProject.ApplicationService
{
    public class UserService : IUserService
    {
        public UserService()
        {

        }
        public Task EnsureUser(IReadOnlyCollection<Claim> claims)
        {
            throw new NotImplementedException();
        }
    }
}
