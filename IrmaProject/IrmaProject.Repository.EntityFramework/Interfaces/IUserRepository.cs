using IrmaProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IrmaProject.Repository.EntityFramework.Interfaces
{
    public interface IUserRepository
    {
        Task<Guid> Create(Account entity);
        Task<Account> FindByIdentifier(Guid userIdendifier);
        Task<Account> FindByFacebookIdentifier(string userIdentifier);
    }
}
