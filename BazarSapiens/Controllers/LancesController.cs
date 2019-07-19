using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BazarSapiens.Models;
using Microsoft.AspNetCore.Authorization;

namespace BazarSapiens.Controllers
{
    [Authorize]
    [Route("api/Lances")]
    [ApiController]
    public class LancesController : ControllerBase
    {
        private readonly BazarContext _context;

        public LancesController(BazarContext context)
        {
            _context = context;
        }

        public async Task<DadosLance> Get([FromQuery] long produtoId, decimal valorLance, string usuario)
        {
            
            var dadosLance = new DadosLance();

            // verifica se existe o usuário e o produto
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.UserName == usuario);
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == produtoId);
            if (user != null && produto != null && valorLance > produto.ValorAtual)
            {
                // grava o lance no bd
                Lance lance = new Lance();
                lance.ProdutoId = produtoId;
                lance.Usuario = usuario;
                lance.Valor = valorLance;
                lance.DataHora = DateTime.Now;
                _context.Lances.Add(lance);

                // atualiza o produto
                produto.QuantidadeLances++;
                produto.ValorAtual = valorLance;
                produto.UsuarioUltimoLance = usuario;
                _context.Attach(produto).State = EntityState.Modified;

                // salva no banco de dados
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex) { }

                dadosLance.Id = lance.Id;
                dadosLance.ProdutoId = produtoId;
                dadosLance.ValorLance = valorLance;
                dadosLance.ValorAtual = valorLance;
                dadosLance.Usuario = user.Nome;
            }
            return dadosLance;
        }
    }

    public class DadosLance
    {
        public long Id { get; set; }
        public long ProdutoId { get; set; }
        public decimal ValorLance { get; set; }
        public decimal ValorAtual { get; set; }
        public string Usuario { get; set; }
    }
}
