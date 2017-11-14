using IrmaProject.Domain.Interfaces;
using IrmaProject.Repository.EntityFramework.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IrmaProject.Repository.EntityFramework.Repositories
{
  public abstract class GenericEfRepository<TEntity> : IGenericsEfRepository<TEntity> where TEntity : class
  {
        protected readonly PicBookDbContext Context;

        private bool _disposedValue;

        protected GenericEfRepository(PicBookDbContext ctx) =>
          Context = ctx ?? throw new ArgumentNullException(nameof(ctx));

        public async Task<IReadOnlyCollection<TEntity>> FindAll(Expression<Func<TEntity, bool>> filterExpression)
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public abstract Task<TEntity> GetById(Guid id);

        public virtual async Task<int> Count(Expression<Func<TEntity, bool>> predicate)
        {
          return predicate == null
            ? throw new ArgumentNullException(nameof(predicate))
            : await Context.Set<TEntity>().CountAsync(predicate);
        }

        public virtual async Task Create(TEntity entity)
        {
          if (entity == null)  throw new ArgumentNullException(nameof(entity));

          Context.Set<TEntity>().Attach(entity);
          Context.Set<TEntity>().Add(entity);
          await Context.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
          if (entity == null) throw new ArgumentNullException(nameof(entity));

          Context.Set<TEntity>().Attach(entity);
          Context.Entry(entity).State = EntityState.Modified;
          await Context.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
          if (entity == null)
          {
            throw new ArgumentNullException(nameof(entity));
          }

          Context.Set<TEntity>().Attach(entity);
          Context.Entry(entity).State = EntityState.Deleted;
          await Context.SaveChangesAsync();
        }

        public virtual async Task Delete(Guid id)
        {
          var entitiyToDelete = await GetById(id);
          await Delete(entitiyToDelete);
        }

        public async Task<IReadOnlyCollection<TEntity>> GetByFilter(Expression<Func<TEntity, bool>> filterExpression)
        {
          IQueryable<TEntity> entities = Context.Set<TEntity>();
          if (filterExpression != null)
          {
            entities = entities.Where(filterExpression);
          }

          return await entities.ToListAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
          if (!_disposedValue)
          {
            if (disposing)
            {
              Context.Dispose();
            }
            _disposedValue = true;
          }
        }

        public void Dispose()
        {
          Dispose(true);
          GC.SuppressFinalize(this);
        }
  }
}