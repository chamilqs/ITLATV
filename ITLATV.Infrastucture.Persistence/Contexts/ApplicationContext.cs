using Microsoft.EntityFrameworkCore;
using ITLATV.Core.Domain.Entities;

namespace ITLATV.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Productora> Productoras { get; set; }
        public DbSet<Serie> Series { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Configuración de la tabla 'Genero'
            modelBuilder.Entity<Genero>(entity => {

                entity.ToTable("Generos");
                entity.HasKey(fk => fk.Id);
                entity.Property(g => g.Nombre)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.HasMany(g => g.Series)
                      .WithOne(s => s.Genero)
                      .HasForeignKey(g => g.GeneroPrimarioId)
                      .HasForeignKey(g => g.GeneroSecundarioId);
            });
            #endregion

            #region Configuración de la tabla 'Productora'
            modelBuilder.Entity<Productora>(entity => {

                entity.ToTable("Productoras");
                entity.HasKey(fk => fk.Id);
                entity.Property(p => p.Nombre)
                      .HasMaxLength(150)
                      .IsRequired();
                entity.HasMany(p => p.Series)
                      .WithOne(p => p.Productora)
                      .HasForeignKey(p => p.ProductoraId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
            #endregion

            #region Configuración de la tabla 'Serie'
            modelBuilder.Entity<Serie>(entity => {

                entity.ToTable("Series");
                entity.HasKey(fk => fk.Id);
                entity.Property(s => s.Nombre)
                      .HasMaxLength(150)
                      .IsRequired();
                entity.Property(s => s.EnlaceCaratula)
                      .IsRequired();
                entity.Property(s => s.EnlaceVideo)
                      .IsRequired();

            });
            #endregion
        }
    }
}
