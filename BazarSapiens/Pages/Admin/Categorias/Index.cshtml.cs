﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BazarSapiens.Models;

namespace BazarSapiens.Pages.Admin.Categorias
{
    public class IndexModel : PageModel
    {
        private readonly BazarSapiens.Models.BazarContext _context;

        public IndexModel(BazarSapiens.Models.BazarContext context)
        {
            _context = context;
        }

        public IList<Categoria> Categorias { get;set; }

        public async Task OnGetAsync()
        {
            Categorias = await _context.Categorias.ToListAsync();
        }
    }
}
