using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BazarSapiens.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace BazarSapiens.Pages.Admin.Bazares
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
        public Bazar Bazar { get; set; }

        [BindProperty]
        public IFormFile Arquivo { get; set; }

        public string Logotipo { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bazar = await _context.Bazares.FirstOrDefaultAsync(m => m.Id == id);
            if (Bazar == null)
            {
                return NotFound();
            }

            var diretorio = Path.Combine(_ambiente.WebRootPath, "bazares");
            var di = new DirectoryInfo(diretorio);
            foreach (var f in di.GetFiles())
            {
                if (f.Name.StartsWith(id + "."))
                {
                    Logotipo = f.Name;
                    break;
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bazar).State = EntityState.Modified;

            try
            {
              
                if (Arquivo.Length > 0)
                {
                    var extensao = Path.GetExtension(Arquivo.FileName);
                    var nomeArquivo = Path.Combine(_ambiente.WebRootPath, "bazares", Bazar.Id + extensao);
                    using (var stream = new FileStream(nomeArquivo, FileMode.Create))
                    {
                        Arquivo.CopyTo(stream);
                        stream.Close();
                    }
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BazarExists(Bazar.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Edit", new { Id = Bazar.Id });
        }

        private bool BazarExists(long id)
        {
            return _context.Bazares.Any(e => e.Id == id);
        }
    }   
}
