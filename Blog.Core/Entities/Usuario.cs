using Blog.Core.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace Blog.Core.Entities
{
    public  class Usuario : IEntity
    {
        public Usuario()
        {
            Comentarios = new HashSet<Comentario>();
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
