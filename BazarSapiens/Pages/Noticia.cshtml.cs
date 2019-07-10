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
    public class NoticiaModel : PageModel
    {

        private readonly BazarContext _context;
        private readonly IHostingEnvironment _ambiente;

        public NoticiaModel(BazarContext context, IHostingEnvironment ambiente)
        {
            _context = context;
            _ambiente = ambiente;
        }

        [BindProperty]
        public Noticia Noticia { get; set; }

        public List<string> Fotos { get; set; }

        public string[] Tags { get; set; }

        public string Corpo { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Noticia = await _context.Noticias.FirstOrDefaultAsync(m => m.Id == id);

            if (Noticia == null)
            {
                return NotFound();
            }

            Corpo = Markdown.ToHtml(Noticia.Corpo);

            Tags = Noticia.Tags?.Split(",");

            Fotos = new List<string>();

            var diretorio = Path.Combine(_ambiente.WebRootPath, "noticias");
            var di = new DirectoryInfo(diretorio);

            // coloca a foto principal como o primeiro da lista
            if (Noticia.FotoPrincipal != null)
                Fotos.Add(Noticia.FotoPrincipal);
            foreach (var f in di.GetFiles())
            {
                if (f.Name.StartsWith(id + "-") && f.Name != Noticia.FotoPrincipal)
                {
                    Fotos.Add(f.Name);
                }
            }

            Noticia.Visualizacoes++;
            await _context.SaveChangesAsync();

            return Page();
        }
    }
}