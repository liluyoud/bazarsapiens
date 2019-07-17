using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BazarSapiens.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BazarSapiens.Pages
{
    [Authorize]
    public class LancesModel : PageModel
    {
        private readonly BazarContext _context;

        public LancesModel(BazarContext context)
        {
            _context = context;
        }

        public IList<LanceView> Lances { get; set; } = new List<LanceView>();

        public long? ProdutoId { get; set; }

        public async Task OnGetAsync(long? id)
        {
            ProdutoId = id;

            var lances = await _context.Lances.Where(l => l.ProdutoId == id)
                .OrderByDescending(l => l.Valor)
                .ThenByDescending(l => l.Id)
                .ToListAsync();

            foreach (var item in lances)
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.UserName == item.Usuario);
                Lances.Add(new LanceView()
                {
                    Cpf = item.Usuario,
                    Nome = usuario.Nome,
                    Valor = item.Valor,
                    DataHora = item.DataHora
                });
            }
        }
    }

    public class LanceView
    {
        public String Cpf { get; set; }
        public String Nome { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHora { get; set; }

    }
}
