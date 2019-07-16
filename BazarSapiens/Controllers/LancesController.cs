using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BazarSapiens.Models;

namespace BazarSapiens.Controllers
{
    [Route("api/Lances")]
    [ApiController]
    public class LancesController : ControllerBase
    {
        private readonly BazarContext _context;

        public LancesController(BazarContext context)
        {
            _context = context;
        }

        public DadosLance Get([FromQuery] long produtoId, decimal valorLance, string usuario)
        {
            var retorno = new DadosLance();
            retorno.ProdutoId = produtoId;
            retorno.ValorLance = valorLance;
            retorno.Usuario = usuario;

            retorno.ValorAtual = 10;
            retorno.Id = 1;

            return retorno;
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
