using Blog.Core.Entities;
using Blog.Core.Interfaces;
using Blog.Insfrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Blog.Core.Services
{
    public abstract class BaseService<TEntity> : IService<TEntity> where TEntity :  IEntity
    {
        protected readonly IContainer _container;
        protected readonly IRepository<TEntity> _repository;

        public BaseService(IContainer container, IRepository<TEntity> repository)
        {
            this._container = container;
            this._repository = repository;
            
        }

        public abstract   Task<bool> Actualizar(TEntity entity);
       
        public async Task Agregar(TEntity entitiy)
        {
           await  _repository.Add(entitiy);
           await _container.SaveChangesAsync();
        }

        public async Task<bool> Borrar(int id)
        {
            var entity = await ObtenerPorId(id);
            if (entity == null)
            {
                return false;
            }
            await _repository.Delete(entity);
            await _container.SaveChangesAsync();
            return true;
        }

        public async Task<TEntity> ObtenerPorId(int id)
        {
           return await  _repository.GetById(id);
        }

        public async  Task<IEnumerable<TEntity>> ObtenerTodos()
        {
            return await _repository.GetAll();
        }
    }
}
