using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
     
        Task<IEnumerable<T>> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
            );
        Task<T> GetFirstOrDefault(
          Expression<Func<T, bool>> filter = null,
          string includeProperties = null
          );
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        void Update(T entity);
        Task Delete(int id);

        Task Delete(T entity);
    }
}
