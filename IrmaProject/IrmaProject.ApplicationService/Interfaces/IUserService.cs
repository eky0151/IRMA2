using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IrmaProject.ApplicationService.Interfaces
{
    public interface IUserService
    {
        Task EnsureUser(IReadOnlyCollection<Claim> claims);
    }
}
