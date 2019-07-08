using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BazarSapiens.Models;
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

        public void OnGet()
        {
            Banners = _context.Banners.Where(b => b.Situacao == "Ativo");
        }
    }
}
