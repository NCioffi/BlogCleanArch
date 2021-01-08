using Blog.Core.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace Blog.Core.Entities
{
    public  class Comentario :IEntity
    {
        public int Id { get; set; }
        public int IdPost { get; set; }
        public int IdUsuario { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }

        public virtual Usuario IdPost1 { get; set; }
        public virtual Post IdPostNavigation { get; set; }
    }
}
