using AlbumService.Models;
using Microsoft.EntityFrameworkCore;

namespace AlbumService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt ) : base(opt)
        {
            
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Artist>()
                .HasMany(ar => ar.Albums)
                .WithOne(ar=> ar.Artist!)
                .HasForeignKey(ar => ar.ArtistId);

            modelBuilder
                .Entity<Album>()
                .HasOne(al => al.Artist)
                .WithMany(al => al.Albums)
                .HasForeignKey(al =>al.ArtistId);
        }
    }
}