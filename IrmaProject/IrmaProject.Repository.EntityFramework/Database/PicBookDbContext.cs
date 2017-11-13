using IrmaProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IrmaProject.Repository.EntityFramework.Database
{
    public class PicBookDbContext : DbContext
    {
        public DbSet<Account> Account { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public PicBookDbContext(DbContextOptions<PicBookDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
        }
    }
}
