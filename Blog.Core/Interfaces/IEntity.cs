using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Core.Interfaces
{
    public interface IEntity
    {
        [Key]
         int Id { get; set; }
    }
}
