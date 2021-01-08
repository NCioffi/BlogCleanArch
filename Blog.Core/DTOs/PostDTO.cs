using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Core.DTOs
{
   public class PostDTO
    {
        [Key]
        public int Id { get; set; }

        [RegularExpression("^\\d+$", ErrorMessage = "El Id de Usuario debe contener solo números.")]
        public int IdUsuario { get; set; }
        public DateTime? Fecha { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
    }
}
