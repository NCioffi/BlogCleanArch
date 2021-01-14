using Blog.Core.Entities;
using Blog.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services
{
    public class UserService : BaseService<Usuario>
    {

        public UserService(IContainer container, IRepository<Usuario> repository): base(container,repository)
        {
            
        }
        public  async override Task<bool> Actualizar(Usuario entity)
        {
            var user = await _repository.GetById(entity.Id);
            if (user == null)
            {
                return false;
            }
            user.Nombre = entity.Nombre;
            user.Apellido = entity.Apellido;
            user.Telefono = entity.Telefono;
            user.Activo = entity.Activo;

            _repository.Update(user);
            await _container.SaveChangesAsync();

            return true;
             
        }
    }
}
