using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BazarSapiens.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace BazarSapiens.Controllers
{
    [Authorize]
    [Route("api/Produtos")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly BazarContext _context;
        private readonly IHostingEnvironment _ambiente;

        public ProdutosController(BazarContext context, IHostingEnvironment ambiente)
        {
            _context = context;
            _ambiente = ambiente;
        }

        public async Task<bool> Get([FromQuery] string foto)
        {
            try
            {
                var nomeArquivo = Path.Combine(_ambiente.WebRootPath, "produtos", foto);
                System.IO.File.Delete(nomeArquivo);
            } catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
