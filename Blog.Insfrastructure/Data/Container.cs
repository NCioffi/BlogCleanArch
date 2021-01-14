using Blog.Core.Entities;
using Blog.Core.Interfaces;
using Blog.Insfrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Insfrastructure.Data
{
    public class Container : IContainer 
    {

        protected readonly BlogContext _context;

        public Container(BlogContext context)
        {
            _context = context;
            PostRepository = new PostRepository(context);
            UserRepository = new BaseRepository<Usuario>(context);
            CommentRepository = new BaseRepository<Comentario>(context);
        }

        public IPostRepository PostRepository { get; private set; }
        public IRepository<Usuario> UserRepository { get; private set; }

        public IRepository<Comentario> CommentRepository { get; private set; }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        
    }
}
