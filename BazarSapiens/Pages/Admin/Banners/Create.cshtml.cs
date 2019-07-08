using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BazarSapiens.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace BazarSapiens.Pages.Admin.Banners
{
    public class CreateModel : PageModel
    {
        private readonly BazarContext _context;
        private readonly IHostingEnvironment _ambiente;

        public CreateModel(BazarContext context, IHostingEnvironment ambiente)
        {
            _context = context;
            _ambiente = ambiente;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Banner Banner { get; set; }

        [BindProperty]
        public IFormFile Arquivo { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Banners.Add(Banner);
            await _context.SaveChangesAsync();

            if (Arquivo.Length > 0)
            {
                var extensao = Path.GetExtension(Arquivo.FileName);
                var nomeArquivo = Path.Combine(_ambiente.WebRootPath, "banners", Banner.Id + extensao);
                using (var stream = new FileStream(nomeArquivo, FileMode.Create))
                {
                    Arquivo.CopyTo(stream);
                    stream.Close();
                }

                Banner.Imagem = Banner.Id + extensao;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}