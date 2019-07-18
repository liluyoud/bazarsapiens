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
using Microsoft.EntityFrameworkCore;

namespace BazarSapiens.Pages
{
    public class ProdutosModel : PageModel
    {
        private readonly BazarSapiens.Models.BazarContext _context;

        public ProdutosModel(BazarSapiens.Models.BazarContext context)
        {
            _context = context;
        }

        public IList<Produto> Produtos { get; set; }
        public IList<Categoria> Categorias { get; set; }

        public async Task OnGetAsync()
        {
            var bazar = _context.Bazares.OrderByDescending(b => b.Id).FirstOrDefault(b => b.Situacao != SituacaoBazar.Finalizado && b.Situacao != SituacaoBazar.Cancelado);

            Produtos = await _context.Produtos.Where(p => p.BazarId == bazar.Id).OrderByDescending(c => c.Visualizacoes).ToListAsync();
            Categorias = await _context.Categorias.Where(c => c.BazarId == bazar.Id).OrderBy(c => c.Descricao).ToListAsync();
        }

    }
}