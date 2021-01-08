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
    public class PostController : ControllerBase
    {
        private readonly IService<Post> _postService;
        private readonly IMapper _mapper;
        public PostController(IService<Post> postService,IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetPosts() 
        {
            var posts = await _postService.ObtenerTodos();
            var postsDto = _mapper.Map<IEnumerable<PostDTO>>(posts);
            var response = new ApiResponse<IEnumerable<PostDTO>>(postsDto);

            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postService.ObtenerPorId(id);
            var postDto = _mapper.Map<PostDTO>(post);
            var response = new ApiResponse<PostDTO>(postDto);
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Post(PostDTO postDto)
        {
            var post = _mapper.Map<Post>(postDto);

            await _postService.Agregar(post);

            postDto = _mapper.Map<PostDTO>(post);
           
            return Ok(postDto);
        }


        [HttpPut]
        public async Task<IActionResult> Put(int id, PostDTO postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            post.Id = id;

            var result = await  _postService.Actualizar(post);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _postService.Borrar(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
