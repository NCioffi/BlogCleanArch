using Blog.Core.Entities;
using Blog.Core.Interfaces;
using Blog.Insfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Insfrastructure.Repositories
{
    public class PostRepository : BaseRepository<Post> , IPostRepository 
    {

        public PostRepository(BlogContext context) : base(context) { }


        public async Task<IEnumerable<Post>> GetPostsPorUsuario(int userId)
        {
            var posts = await GetAll((x => x.IdUsuario == userId));
            return posts;
        }

    }
       

     
}  

