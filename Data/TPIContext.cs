using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
                    new Cliente(2, "40222333", TipoDocumento.DNI, "Martin", "Gomez", "3414001002", "martin@gmail.com", new DateOnly(2026, 2, 15)),
                    new Cliente(3, "38333444", TipoDocumento.DNI, "Maria", "Rossi", "3414001003", "maria.rossi@gmail.com", new DateOnly(2026, 3, 1)),
                    new Cliente(4, "42555666", TipoDocumento.DNI, "Julian", "Alvarez", "3414001004", "julian.alvarez@gmail.com", new DateOnly(2026, 3, 20)),
                    new Cliente(5, "39777888", TipoDocumento.DNI, "Valentina", "Diaz", "3414001005", "valen.diaz@gmail.com", new DateOnly(2026, 4, 12)),
                    new Cliente(6, "37999000", TipoDocumento.DNI, "Facundo", "Romero", "3414001006", "facu.romero@gmail.com", new DateOnly(2026, 5, 5)),
                    new Cliente(7, "41111222", TipoDocumento.DNI, "Camila", "Benitez", "3414001007", "camila.b@gmail.com", new DateOnly(2026, 6, 18)),
                    new Cliente(8, "43333444", TipoDocumento.DNI, "Nicolas", "Herrera", "3414001008", "nico.herrera@gmail.com", new DateOnly(2026, 7, 22))
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
                    new { Id = 3, Descripcion = "Eléctrica" },
                    new { Id = 4, Descripcion = "Paseo" },
                    new { Id = 5, Descripcion = "Plegable" }
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
                    new { Id = 3, Marca = "Volta", Modelo = "E-Bike", Estado = EstadoBicicleta.Disponible, CategoriaId = 3, SucursalId = 2 },
                    new { Id = 4, Marca = "Trek", Modelo = "Marlin 5", Estado = EstadoBicicleta.Disponible, CategoriaId = 2, SucursalId = 2 },
                    new { Id = 5, Marca = "Raleigh", Modelo = "Mojave 2.0", Estado = EstadoBicicleta.EnUso, CategoriaId = 2, SucursalId = 1 },
                    new { Id = 6, Marca = "Specialized", Modelo = "Rockhopper", Estado = EstadoBicicleta.Disponible, CategoriaId = 2, SucursalId = 3 },
                    new { Id = 7, Marca = "Olmo", Modelo = "Amelie", Estado = EstadoBicicleta.Disponible, CategoriaId = 4, SucursalId = 3 },
                    new { Id = 8, Marca = "SLP", Modelo = "50 Pro", Estado = EstadoBicicleta.EnUso, CategoriaId = 1, SucursalId = 2 },
                    new { Id = 9, Marca = "Scott", Modelo = "Aspect 950", Estado = EstadoBicicleta.Disponible, CategoriaId = 2, SucursalId = 4 },
                    new { Id = 10, Marca = "Aurora", Modelo = "Folding", Estado = EstadoBicicleta.Disponible, CategoriaId = 5, SucursalId = 4 },
                    new { Id = 11, Marca = "Vairo", Modelo = "XR 3.8", Estado = EstadoBicicleta.EnMantenimiento, CategoriaId = 2, SucursalId = 3 },
                    new { Id = 12, Marca = "Philco", Modelo = "E-Comfort", Estado = EstadoBicicleta.Disponible, CategoriaId = 3, SucursalId = 1 },
                    new { Id = 13, Marca = "Giant", Modelo = "Talon 3", Estado = EstadoBicicleta.Disponible, CategoriaId = 2, SucursalId = 2 },
                    new { Id = 14, Marca = "Zenith", Modelo = "Riva", Estado = EstadoBicicleta.EnMantenimiento, CategoriaId = 1, SucursalId = 4 },
                    new { Id = 15, Marca = "Firebird", Modelo = "Tour", Estado = EstadoBicicleta.Disponible, CategoriaId = 4, SucursalId = 1 }
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
                    new { Id = 2, Nombre = "Bicicletas Ya!", Direccion = "Zeballos 1500", Telefono = "3414002000", Capacidad = 15 },
                    new { Id = 3, Nombre = "BiciPaseo Costanera", Direccion = "Av. Del Huerto 1100", Telefono = "3414003000", Capacidad = 25 },
                    new { Id = 4, Nombre = "EcoBici Pellegrini", Direccion = "Av. Pellegrini 2100", Telefono = "3414004000", Capacidad = 18 }
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
                    .HasForeignKey(e => e.ClienteId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Empleado)
                    .WithMany()
                    .HasForeignKey(e => e.EmpleadoId)
                    .OnDelete(DeleteBehavior.Restrict);

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
                        .HasForeignKey(i => i.BicicletaId)
                        .OnDelete(DeleteBehavior.Restrict);

                    detalle.HasData(
                        // Alquiler 1
                        new { AlquilerId = 1, Id = 1, BicicletaId = 1, HoraInicio = new DateTime(2026, 5, 10, 10, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 5, 10, 12, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 1500m, Subtotal = 3000m },
                        new { AlquilerId = 1, Id = 2, BicicletaId = 2, HoraInicio = new DateTime(2026, 5, 10, 10, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 5, 10, 12, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 2500m, Subtotal = 5000m },
                        // Alquiler 2
                        new { AlquilerId = 2, Id = 3, BicicletaId = 3, HoraInicio = new DateTime(2026, 5, 22, 14, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 5, 22, 16, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 3500m, Subtotal = 7000m },
                        new { AlquilerId = 2, Id = 4, BicicletaId = 4, HoraInicio = new DateTime(2026, 5, 22, 14, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 5, 22, 17, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 2500m, Subtotal = 7500m },
                        // Alquiler 3
                        new { AlquilerId = 3, Id = 5, BicicletaId = 6, HoraInicio = new DateTime(2026, 6, 8, 11, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 6, 8, 13, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 2500m, Subtotal = 5000m },
                        new { AlquilerId = 3, Id = 6, BicicletaId = 7, HoraInicio = new DateTime(2026, 6, 8, 11, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 6, 8, 13, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 1800m, Subtotal = 3600m },
                        // Alquiler 4
                        new { AlquilerId = 4, Id = 7, BicicletaId = 9, HoraInicio = new DateTime(2026, 6, 25, 15, 30, 0), HoraFin = (DateTime?)new DateTime(2026, 6, 25, 17, 30, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 2500m, Subtotal = 5000m },
                        new { AlquilerId = 4, Id = 8, BicicletaId = 10, HoraInicio = new DateTime(2026, 6, 25, 15, 30, 0), HoraFin = (DateTime?)new DateTime(2026, 6, 25, 17, 30, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 2000m, Subtotal = 4000m },
                        // Alquiler 5
                        new { AlquilerId = 5, Id = 9, BicicletaId = 1, HoraInicio = new DateTime(2026, 7, 5, 9, 30, 0), HoraFin = (DateTime?)new DateTime(2026, 7, 5, 11, 30, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 1500m, Subtotal = 3000m },
                        new { AlquilerId = 5, Id = 10, BicicletaId = 5, HoraInicio = new DateTime(2026, 7, 5, 9, 30, 0), HoraFin = (DateTime?)new DateTime(2026, 7, 5, 12, 30, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 2500m, Subtotal = 7500m },
                        new { AlquilerId = 5, Id = 11, BicicletaId = 12, HoraInicio = new DateTime(2026, 7, 5, 9, 30, 0), HoraFin = (DateTime?)new DateTime(2026, 7, 5, 11, 30, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 3500m, Subtotal = 7000m },
                        // Alquiler 6
                        new { AlquilerId = 6, Id = 12, BicicletaId = 4, HoraInicio = new DateTime(2026, 7, 16, 16, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 7, 16, 18, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 2500m, Subtotal = 5000m },
                        new { AlquilerId = 6, Id = 13, BicicletaId = 6, HoraInicio = new DateTime(2026, 7, 16, 16, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 7, 16, 18, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 2500m, Subtotal = 5000m },
                        new { AlquilerId = 6, Id = 14, BicicletaId = 13, HoraInicio = new DateTime(2026, 7, 16, 16, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 7, 16, 18, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 2500m, Subtotal = 5000m },
                        // Alquiler 7
                        new { AlquilerId = 7, Id = 15, BicicletaId = 6, HoraInicio = new DateTime(2026, 7, 28, 10, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 7, 28, 13, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 2500m, Subtotal = 7500m },
                        new { AlquilerId = 7, Id = 16, BicicletaId = 2, HoraInicio = new DateTime(2026, 7, 28, 10, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 7, 28, 12, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 2500m, Subtotal = 5000m },
                        // Alquiler 8
                        new { AlquilerId = 8, Id = 17, BicicletaId = 1, HoraInicio = new DateTime(2026, 8, 4, 11, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 8, 4, 13, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 1500m, Subtotal = 3000m },
                        new { AlquilerId = 8, Id = 18, BicicletaId = 2, HoraInicio = new DateTime(2026, 8, 4, 11, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 8, 4, 13, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 2500m, Subtotal = 5000m },
                        new { AlquilerId = 8, Id = 19, BicicletaId = 5, HoraInicio = new DateTime(2026, 8, 4, 11, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 8, 4, 13, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 2500m, Subtotal = 5000m },
                        // Alquiler 9
                        new { AlquilerId = 9, Id = 20, BicicletaId = 3, HoraInicio = new DateTime(2026, 8, 12, 14, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 8, 12, 16, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 3500m, Subtotal = 7000m },
                        new { AlquilerId = 9, Id = 21, BicicletaId = 4, HoraInicio = new DateTime(2026, 8, 12, 14, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 8, 12, 16, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 2500m, Subtotal = 5000m },
                        // Alquiler 10
                        new { AlquilerId = 10, Id = 22, BicicletaId = 7, HoraInicio = new DateTime(2026, 8, 18, 15, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 8, 18, 18, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 1800m, Subtotal = 5400m },
                        new { AlquilerId = 10, Id = 23, BicicletaId = 3, HoraInicio = new DateTime(2026, 8, 18, 15, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 8, 18, 17, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 3500m, Subtotal = 7000m },
                        // Alquiler 11
                        new { AlquilerId = 11, Id = 24, BicicletaId = 9, HoraInicio = new DateTime(2026, 8, 23, 10, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 8, 23, 12, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 2500m, Subtotal = 5000m },
                        new { AlquilerId = 11, Id = 25, BicicletaId = 2, HoraInicio = new DateTime(2026, 8, 23, 10, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 8, 23, 12, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 2500m, Subtotal = 5000m },
                        // Alquiler 12
                        new { AlquilerId = 12, Id = 26, BicicletaId = 1, HoraInicio = new DateTime(2026, 8, 29, 16, 30, 0), HoraFin = (DateTime?)new DateTime(2026, 8, 29, 18, 30, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 1500m, Subtotal = 3000m },
                        new { AlquilerId = 12, Id = 27, BicicletaId = 15, HoraInicio = new DateTime(2026, 8, 29, 16, 30, 0), HoraFin = (DateTime?)new DateTime(2026, 8, 29, 18, 30, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 1800m, Subtotal = 3600m },
                        new { AlquilerId = 12, Id = 28, BicicletaId = 12, HoraInicio = new DateTime(2026, 8, 29, 16, 30, 0), HoraFin = (DateTime?)new DateTime(2026, 8, 29, 18, 30, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 3500m, Subtotal = 7000m },
                        // Alquiler 13
                        new { AlquilerId = 13, Id = 29, BicicletaId = 1, HoraInicio = new DateTime(2026, 9, 3, 10, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 9, 3, 12, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 1500m, Subtotal = 3000m },
                        new { AlquilerId = 13, Id = 30, BicicletaId = 2, HoraInicio = new DateTime(2026, 9, 3, 10, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 9, 3, 12, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 2500m, Subtotal = 5000m },
                        // Alquiler 14
                        new { AlquilerId = 14, Id = 31, BicicletaId = 3, HoraInicio = new DateTime(2026, 9, 9, 14, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 9, 9, 16, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 3500m, Subtotal = 7000m },
                        new { AlquilerId = 14, Id = 32, BicicletaId = 4, HoraInicio = new DateTime(2026, 9, 9, 14, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 9, 9, 17, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 2500m, Subtotal = 7500m },
                        // Alquiler 15
                        new { AlquilerId = 15, Id = 33, BicicletaId = 6, HoraInicio = new DateTime(2026, 9, 15, 11, 30, 0), HoraFin = (DateTime?)new DateTime(2026, 9, 15, 13, 30, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 2500m, Subtotal = 5000m },
                        new { AlquilerId = 15, Id = 34, BicicletaId = 7, HoraInicio = new DateTime(2026, 9, 15, 11, 30, 0), HoraFin = (DateTime?)new DateTime(2026, 9, 15, 13, 30, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 1800m, Subtotal = 3600m },
                        // Alquiler 16
                        new { AlquilerId = 16, Id = 35, BicicletaId = 9, HoraInicio = new DateTime(2026, 9, 21, 16, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 9, 21, 18, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 2500m, Subtotal = 5000m },
                        new { AlquilerId = 16, Id = 36, BicicletaId = 4, HoraInicio = new DateTime(2026, 9, 21, 16, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 9, 21, 18, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 2500m, Subtotal = 5000m },
                        // Alquiler 17
                        new { AlquilerId = 17, Id = 37, BicicletaId = 1, HoraInicio = new DateTime(2026, 9, 26, 10, 30, 0), HoraFin = (DateTime?)new DateTime(2026, 9, 26, 12, 30, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 1500m, Subtotal = 3000m },
                        new { AlquilerId = 17, Id = 38, BicicletaId = 5, HoraInicio = new DateTime(2026, 9, 26, 10, 30, 0), HoraFin = (DateTime?)new DateTime(2026, 9, 26, 12, 30, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 2500m, Subtotal = 5000m },
                        new { AlquilerId = 17, Id = 39, BicicletaId = 12, HoraInicio = new DateTime(2026, 9, 26, 10, 30, 0), HoraFin = (DateTime?)new DateTime(2026, 9, 26, 12, 30, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 3500m, Subtotal = 7000m },
                        // Alquiler 18
                        new { AlquilerId = 18, Id = 40, BicicletaId = 1, HoraInicio = new DateTime(2026, 9, 30, 15, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 9, 30, 17, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 1500m, Subtotal = 3000m },
                        new { AlquilerId = 18, Id = 41, BicicletaId = 4, HoraInicio = new DateTime(2026, 9, 30, 15, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 9, 30, 17, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 2500m, Subtotal = 5000m },
                        // Alquiler 19
                        new { AlquilerId = 19, Id = 42, BicicletaId = 1, HoraInicio = new DateTime(2026, 10, 5, 10, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 10, 5, 12, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 1500m, Subtotal = 3000m },
                        new { AlquilerId = 19, Id = 43, BicicletaId = 2, HoraInicio = new DateTime(2026, 10, 5, 10, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 10, 5, 12, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 2500m, Subtotal = 5000m },
                        // Alquiler 20
                        new { AlquilerId = 20, Id = 44, BicicletaId = 3, HoraInicio = new DateTime(2026, 10, 11, 14, 30, 0), HoraFin = (DateTime?)new DateTime(2026, 10, 11, 16, 30, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 3500m, Subtotal = 7000m },
                        new { AlquilerId = 20, Id = 45, BicicletaId = 4, HoraInicio = new DateTime(2026, 10, 11, 14, 30, 0), HoraFin = (DateTime?)new DateTime(2026, 10, 11, 16, 30, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 2500m, Subtotal = 5000m },
                        new { AlquilerId = 20, Id = 46, BicicletaId = 8, HoraInicio = new DateTime(2026, 10, 11, 14, 30, 0), HoraFin = (DateTime?)new DateTime(2026, 10, 11, 16, 30, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 1500m, Subtotal = 3000m },
                        // Alquiler 21
                        new { AlquilerId = 21, Id = 47, BicicletaId = 6, HoraInicio = new DateTime(2026, 10, 17, 11, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 10, 17, 13, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 2500m, Subtotal = 5000m },
                        new { AlquilerId = 21, Id = 48, BicicletaId = 7, HoraInicio = new DateTime(2026, 10, 17, 11, 0, 0), HoraFin = (DateTime?)new DateTime(2026, 10, 17, 14, 0, 0), Estado = EstadoDetalleAlquiler.Devuelto, PrecioHora = 1800m, Subtotal = 5400m },
                        // Alquiler 22 (Cancelado)
                        new { AlquilerId = 22, Id = 49, BicicletaId = 2, HoraInicio = new DateTime(2026, 10, 20, 16, 0, 0), HoraFin = (DateTime?)null, Estado = EstadoDetalleAlquiler.Activo, PrecioHora = 2500m, Subtotal = 0m },
                        // Alquiler 23 (Activo)
                        new { AlquilerId = 23, Id = 50, BicicletaId = 5, HoraInicio = new DateTime(2026, 10, 24, 16, 0, 0), HoraFin = (DateTime?)null, Estado = EstadoDetalleAlquiler.Activo, PrecioHora = 2500m, Subtotal = 0m },
                        // Alquiler 24 (Activo)
                        new { AlquilerId = 24, Id = 51, BicicletaId = 8, HoraInicio = new DateTime(2026, 10, 24, 17, 30, 0), HoraFin = (DateTime?)null, Estado = EstadoDetalleAlquiler.Activo, PrecioHora = 1500m, Subtotal = 0m }
                    );
                });

                entity.HasData(
                    new { Id = 1, ClienteId = 1, EmpleadoId = 1, FechaAlquiler = new DateTime(2026, 5, 10, 10, 0, 0), EstadoAlquiler = EstadoDeAlquiler.Finalizado },
                    new { Id = 2, ClienteId = 2, EmpleadoId = 2, FechaAlquiler = new DateTime(2026, 5, 22, 14, 0, 0), EstadoAlquiler = EstadoDeAlquiler.Finalizado },
                    new { Id = 3, ClienteId = 3, EmpleadoId = 3, FechaAlquiler = new DateTime(2026, 6, 8, 11, 0, 0), EstadoAlquiler = EstadoDeAlquiler.Finalizado },
                    new { Id = 4, ClienteId = 4, EmpleadoId = 4, FechaAlquiler = new DateTime(2026, 6, 25, 15, 30, 0), EstadoAlquiler = EstadoDeAlquiler.Finalizado },
                    new { Id = 5, ClienteId = 5, EmpleadoId = 1, FechaAlquiler = new DateTime(2026, 7, 5, 9, 30, 0), EstadoAlquiler = EstadoDeAlquiler.Finalizado },
                    new { Id = 6, ClienteId = 6, EmpleadoId = 2, FechaAlquiler = new DateTime(2026, 7, 16, 16, 0, 0), EstadoAlquiler = EstadoDeAlquiler.Finalizado },
                    new { Id = 7, ClienteId = 7, EmpleadoId = 3, FechaAlquiler = new DateTime(2026, 7, 28, 10, 0, 0), EstadoAlquiler = EstadoDeAlquiler.Finalizado },
                    new { Id = 8, ClienteId = 8, EmpleadoId = 1, FechaAlquiler = new DateTime(2026, 8, 4, 11, 0, 0), EstadoAlquiler = EstadoDeAlquiler.Finalizado },
                    new { Id = 9, ClienteId = 1, EmpleadoId = 2, FechaAlquiler = new DateTime(2026, 8, 12, 14, 0, 0), EstadoAlquiler = EstadoDeAlquiler.Finalizado },
                    new { Id = 10, ClienteId = 2, EmpleadoId = 3, FechaAlquiler = new DateTime(2026, 8, 18, 15, 0, 0), EstadoAlquiler = EstadoDeAlquiler.Finalizado },
                    new { Id = 11, ClienteId = 3, EmpleadoId = 4, FechaAlquiler = new DateTime(2026, 8, 23, 10, 0, 0), EstadoAlquiler = EstadoDeAlquiler.Finalizado },
                    new { Id = 12, ClienteId = 4, EmpleadoId = 5, FechaAlquiler = new DateTime(2026, 8, 29, 16, 30, 0), EstadoAlquiler = EstadoDeAlquiler.Finalizado },
                    new { Id = 13, ClienteId = 5, EmpleadoId = 1, FechaAlquiler = new DateTime(2026, 9, 3, 10, 0, 0), EstadoAlquiler = EstadoDeAlquiler.Finalizado },
                    new { Id = 14, ClienteId = 6, EmpleadoId = 2, FechaAlquiler = new DateTime(2026, 9, 9, 14, 0, 0), EstadoAlquiler = EstadoDeAlquiler.Finalizado },
                    new { Id = 15, ClienteId = 7, EmpleadoId = 3, FechaAlquiler = new DateTime(2026, 9, 15, 11, 30, 0), EstadoAlquiler = EstadoDeAlquiler.Finalizado },
                    new { Id = 16, ClienteId = 8, EmpleadoId = 4, FechaAlquiler = new DateTime(2026, 9, 21, 16, 0, 0), EstadoAlquiler = EstadoDeAlquiler.Finalizado },
                    new { Id = 17, ClienteId = 1, EmpleadoId = 1, FechaAlquiler = new DateTime(2026, 9, 26, 10, 30, 0), EstadoAlquiler = EstadoDeAlquiler.Finalizado },
                    new { Id = 18, ClienteId = 2, EmpleadoId = 2, FechaAlquiler = new DateTime(2026, 9, 30, 15, 0, 0), EstadoAlquiler = EstadoDeAlquiler.Finalizado },
                    new { Id = 19, ClienteId = 3, EmpleadoId = 1, FechaAlquiler = new DateTime(2026, 10, 5, 10, 0, 0), EstadoAlquiler = EstadoDeAlquiler.Finalizado },
                    new { Id = 20, ClienteId = 4, EmpleadoId = 2, FechaAlquiler = new DateTime(2026, 10, 11, 14, 30, 0), EstadoAlquiler = EstadoDeAlquiler.Finalizado },
                    new { Id = 21, ClienteId = 5, EmpleadoId = 3, FechaAlquiler = new DateTime(2026, 10, 17, 11, 0, 0), EstadoAlquiler = EstadoDeAlquiler.Finalizado },
                    new { Id = 22, ClienteId = 6, EmpleadoId = 1, FechaAlquiler = new DateTime(2026, 10, 20, 16, 0, 0), EstadoAlquiler = EstadoDeAlquiler.Cancelado },
                    new { Id = 23, ClienteId = 7, EmpleadoId = 1, FechaAlquiler = new DateTime(2026, 10, 24, 16, 0, 0), EstadoAlquiler = EstadoDeAlquiler.Activo },
                    new { Id = 24, ClienteId = 8, EmpleadoId = 2, FechaAlquiler = new DateTime(2026, 10, 24, 17, 30, 0), EstadoAlquiler = EstadoDeAlquiler.Activo }
                );

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

                entity.HasData(
                    new { IdPago = 1, IdAlquiler = 1, FechaPago = new DateTime(2026, 5, 10, 12, 5, 0), Monto = 8000m, Metodo = MetodoPago.Efectivo },
                    new { IdPago = 2, IdAlquiler = 2, FechaPago = new DateTime(2026, 5, 22, 17, 5, 0), Monto = 14500m, Metodo = MetodoPago.TarjetaDebito },
                    new { IdPago = 3, IdAlquiler = 3, FechaPago = new DateTime(2026, 6, 8, 13, 10, 0), Monto = 8600m, Metodo = MetodoPago.Transferencia },
                    new { IdPago = 4, IdAlquiler = 4, FechaPago = new DateTime(2026, 6, 25, 17, 35, 0), Monto = 9000m, Metodo = MetodoPago.TarjetaCredito },
                    new { IdPago = 5, IdAlquiler = 5, FechaPago = new DateTime(2026, 7, 5, 12, 35, 0), Monto = 17500m, Metodo = MetodoPago.Efectivo },
                    new { IdPago = 6, IdAlquiler = 6, FechaPago = new DateTime(2026, 7, 16, 18, 5, 0), Monto = 15000m, Metodo = MetodoPago.Transferencia },
                    new { IdPago = 7, IdAlquiler = 7, FechaPago = new DateTime(2026, 7, 28, 13, 5, 0), Monto = 12500m, Metodo = MetodoPago.TarjetaDebito },
                    new { IdPago = 8, IdAlquiler = 8, FechaPago = new DateTime(2026, 8, 4, 13, 5, 0), Monto = 13000m, Metodo = MetodoPago.TarjetaCredito },
                    new { IdPago = 9, IdAlquiler = 9, FechaPago = new DateTime(2026, 8, 12, 16, 10, 0), Monto = 12000m, Metodo = MetodoPago.Efectivo },
                    new { IdPago = 10, IdAlquiler = 10, FechaPago = new DateTime(2026, 8, 18, 18, 5, 0), Monto = 12400m, Metodo = MetodoPago.Transferencia },
                    new { IdPago = 11, IdAlquiler = 11, FechaPago = new DateTime(2026, 8, 23, 12, 5, 0), Monto = 10000m, Metodo = MetodoPago.TarjetaDebito },
                    new { IdPago = 12, IdAlquiler = 12, FechaPago = new DateTime(2026, 8, 29, 18, 35, 0), Monto = 13600m, Metodo = MetodoPago.Efectivo },
                    new { IdPago = 13, IdAlquiler = 13, FechaPago = new DateTime(2026, 9, 3, 12, 5, 0), Monto = 8000m, Metodo = MetodoPago.TarjetaCredito },
                    new { IdPago = 14, IdAlquiler = 14, FechaPago = new DateTime(2026, 9, 9, 17, 5, 0), Monto = 14500m, Metodo = MetodoPago.Transferencia },
                    new { IdPago = 15, IdAlquiler = 15, FechaPago = new DateTime(2026, 9, 15, 13, 35, 0), Monto = 8600m, Metodo = MetodoPago.TarjetaDebito },
                    new { IdPago = 16, IdAlquiler = 16, FechaPago = new DateTime(2026, 9, 21, 18, 5, 0), Monto = 10000m, Metodo = MetodoPago.Efectivo },
                    new { IdPago = 17, IdAlquiler = 17, FechaPago = new DateTime(2026, 9, 26, 12, 35, 0), Monto = 15000m, Metodo = MetodoPago.TarjetaCredito },
                    new { IdPago = 18, IdAlquiler = 18, FechaPago = new DateTime(2026, 9, 30, 17, 5, 0), Monto = 8000m, Metodo = MetodoPago.Transferencia },
                    new { IdPago = 19, IdAlquiler = 19, FechaPago = new DateTime(2026, 10, 5, 12, 5, 0), Monto = 8000m, Metodo = MetodoPago.Efectivo },
                    new { IdPago = 20, IdAlquiler = 20, FechaPago = new DateTime(2026, 10, 11, 16, 35, 0), Monto = 15000m, Metodo = MetodoPago.TarjetaDebito },
                    new { IdPago = 21, IdAlquiler = 21, FechaPago = new DateTime(2026, 10, 17, 14, 5, 0), Monto = 10400m, Metodo = MetodoPago.Transferencia }
                );
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
                    new Empleado(2, "30222333", TipoDocumento.DNI, "Juan", "Diaz", "3414001011", 1002, 2),
                    new Empleado(3, "32444555", TipoDocumento.DNI, "Carlos", "Rodriguez", "3414001012", 1003, 3),
                    new Empleado(4, "35666777", TipoDocumento.DNI, "Sofia", "Martinez", "3414001013", 1004, 4),
                    new Empleado(5, "33888999", TipoDocumento.DNI, "Lucas", "Fernandez", "3414001014", 1005, 1)
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
                    new { Id = 3, PrecioHora = 3500m, FechaDesde = new DateTime(2026, 1, 1), FechaHasta = (DateTime?)null, CategoriaId = 3 },
                    new { Id = 4, PrecioHora = 1800m, FechaDesde = new DateTime(2026, 1, 1), FechaHasta = (DateTime?)null, CategoriaId = 4 },
                    new { Id = 5, PrecioHora = 2000m, FechaDesde = new DateTime(2026, 1, 1), FechaHasta = (DateTime?)null, CategoriaId = 5 }
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