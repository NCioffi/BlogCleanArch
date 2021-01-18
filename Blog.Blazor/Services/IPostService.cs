
using Blog.Blazor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Blazor.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetPosts();
    }
}
