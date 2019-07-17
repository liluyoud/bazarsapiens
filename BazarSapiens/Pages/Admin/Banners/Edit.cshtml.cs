using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BazarSapiens.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace BazarSapiens.Pages.Admin.Banners
{
    public class EditModel : PageModel
    {
        private readonly BazarContext _context;
        private readonly IHostingEnvironment _ambiente;

        public EditModel(BazarContext context, IHostingEnvironment ambiente)
        {
            _context = context;
            _ambiente = ambiente;
        }

        [BindProperty]
        public Banner Banner { get; set; }

        [BindProperty]
        public IFormFile Arquivo { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Banner = await _context.Banners.FirstOrDefaultAsync(m => m.Id == id);

            if (Banner == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                if (Arquivo?.Length > 0)
                {
                    var extensao = Path.GetExtension(Arquivo.FileName);
                    var nomeArquivo = Path.Combine(_ambiente.WebRootPath, "banners", Banner.Id + extensao);
                    using (var stream = new FileStream(nomeArquivo, FileMode.Create))
                    {
                        Arquivo.CopyTo(stream);
                        stream.Close();
                    }

                    Banner.Imagem = Banner.Id + extensao;

                }

                _context.Attach(Banner).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BannerExists(Banner.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Edit", new { Id = Banner.Id });
        }

        private bool BannerExists(long id)
        {
            return _context.Banners.Any(e => e.Id == id);
        }
    }   
}
