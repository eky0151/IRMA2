using IrmaProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IrmaProject.Common.Constant;

namespace IrmaProject.ApplicationService.Interfaces
{
    public interface IUserService
    {
        Task<Account> GetUserByName(string username);

        string GetProfilPictureById(Guid id, string sizeType);
        Task<Guid> EnsureUser(IReadOnlyCollection<Claim> claims);
        Account GetAccountByClaimsPrincipal(ClaimsPrincipal userClaimsPrincipal);
    }
}
