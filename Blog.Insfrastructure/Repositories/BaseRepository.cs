using Blog.Core.Interfaces;
using Blog.Insfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Blog.Insfrastructure.Repositories
{
   public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {

        private readonly BlogContext _context;
        protected readonly DbSet<TEntity> _entities;

        public BaseRepository(BlogContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        #region Metodos de busqueda

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null,
         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
         string includeProperties = null)
        {
            IQueryable<TEntity> query = _entities;

            if (filter != null)
            {
                query = query.Where(filter);
            }


            if (includeProperties != null)
            {

                foreach (var prop in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }

            }


            if (orderBy != null)
            {

                return await orderBy(query).ToListAsync();

            }

            return await query.ToListAsync();

        }

        public async Task<TEntity> GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<TEntity> query = _entities;

            if (filter != null)
            {
                query = query.Where(filter);
            }


            if (includeProperties != null)
            {

                foreach (var prop in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }

            }


            return await query.FirstOrDefaultAsync();

        }



        #endregion

        #region Metodos CRUD

        public async Task Add(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _entities.Update(entity);
        }

        public async Task Delete(int id)
        {
            TEntity entity = await GetById(id);
           await  Delete(entity);
        }
        public async Task Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }

        #endregion

    }
}
