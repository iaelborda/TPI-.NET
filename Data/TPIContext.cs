using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Domain.Model;

namespace Data
{
    public class TPIContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public TPIContext(DbContextOptions<TPIContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        internal TPIContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TipoDocumento)
                    .IsRequired();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasIndex(e => e.Email)
                    .IsUnique();

                entity.HasIndex(e => e.Documento)
                    .IsUnique();

                entity.Property(e => e.FechaAlta)
                    .IsRequired();
            });
        }
    }
}