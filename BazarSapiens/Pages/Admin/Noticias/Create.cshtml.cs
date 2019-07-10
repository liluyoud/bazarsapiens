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

namespace BazarSapiens.Pages.Admin.Noticias
{
    public class CreateModel : PageModel
    {
        private readonly BazarContext _context;
        private readonly IHostingEnvironment _ambiente;

        public CreateModel(BazarContext context, IHostingEnvironment ambiente)
        {
            _context = context;
            _ambiente = ambiente;
            Noticia = new Noticia();
        }

        public IActionResult OnGet()
        {
            var agora = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            Noticia.DataPublicacao = DateTime.Parse(agora);
            Noticia.Autor = "Bazar da Solidariedade";

            return Page();
        }

        [BindProperty]
        public Noticia Noticia { get; set; }

        [BindProperty]
        public List<IFormFile> Arquivos { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // atualizar para quando tiver mais de 1 bazar acontecendo ao mesmo tempo
            var bazar = _context.Bazares.OrderByDescending(b => b.Id).FirstOrDefault(b => b.Situacao != SituacaoBazar.Finalizado && b.Situacao != SituacaoBazar.Cancelado);
            if (bazar != null)
                Noticia.BazarId = bazar.Id;

            _context.Noticias.Add(Noticia);
            await _context.SaveChangesAsync();
            int i = 0;
            foreach (var arquivo in Arquivos)
            {
                if (arquivo.Length > 0)
                {
                    var extensao = Path.GetExtension(arquivo.FileName); 
                    var nomeArquivo = Path.Combine(_ambiente.WebRootPath, "noticias", Noticia.Id + "-" + ++i + extensao);
                    using (var stream = new FileStream(nomeArquivo, FileMode.Create))
                    {
                        arquivo.CopyTo(stream);
                        stream.Close();
                    }
                    if (i == 1)
                    {
                        Noticia.FotoPrincipal = Noticia.Id + "-1" + extensao;
                    }
                }
            }
            Noticia.TotalFotos = i;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}