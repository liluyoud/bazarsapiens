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
using Markdig;
using BazarSapiens.Extensions;

namespace BazarSapiens.Pages
{
    public class SobreModel : PageModel
    {
        private readonly BazarSapiens.Models.BazarContext _context;

        public SobreModel(BazarSapiens.Models.BazarContext context)
        {
            _context = context;
        }

        public Bazar Bazar { get; set; }

        public IEnumerable<Colaborador> Colaboradores { get; set; }

        public string BazarDescricao { get; set; }

        public async Task OnGetAsync()
        {
            Bazar = _context.Bazares.OrderByDescending(b => b.Id).FirstOrDefault(b => b.Situacao != SituacaoBazar.Finalizado && b.Situacao != SituacaoBazar.Cancelado);
            BazarDescricao = Markdown.ToHtml(Bazar.Descricao).ReplaceFirst("<p>", "<p class='dropcaps'>");

            Colaboradores = await _context.Colaboradores.Where(c => c.BazarId == Bazar.Id).OrderBy(c => c.Ordem).ToListAsync();
        }

    }
}