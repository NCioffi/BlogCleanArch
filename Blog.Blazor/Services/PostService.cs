
using Blog.Blazor.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Blog.Blazor.Services
{
    public class PostService : IPostService
    {
        private readonly HttpClient httpClient;

        public PostService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

    

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var _response  =  await httpClient.GetFromJsonAsync<Response<Post>>("/post");

            return (IEnumerable<Post>)_response;
        }
    }
}
