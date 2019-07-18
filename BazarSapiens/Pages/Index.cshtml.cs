using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BazarSapiens.Models;
using Markdig;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BazarSapiens.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BazarContext _context;
        private readonly IHostingEnvironment _ambiente;

        public IndexModel(BazarContext context, IHostingEnvironment ambiente)
        {
            _context = context;
            _ambiente = ambiente;
        }

        public IEnumerable<Banner> Banners { get; set; }

        public string Regras { get; set; }

        public int Visualizacoes { get; set; }
        public int Lances { get; set; }
        public int Usuarios { get; set; }
        public int Produtos { get; set; }
        public int Parceiros { get; set; }

        public void OnGet()
        {
            var bazar = _context.Bazares.OrderByDescending(b => b.Id).FirstOrDefault(b => b.Situacao != SituacaoBazar.Finalizado && b.Situacao != SituacaoBazar.Cancelado);

            Banners = _context.Banners.OrderBy(b => b.Ordem).Where(b => b.BazarId == bazar.Id && b.Situacao == "Ativo");

            Regras = Markdown.ToHtml(bazar.Regras);

            Visualizacoes = _context.Produtos.Where(p => p.BazarId == bazar.Id).Sum(p => p.Visualizacoes);
            Lances = _context.Produtos.Where(p => p.BazarId == bazar.Id).Sum(p => p.QuantidadeLances);
            Usuarios = _context.Usuarios.Count();
            Produtos = _context.Produtos.Where(p => p.BazarId == bazar.Id).Count();
            Parceiros = _context.Parceiros.Where(p => p.BazarId == bazar.Id).Count();
        }
    }
}
