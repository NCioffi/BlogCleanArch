using Blog.Core.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace Blog.Core.Entities
{
    public  class Post : IEntity
    {
        public Post()
        {
            Comentarios = new HashSet<Comentario>();
        }

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public DateTime? Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}
