using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BazarSapiens.Models;
using Markdig;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BazarSapiens.Pages
{
    public class NoticiasModel : PageModel
    {

        private readonly BazarContext _context;
        private readonly IHostingEnvironment _ambiente;

        public NoticiasModel(BazarContext context, IHostingEnvironment ambiente)
        {
            _context = context;
            _ambiente = ambiente;
        }

        public IList<Noticia> Noticias { get;set; }

        public async Task OnGetAsync()
        {
            Noticias = await _context.Noticias.ToListAsync();
        }
    }
}