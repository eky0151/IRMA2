using IrmaProject.ApplicationService.Interfaces;
using IrmaProject.Repository.EntityFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using IrmaProject.Domain.Entities;

namespace IrmaProject.ApplicationService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task EnsureUser(IReadOnlyCollection<Claim> claims)
        {
            var userIdentifier = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if(userIdentifier == null)
            {
                throw new ArgumentException();
            }
            var user = await userRepository.FindByFacebookIdentifier(userIdentifier.Value);
            if(user == null)
            {
                await userRepository.Create(new Account
                {
                    FacebookUserId = userIdentifier.Value,
                    Email = claims.First(x => x.Type == ClaimTypes.Email).Value,
                    FirstName = claims.First(x => x.Type == ClaimTypes.GivenName).Value,
                    LastName = claims.First(x => x.Type == ClaimTypes.Surname).Value
                });
            }
        }
    }
}
