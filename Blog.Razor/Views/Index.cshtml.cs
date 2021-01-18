using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Blog.Core.Entities;
using Blog.Razor.Data;

namespace Blog.Razor.Views
{
    public class IndexModel : PageModel
    {
        private readonly Blog.Razor.Data.BlogRazorContext _context;

        public IndexModel(Blog.Razor.Data.BlogRazorContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; }

        public async Task OnGetAsync()
        {
            Post = await _context.Post.ToListAsync();
        }
    }
}
