﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BazarSapiens.Models;

namespace BazarSapiens.Pages.Admin.Parceiros
{
    public class IndexModel : PageModel
    {
        private readonly BazarSapiens.Models.BazarContext _context;

        public IndexModel(BazarSapiens.Models.BazarContext context)
        {
            _context = context;
        }

        public IList<Parceiro> Parceiros { get;set; }

        public async Task OnGetAsync()
        {
            var bazar = _context.Bazares.OrderByDescending(b => b.Id).FirstOrDefault(b => b.Situacao != SituacaoBazar.Finalizado && b.Situacao != SituacaoBazar.Cancelado);
            Parceiros = await _context.Parceiros.Where(p => p.BazarId == bazar.Id).OrderBy(p => p.Ordem).ToListAsync();
        }
    }
}
