using IrmaProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IrmaProject.ApplicationService.Interfaces
{
    public interface IUserService
    {
        Task<Guid> EnsureUser(IReadOnlyCollection<Claim> claims);
        Task<Account> GetAccountByClaimsIdentity(ClaimsPrincipal userClaimsPrincipal);
    }
}
