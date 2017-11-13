﻿using IrmaProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IrmaProject.Repository.EntityFramework.Interfaces
{
    public interface IUserRepository
    {
        Task Create(Account entity);
        Task<Account> FindByIdentifier(Guid userIdendifier);
    }
}