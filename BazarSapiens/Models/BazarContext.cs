using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazarSapiens.Models
{
    public class BazarContext: DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }

        public BazarContext(DbContextOptions<BazarContext> options): base(options)
        {
        }
    }
}
