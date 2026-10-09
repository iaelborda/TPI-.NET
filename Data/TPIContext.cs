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
        public DbSet<Alquiler> Alquileres { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Tarifa> Tarifas { get; set; }

        public TPIContext(DbContextOptions<TPIContext> options)
            : base(options)
        {
        }

        internal TPIContext()
        {
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

            modelBuilder.Entity<Alquiler>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ClienteId)
                    .IsRequired()
                    .HasField("_clienteId");

                entity.Navigation(e => e.Cliente)
                    .HasField("_cliente");

                 entity.Property(e => e.EmpleadoId)
                    .IsRequired()
                    .HasField("_empleadoId");

                entity.Navigation(e => e.Empleado)
                    .HasField("_empleado"); 

                entity.Property(e => e.FechaAlquiler)
                    .IsRequired();

                entity.HasOne(e => e.Cliente)
                    .WithMany()
                    .HasForeignKey(e => e.ClienteId);

                entity.HasOne(e => e.Empleado)
                    .WithMany()
                    .HasForeignKey(e => e.EmpleadoId);

                entity.OwnsMany(e => e.DetallesAlquiler, detalle =>
                {
                    detalle.WithOwner().HasForeignKey(i => i.AlquilerId);

                    detalle.Property(i => i.BicicletaId)
                        .IsRequired()
                        .HasField("_bicicletaId");

                    detalle.Navigation(i => i.Bicicleta)
                        .HasField("_bicicleta");

                    detalle.Property(i => i.PrecioHora)
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    detalle.Property(i => i.Subtotal)
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    detalle.Property(i => i.HoraInicio)
                        .IsRequired();

                    detalle.Property(i => i.HoraFin)
                        .IsRequired(false);

                    detalle.HasOne(i => i.Bicicleta)
                        .WithMany()
                        .HasForeignKey(i => i.BicicletaId);
                });

            });

            modelBuilder.Entity<Empleado>(entity =>
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

                entity.Property(e => e.Legajo)
                    .IsRequired();

                entity.HasIndex(e => e.Documento)
                    .IsUnique();

                entity.HasIndex(e => e.Legajo)
                    .IsUnique();

                entity.Property(e => e.SucursalId)
                    .IsRequired()
                    .HasField("_sucursalId");

                entity.Navigation(e => e.Sucursal)
                    .HasField("_sucursal");

                entity.HasOne(e => e.Sucursal)
                    .WithMany()
                    .HasForeignKey(e => e.SucursalId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Tarifa>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id).ValueGeneratedOnAdd();
                entity.Property(t => t.PrecioHora).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(t => t.FechaDesde).IsRequired();
                entity.Property(t => t.FechaHasta).IsRequired(false);
                entity.Property(t => t.CategoriaId).IsRequired().HasField("_categoriaId");
                entity.HasOne(t => t.Categoria).WithMany(c => c.tarifas).HasForeignKey(t => t.CategoriaId).OnDelete(DeleteBehavior.Restrict);
                entity.Navigation(t => t.Categoria).HasField("_categoria");
            });


        }
    }
}