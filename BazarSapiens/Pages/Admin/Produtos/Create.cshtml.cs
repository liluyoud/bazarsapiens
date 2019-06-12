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

namespace BazarSapiens.Pages.Admin.Produtos
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
            Categorias = new SelectList(_context.Categorias.ToList(), "Id", "Descricao");
            return Page();
        }

        [BindProperty]
        public Produto Produto { get; set; }

        public SelectList Categorias { set; get; }

        [BindProperty]
        public List<IFormFile> Arquivos { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Produtos.Add(Produto);
            await _context.SaveChangesAsync();
            int i = 0;
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
                    if (i == 1)
                    {
                        Produto.FotoPrincipal = Produto.Id + "-1" + extensao;
                    }
                }
            }
            Produto.TotalFotos = i;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}