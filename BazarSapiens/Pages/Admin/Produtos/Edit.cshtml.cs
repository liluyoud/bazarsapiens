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

namespace BazarSapiens.Pages.Admin.Produtos
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
        public Produto Produto { get; set; }

        public SelectList Categorias { set; get; }

        [BindProperty]
        public List<IFormFile> Arquivos { get; set; }

        public List<string> Fotos { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produto = await _context.Produtos.FirstOrDefaultAsync(m => m.Id == id);
            if (Produto == null)
            {
                return NotFound();
            }

            Categorias = new SelectList(_context.Categorias.ToList(), "Id", "Descricao");

            Fotos = new List<string>();

            var diretorio = Path.Combine(_ambiente.WebRootPath, "fotos");
            var di = new DirectoryInfo(diretorio);
            foreach (var f in di.GetFiles())
            {
                if (f.Name.StartsWith(id + "-"))
                {
                    Fotos.Add(f.Name);
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

            _context.Attach(Produto).State = EntityState.Modified;

            try
            {
                int i = Produto.TotalFotos;
                foreach (var arquivo in Arquivos)
                {
                    if (arquivo.Length > 0)
                    {
                        var extensao = Path.GetExtension(arquivo.FileName);
                        var nomeArquivo = Path.Combine(_ambiente.WebRootPath, "fotos", Produto.Id + "-" + ++i + extensao);
                        using (var stream = new FileStream(nomeArquivo, FileMode.Create))
                        {
                            arquivo.CopyTo(stream);
                            stream.Close();
                        }
                    }
                }
                Produto.TotalFotos = i;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(Produto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Edit", new { Id = Produto.Id });
        }

        private bool ProdutoExists(long id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }   
}
