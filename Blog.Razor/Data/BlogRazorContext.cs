using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blog.Core.Entities;

namespace Blog.Razor.Data
{
    public class BlogRazorContext : DbContext
    {
        public BlogRazorContext (DbContextOptions<BlogRazorContext> options)
            : base(options)
        {
        }

        public DbSet<Blog.Core.Entities.Post> Post { get; set; }
    }
}
