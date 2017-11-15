using IrmaProject.Domain.Entities;
using IrmaProject.Repository.EntityFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using IrmaProject.Repository.EntityFramework.Database;

namespace IrmaProject.Repository.EntityFramework.Repositories
{
    public class DbImageRepository : GenericEfRepository<Image>, IDbImageRepository
    {
        public DbImageRepository(PicBookDbContext context): base(context)
        {
        }

        public async Task<Guid> AddImage(Image image)
        {
            await Create(image);
            return image.Id;
        }
    }
}
