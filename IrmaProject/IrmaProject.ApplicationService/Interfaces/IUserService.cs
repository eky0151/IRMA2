using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IrmaProject.Domain.Entities;

namespace IrmaProject.ApplicationService.Interfaces
{
    public interface IUserService
    {
        Task EnsureUser(IReadOnlyCollection<Claim> claims);

        Task<Account> GetUserByName(string username);

        Task<string> GetProfilPictureById(Guid id);

        Task<IReadOnlyCollection<Album>> GetAlbumsByUserId(Guid id);
  }
}
