using AutoMapper;
using Blog.Core.DTOs;
using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Insfrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Post, PostDTO>();
            CreateMap<PostDTO, Post>();
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<UsuarioDTO, Usuario>();
        }
    }
}
