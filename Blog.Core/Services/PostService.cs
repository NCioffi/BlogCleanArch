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
   public class PostService : IService<Post>
    {
        private readonly IContainer _container;
        

        public PostService(IContainer container)
        {
            this._container = container;
        }

   

        public async Task Agregar(Post entitiy)
        {
            // Agregar validacion si existe usuario
            var user = await _container.UserRepository.GetById(entitiy.IdUsuario);
            if (user == null)
            {
                throw new BusinessException("No existe el usuario.");
            }

            await _container.PostRepository.Add(entitiy);
            await _container.SaveChangesAsync();
        }
        public async Task<bool> Actualizar(Post entity)
        {
            var post = await _container.PostRepository.GetById(entity.Id);
            if (post == null)
            {
                return false;
            }
            post.Imagen = entity.Imagen;
            post.Descripcion = entity.Descripcion;

            _container.PostRepository.Update(entity);
             await _container.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Borrar(int id)
        {
            var post = await _container.PostRepository.GetById(id);
            if (post == null)
            {
                return false;
            }
            await _container.PostRepository.Delete(post);
            return true;
        }

        public async Task<bool> Existe(int id)
        {
            if ( await ObtenerPorId(id) == null) return false;

            return true;
        }

        public  async Task<Post> ObtenerPorId(int id)
        {
            return await _container.PostRepository.GetById(id);
        }

        public async Task<IEnumerable<Post>> ObtenerTodos()
        {
            
            var posts = await _container.PostRepository.GetAll();
            
            return posts;
        }


        public async Task<IEnumerable<Post>> ObtenerPorUsuario(int idUsuario)
        {

            var posts = await _container.PostRepository.GetPostsPorUsuario(idUsuario);

            return posts;
        }
    }
}
