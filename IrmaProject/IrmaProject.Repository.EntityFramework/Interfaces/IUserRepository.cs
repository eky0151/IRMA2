using IrmaProject.Common.Constant;
using IrmaProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IrmaProject.Repository.EntityFramework.Interfaces
{
    public interface IUserRepository
    {
        Task<Account> FindByIdentifier(Guid userIdendifier);
        Task<Account> FindBySocialIdentifier(string userIdentifier);
        Task<Account> FindByName(string userName);
        Task<Account> FindByUserName(string userName);
        Task<Guid> CreateUser(Account account);
    }
}
