using Microsoft.EntityFrameworkCore;

namespace BazarSapiens.Models
{
    public class BazarContext: DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public BazarContext(DbContextOptions<BazarContext> options): base(options)
        {
        }
    }
}
