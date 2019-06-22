using Microsoft.EntityFrameworkCore;

namespace BazarSapiens.Models
{
    public class BazarContext: DbContext
    {
        public DbSet<Bazar> Bazares { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Parceiro> Parceiros { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Banner> Banners { get; set; }

        public BazarContext(DbContextOptions<BazarContext> options): base(options)
        {
        }
    }
}
