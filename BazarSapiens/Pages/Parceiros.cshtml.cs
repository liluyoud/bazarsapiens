using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BazarSapiens.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BazarSapiens.Pages
{
    public class ParceirosModel : PageModel
    {

        private readonly BazarContext _context;
        private readonly IHostingEnvironment _ambiente;

        public ParceirosModel(BazarContext context, IHostingEnvironment ambiente)
        {
            _context = context;
            _ambiente = ambiente;
        }

        public IList<Parceiro> Parceiros { get; set; }

        public async Task OnGetAsync()
        {
            var bazar = _context.Bazares.OrderByDescending(b => b.Id).FirstOrDefault(b => b.Situacao != SituacaoBazar.Finalizado && b.Situacao != SituacaoBazar.Cancelado);
            Parceiros = await _context.Parceiros.Where(p => p.BazarId == bazar.Id).OrderBy(p => p.Ordem).ToListAsync();
        }
    }
}