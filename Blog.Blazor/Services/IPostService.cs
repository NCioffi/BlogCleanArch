

using Blog.Blazor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Blazor.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetPosts();
    }
}
