using Blog.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Insfrastructure.Validations
{
    public class PostValidations : AbstractValidator<PostDTO>
    {
        public PostValidations()
        {
            RuleFor(post => post.Descripcion)
                    .NotNull()
                    .Length(15, 1000);

            RuleFor(post => post.Fecha)
                   .NotNull();
                  
        }

    }
}
