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
    public class MeusLancesModel : PageModel
    {
        private readonly BazarContext _context;

        public MeusLancesModel(BazarContext context)
        {
            _context = context;
        }

        public IList<MeuLanceView> Lances { get; set; } = new List<MeuLanceView>();

        public async Task OnGetAsync(string id)
        {
            if (id == null) // meus lances
            {
                id = User.Identity.Name;
            } else if (!User.IsInRole("Administradores"))
            {
                id = User.Identity.Name;
            }

            var lances = from lance in _context.Lances.Where(l => l.Usuario == id)
                         group lance by lance.ProdutoId into novoGrupo
                         orderby novoGrupo.Key
                         select novoGrupo;


            foreach (var item in lances)
            {
                var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == item.Key);
                var meuLance = new MeuLanceView();
                meuLance.ProdutoId = item.Key;
                meuLance.ProdutoNome = produto.Nome;
                meuLance.UltimoLanceId = item.Max(l => l.Id);
                meuLance.UltimoLanceValor = item.Max(l => l.Valor);
                meuLance.UltimoLanceDataHora = item.Max(l => l.DataHora);
                meuLance.Ganhando = (meuLance.UltimoLanceValor == produto.ValorAtual);
                Lances.Add(meuLance);
            }
        }
    }

    public class MeuLanceView
    {
        public long? ProdutoId { get; set; }
        public String ProdutoNome { get; set; }
        public long UltimoLanceId { get; set; }
        public decimal UltimoLanceValor { get; set; }
        public DateTime UltimoLanceDataHora { get; set; }
        public bool Ganhando { get; set; }

    }
}
