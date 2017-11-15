using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IrmaProject.Repository.EntityFramework.Repositories
{
  public interface IGenericsEfRepository<TEntity> : IDisposable where TEntity : class
  {
        Task<int> Count(Expression<Func<TEntity, bool>> predicate);
        Task Create(TEntity entity);
        Task Delete(TEntity entity);
        Task Delete(Guid id);
        Task<IReadOnlyCollection<TEntity>> FindAll(Expression<Func<TEntity, bool>> filterExpression);
        Task<IReadOnlyCollection<TEntity>> GetByFilter(Expression<Func<TEntity, bool>> filterExpression);
        Task<TEntity> GetById(Guid id);
        Task Update(TEntity entity);
  }
}
