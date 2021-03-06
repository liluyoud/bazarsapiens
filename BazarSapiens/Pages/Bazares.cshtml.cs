﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BazarSapiens.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BazarSapiens.Pages
{
    public class BazaresModel : PageModel
    {
        private readonly BazarSapiens.Models.BazarContext _context;

        public BazaresModel(BazarSapiens.Models.BazarContext context)
        {
            _context = context;
        }

        public IList<Bazar> Bazar { get; set; }

        public async Task OnGetAsync()
        {
            Bazar = await _context.Bazares.ToListAsync();
        }
    }
}