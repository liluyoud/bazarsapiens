using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BazarSapiens.Models
{
    public class BazarContext: IdentityDbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Bazar> Bazares { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Parceiro> Parceiros { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Lance> Lances { get; set; }
        public DbSet<Testemunho> Testemunhos { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }

        public BazarContext(DbContextOptions<BazarContext> options): base(options)
        {
        }
    }
}
