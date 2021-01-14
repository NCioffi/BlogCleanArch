using AutoMapper;
using Blog.API.Responses;
using Blog.Core.DTOs;
using Blog.Core.Entities;
using Blog.Core.Interfaces;
using Blog.Insfrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IService<Usuario>  _service;
        private readonly IMapper _mapper;
        public UserController(IService<Usuario> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _service.ObtenerTodos();
            var usuariosDTO = _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
            var response = new ApiResponse<IEnumerable<UsuarioDTO>>(usuariosDTO);

            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await _service.ObtenerPorId(id);
            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
            var response = new ApiResponse<UsuarioDTO>(usuarioDTO);
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> AgregarUsuario(UsuarioDTO usuario)
        {
            var user = _mapper.Map<Usuario>(usuario);

            await _service.Agregar(user);

            var response = new ApiResponse<UsuarioDTO>(usuario);

            return Ok(response);
        }


        [HttpPut]
        public async Task<IActionResult> ActualizarUsuario(int id, UsuarioDTO usuario)
        {
            var user = _mapper.Map<Usuario>(usuario);
            user.Id = id;

            var result = await _service.Actualizar(user);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Borrar(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
