using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Domain.Model;

namespace Data
{
    public class TPIContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Bicicleta> Bicicletas { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public TPIContext(DbContextOptions<TPIContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        internal TPIContext()
        {
            //Database.EnsureCreated();
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

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasIndex(e => e.Descripcion)
                    .IsUnique();

                entity.Ignore(e => e.Tarifas);

                entity.HasData(
                    new { Id = 1, Descripcion = "Urbana" },
                    new { Id = 2, Descripcion = "de Montaña" },
                    new { Id = 3, Descripcion = "Eléctrica" }
                );
            });

            modelBuilder.Entity<Bicicleta>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Estado)
                    .IsRequired();

                entity.Property(e => e.CategoriaId)
                    .IsRequired()
                    .HasField("_categoriaId");

                entity.Property(e => e.SucursalId)
                    .IsRequired()
                    .HasField("_sucursalId");

                entity.Navigation(e => e.Categoria)
                    .HasField("_categoria");

                entity.Navigation(e => e.Sucursal)
                    .HasField("_sucursal");

                entity.HasOne(e => e.Categoria)
                    .WithMany()
                    .HasForeignKey(e => e.CategoriaId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Sucursal)
                    .WithMany()
                    .HasForeignKey(e => e.SucursalId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Capacidad)
                    .IsRequired();

                entity.HasIndex(e => e.Nombre)
                    .IsUnique();
            });
            modelBuilder.Ignore<Tarifa>();
        }
    }
}