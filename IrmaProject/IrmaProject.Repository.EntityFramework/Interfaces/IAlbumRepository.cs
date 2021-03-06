﻿using IrmaProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IrmaProject.Repository.EntityFramework.Interfaces
{
    public interface IAlbumRepository
    {
        Task<Guid> CreateAlbum(Album album);
        Task<Album> GetAlbumById(Guid albumId);
        Task<Album> GetAlbumByName(string name);
        Task<IEnumerable<Album>> GetAlbumsByAccountId(Guid accountId);
        Task<bool> UpdateAlbumModifiedDate(Guid albumId);
    }
}
