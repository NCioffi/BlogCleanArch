using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Blog.Core.Entities;
using Blog.Razor.Data;
using Blog.Core.Interfaces;

namespace Blog.Razor.Views
{
    public class CreateModel : PageModel
    {
        private readonly IService<Post> _service;

        public CreateModel(IService<Post>  service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Post Post { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           await _service.Agregar(Post);
           

            return RedirectToPage("./Index");
        }
    }
}
