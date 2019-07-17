using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BazarSapiens.Models;

namespace BazarSapiens.Pages.Admin.Produtos
{
    public class IndexModel : PageModel
    {
        private readonly BazarContext _context;

        public IndexModel(BazarContext context)
        {
            _context = context;
        }

        public IList<Produto> Produtos { get;set; }

        public async Task OnGetAsync()
        {
            Produtos = await _context.Produtos.ToListAsync();
        }
    }
}
