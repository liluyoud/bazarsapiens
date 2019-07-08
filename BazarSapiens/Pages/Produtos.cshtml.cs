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
            Produtos = await _context.Produtos.ToListAsync();
            Categorias = await _context.Categorias.ToListAsync();
        }

    }
}