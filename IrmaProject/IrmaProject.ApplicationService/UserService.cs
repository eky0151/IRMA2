using IrmaProject.ApplicationService.Interfaces;
using IrmaProject.Repository.EntityFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using IrmaProject.Domain.Entities;
using IrmaProject.Common.Constant;
using System.Text.RegularExpressions;

namespace IrmaProject.ApplicationService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<Guid> EnsureUser(IReadOnlyCollection<Claim> claims)
        {
            var userIdentifier = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if(userIdentifier == null)
            {
                throw new ArgumentException();
            }
            var user = await userRepository.FindBySocialIdentifier(userIdentifier.Value);
            if(user == null)
            {
                var newUserId = await userRepository.CreateUser(new Account
                {
                    Username = claims.First(x => x.Type == ClaimTypes.Email).Value.Replace('@','_').Replace('.','_').Replace(' ','_'),
                    SocialUserId = userIdentifier.Value,
                    Email = claims.First(x => x.Type == ClaimTypes.Email).Value,
                    Name = claims.First(x => x.Type == ClaimTypes.Name).Value,
                    FirstName = claims.First(x => x.Type == ClaimTypes.GivenName).Value,
                    LastName = claims.First(x => x.Type == ClaimTypes.Surname).Value,
                    Deleted = false
                });
                return newUserId;
            }
            return user.Id;
        }

        public Account GetAccountByClaimsPrincipal(ClaimsPrincipal userClaimsPrincipal)
        {
            var fbIdentity = userClaimsPrincipal.Identities.FirstOrDefault(i => i.AuthenticationType == "Facebook" && i.IsAuthenticated);
            var googleIdentity = userClaimsPrincipal.Identities.FirstOrDefault(i => i.AuthenticationType == "Google" && i.IsAuthenticated);
            Account user = null;
            if(fbIdentity != null)
            {
                var facebookId = fbIdentity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                user = userRepository.FindBySocialIdentifier(facebookId).Result;
            }
            if(googleIdentity != null)
            {
                var googleId = googleIdentity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                user = userRepository.FindBySocialIdentifier(googleId).Result;
            }
            if (user == null)
            {
                throw new ArgumentException();
            }
            return user;
        }

          public async Task<Account> GetUserByName(string username)
          {
            return await userRepository.FindByName(username);
          }
    }
}
