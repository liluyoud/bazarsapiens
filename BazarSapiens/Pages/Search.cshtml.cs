using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BazarSapiens.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BazarSapiens.Pages
{
    public class SearchModel : PageModel
    {

        private readonly BazarContext _context;

        public SearchModel(BazarContext context)
        {
            _context = context;
        }

        public IList<SearchView> Objetos { get; set; } = new List<SearchView>();

        [BindProperty]
        public string Pesquisa { get; set; }

        public async Task OnPostAsync(string pesquisa)
        {
            Pesquisa = pesquisa;

            // pesquisa produtos
            var produtos = await _context.Produtos.Include(p => p.Categoria)
                .Where(p => p.Nome.IndexOf(pesquisa, StringComparison.OrdinalIgnoreCase) >= 0 || p.Descricao.IndexOf(pesquisa, StringComparison.OrdinalIgnoreCase) > 0)
                .OrderByDescending(p => p.Visualizacoes)
                .ThenByDescending(p => p.QuantidadeLances)
                .ThenByDescending(p => p.Nome)
                .ToListAsync();
            foreach (var item in produtos)
            {
                Objetos.Add(new SearchView()
                {
                    Id = item.Id,
                    Tipo = SearchObject.Produto,
                    Texto = item.Nome,
                    Subtexto = item.Categoria.Descricao + ";" +
                               item.Estado + ";" +
                               item.ValorInicial.ToString("0") + ";" +
                               item.ValorAtual.ToString("0") + ";" +
                               item.QuantidadeLances + ";" +
                               item.Visualizacoes + ";" +
                               item.TotalFotos,
                    Imagem = item.FotoPrincipal
                });
            }
        }


    }

    public class SearchView
    {
        public long Id { get; set; }
        public SearchObject Tipo { get; set; }
        public string Texto { get; set; }
        public string Subtexto { get; set; }
        public string Imagem { get; set; }
    }

    public enum SearchObject
    {
        Produto,
        Noticia,
        Parceiro,
        Colaborador,
        Video,
        Testemunho
    }
}
