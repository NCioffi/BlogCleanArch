using Blog.Blazor.ViewModels;
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
        private string Url;
        public PostService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.Url = "/Posts";
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var response  =  await httpClient.GetFromJsonAsync<Response<Post>>(Url);

            return  (IEnumerable<Post>)response.Data;
        }
    }
}
