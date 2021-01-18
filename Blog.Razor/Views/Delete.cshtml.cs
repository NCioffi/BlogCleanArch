using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Blog.Core.Entities;
using Blog.Razor.Data;
using Blog.Core.Interfaces;

namespace Blog.Razor.Views
{
    public class DeleteModel : PageModel
    {
        private readonly IService<Post> _service;

        public DeleteModel(IService<Post> service)
        {
            _service = service;
        }

        [BindProperty]
        public Post Post { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = await _service.ObtenerPorId((int)id);

            if (Post == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

         

            if (Post != null)
            {
              await  _service.Borrar((int)id);
            }

            return RedirectToPage("./Index");
        }
    }
}
