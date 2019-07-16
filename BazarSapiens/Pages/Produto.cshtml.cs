using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BazarSapiens.Models;
using Markdig;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BazarSapiens.Pages
{
    public class ProdutoModel : PageModel
    {

        private readonly BazarContext _context;
        private readonly IHostingEnvironment _ambiente;

        public ProdutoModel(BazarContext context, IHostingEnvironment ambiente)
        {
            _context = context;
            _ambiente = ambiente;
        }

        [BindProperty]
        public Produto Produto { get; set; }

        public List<string> Fotos { get; set; }

        public string Descricao { get; set; }
        public string PessoaUltimoLance { get; set; }

        [BindProperty]
        public decimal Lance { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produto = await _context.Produtos.Include(p => p.Categoria).FirstOrDefaultAsync(m => m.Id == id);

            Descricao = Markdown.ToHtml(Produto.Descricao);

            Fotos = new List<string>();

            Lance = Produto.ValorAtual + Produto.ValorLance;

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.UserName == Produto.UsuarioUltimoLance);
            PessoaUltimoLance = usuario?.Nome;

            var diretorio = Path.Combine(_ambiente.WebRootPath, "produtos");
            var di = new DirectoryInfo(diretorio);

            // coloca a foto principal como o primeiro da lista
            if (Produto.FotoPrincipal != null)
                Fotos.Add(Produto.FotoPrincipal);
            foreach (var f in di.GetFiles())
            {
                if (f.Name.StartsWith(id + "-") && f.Name != Produto.FotoPrincipal)
                {
                    Fotos.Add(f.Name);
                }
            }

            Produto.Visualizacoes++;
            await _context.SaveChangesAsync();

            return Page();
        }
    }
}