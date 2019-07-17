using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BazarSapiens.Models;

namespace BazarSapiens.Pages.Admin.Colaboradores
{
    public class IndexModel : PageModel
    {
        private readonly BazarSapiens.Models.BazarContext _context;

        public IndexModel(BazarSapiens.Models.BazarContext context)
        {
            _context = context;
        }

        public IList<Colaborador> Colaboradores { get;set; }

        public async Task OnGetAsync()
        {
            var bazar = _context.Bazares.OrderByDescending(b => b.Id).FirstOrDefault(b => b.Situacao != SituacaoBazar.Finalizado && b.Situacao != SituacaoBazar.Cancelado);
            Colaboradores = await _context.Colaboradores.Where(c => c.BazarId == bazar.Id).OrderBy(c => c.Ordem).ToListAsync();
        }
    }
}
