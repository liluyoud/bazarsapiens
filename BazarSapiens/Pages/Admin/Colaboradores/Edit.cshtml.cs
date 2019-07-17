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

namespace BazarSapiens.Pages.Admin.Colaboradores
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
        public Colaborador Colaborador { get; set; }

        [BindProperty]
        public IFormFile Arquivo { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Colaborador = await _context.Colaboradores.FirstOrDefaultAsync(m => m.Id == id);
            if (Colaborador == null)
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
                    var nomeArquivo = Path.Combine(_ambiente.WebRootPath, "colaboradores", Colaborador.Id + extensao);
                    using (var stream = new FileStream(nomeArquivo, FileMode.Create))
                    {
                        Arquivo.CopyTo(stream);
                        stream.Close();
                    }

                    Colaborador.Foto = Colaborador.Id + extensao;
                }
                _context.Attach(Colaborador).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParceiroExists(Colaborador.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Edit", new { Id = Colaborador.Id });
        }

        private bool ParceiroExists(long id)
        {
            return _context.Colaboradores.Any(e => e.Id == id);
        }
    }   
}
