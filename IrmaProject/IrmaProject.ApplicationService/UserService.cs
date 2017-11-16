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
            var user = await userRepository.FindByFacebookIdentifier(userIdentifier.Value);
            if(user == null)
            {
                var newUserId = await userRepository.CreateUser(new Account
                {
                    Username = claims.First(x => x.Type == ClaimTypes.Email).Value.Replace('@','_').Replace('.','_'),
                    FacebookUserId = userIdentifier.Value,
                    Email = claims.First(x => x.Type == ClaimTypes.Email).Value,
                    Name = claims.First(x => x.Type == ClaimTypes.Name).Value,
                    FirstName = claims.First(x => x.Type == ClaimTypes.GivenName).Value,
                    LastName = claims.First(x => x.Type == ClaimTypes.Surname).Value,
                    ProfileImageUrl = @"https://graph.facebook.com/"+userIdentifier.Value+@"/picture"
                });
                return newUserId;
            }
            return user.Id;
        }

        public Account GetAccountByClaimsPrincipal(ClaimsPrincipal userClaimsPrincipal)
        {
            var identity = userClaimsPrincipal.Identities.FirstOrDefault(i => i.AuthenticationType == "Facebook" && i.IsAuthenticated);
            if (identity == null)
            {
                throw new ArgumentException();
            }
            var facebookId = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var user = userRepository.FindByFacebookIdentifier(facebookId).Result;
            if(user == null)
            {
                throw new ArgumentException();
            }
            return user;
        }

          public async Task<Account> GetUserByName(string username)
          {
            return await userRepository.FindByName(username);
          }

          public string GetProfilPictureById(Guid id, string sizeType)
          {
            var pictureUrl = userRepository.GetProfilePictureById(id, sizeType).Result;
            return pictureUrl;
          }
    }
}
