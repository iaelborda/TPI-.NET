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
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Pago> Pagos { get; set; }

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

                entity.HasData(
                    new Cliente(1, "36111222", TipoDocumento.DNI, "Lucia", "Perez", "3414001001", "lucia@gmail.com", new DateOnly(2026, 1, 10)),
                    new Cliente(2, "40222333", TipoDocumento.DNI, "Martin", "Gomez", "3414001002", "martin@gmail.com", new DateOnly(2026, 2, 15))
                );
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

                entity.HasData(
                    new { Id = 1, Marca = "Venzo", Modelo = "Raptor", Estado = EstadoBicicleta.Disponible, CategoriaId = 1, SucursalId = 1 },
                    new { Id = 2, Marca = "TopMega", Modelo = "City", Estado = EstadoBicicleta.Disponible, CategoriaId = 2, SucursalId = 1 },
                    new { Id = 3, Marca = "Volta", Modelo = "E-Bike", Estado = EstadoBicicleta.Disponible, CategoriaId = 3, SucursalId = 2 }
                );
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

                entity.HasData(
                    new { Id = 1, Nombre = "BiciMania", Direccion = "Mitre 1200", Telefono = "3414001000", Capacidad = 20 },
                    new { Id = 2, Nombre = "Bicicletas Ya!", Direccion = "Zeballos 1500", Telefono = "3414002000", Capacidad = 15 }
                );
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

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.IdPago);
                entity.Property(e => e.IdPago).ValueGeneratedOnAdd();
                entity.Property(e => e.IdAlquiler).IsRequired();
                entity.Property(e => e.FechaPago).IsRequired();
                entity.Property(e => e.Monto).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(e => e.Metodo).IsRequired();
                entity.HasIndex(e => e.IdAlquiler).IsUnique();
                entity.HasOne<Alquiler>().WithOne().HasForeignKey<Pago>(e => e.IdAlquiler).OnDelete(DeleteBehavior.Restrict);
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

                entity.HasData(
                    new Empleado(1, "30111222", TipoDocumento.DNI, "Ana", "Lopez", "3414001010", 1001, 1),
                    new Empleado(2, "30222333", TipoDocumento.DNI, "Juan", "Diaz", "3414001011", 1002, 2)
                );
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
                entity.HasData(
                    new { Id = 1, PrecioHora = 1500m, FechaDesde = new DateTime(2026, 1, 1), FechaHasta = (DateTime?)null, CategoriaId = 1 },
                    new { Id = 2, PrecioHora = 2500m, FechaDesde = new DateTime(2026, 1, 1), FechaHasta = (DateTime?)null, CategoriaId = 2 },
                    new { Id = 3, PrecioHora = 3500m, FechaDesde = new DateTime(2026, 1, 1), FechaHasta = (DateTime?)null, CategoriaId = 3 }
                );
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FechaCreacion)
                    .IsRequired();

                entity.Property(e => e.Activo)
                    .IsRequired();

                // Restricciones únicas
                entity.HasIndex(e => e.Username)
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .IsUnique();

                // Usuarios iniciales
                var adminUser = new Domain.Model.Usuario(1, "admin", "admin@tpi.com", "admin123", DateTime.Now, RolUsuario.Administrador);
                var empleadoUser = new Domain.Model.Usuario(2, "empleado", "empleado@tpi.com", "empleado123", DateTime.Now, RolUsuario.Usuario);

                entity.HasData(
                    new
                    {
                        Id = adminUser.Id,
                        Username = adminUser.Username,
                        Email = adminUser.Email,
                        PasswordHash = adminUser.PasswordHash,
                        Salt = adminUser.Salt,
                        FechaCreacion = adminUser.FechaCreacion,
                        Rol = RolUsuario.Administrador,
                        Activo = adminUser.Activo
                    },
                    new
                    {
                        Id = empleadoUser.Id,
                        Username = empleadoUser.Username,
                        Email = empleadoUser.Email,
                        PasswordHash = empleadoUser.PasswordHash,
                        Salt = empleadoUser.Salt,
                        FechaCreacion = empleadoUser.FechaCreacion,
                        Rol = RolUsuario.Usuario,
                        Activo = empleadoUser.Activo
                    }
                );
            });
        }
    }
}