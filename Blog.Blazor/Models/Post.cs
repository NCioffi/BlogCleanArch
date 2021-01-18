using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Blazor.Models
{
    public class Post
    {
        public int Id { get; set; }

        public int IdUsuario { get; set; }
        public DateTime? Fecha { get; set; }

        public string Descripcion { get; set; }
        public string Imagen { get; set; }
    }
}
