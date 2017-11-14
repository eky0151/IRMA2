using IrmaProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IrmaProject.Repository.EntityFramework.Repositories;

namespace IrmaProject.Repository.EntityFramework.Interfaces
{
  public interface IAccountRepository : IGenericsEfRepository<Account>
  {
    Task<Account> GetUserByName(string username);

    Task<string> GetProfilPictureById(Guid id);

    Task<IReadOnlyCollection<Album>> GetAlbumsByUserId(Guid id);
  }
}
