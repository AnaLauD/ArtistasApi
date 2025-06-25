using Microsoft.EntityFrameworkCore;
using ArtistasApi.Models;

namespace Artistas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Artista> Artistas { get; set; }
        public DbSet<CategoriaArtista> CategoriasArtista { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaArtista>()
                .HasMany(c => c.Artistas)
                .WithOne(a => a.CategoriaArtista)
                .HasForeignKey(a => a.CategoriaArtistaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
