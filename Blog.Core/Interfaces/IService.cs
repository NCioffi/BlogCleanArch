using Blog.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Interfaces
{
    public interface IService<T> where T : IEntity
    {

        Task<T> ObtenerPorId(int id);

        Task<IEnumerable<T>> ObtenerTodos();

        Task Agregar(T entitiy);

        Task<bool> Actualizar(T entity);

        Task<bool> Borrar(int id);


    }
}
