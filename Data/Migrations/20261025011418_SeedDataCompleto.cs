using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataCompleto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Alquileres",
                columns: new[] { "Id", "ClienteId", "EmpleadoId", "EstadoAlquiler", "FechaAlquiler" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, new DateTime(2026, 5, 10, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 2, 1, new DateTime(2026, 5, 22, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 1, 2, 1, new DateTime(2026, 8, 12, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 1, 1, 1, new DateTime(2026, 9, 26, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 2, 2, 1, new DateTime(2026, 9, 30, 15, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Bicicletas",
                columns: new[] { "Id", "CategoriaId", "Estado", "Marca", "Modelo", "SucursalId" },
                values: new object[,]
                {
                    { 4, 2, 0, "Trek", "Marlin 5", 2 },
                    { 5, 2, 1, "Raleigh", "Mojave 2.0", 1 },
                    { 8, 1, 1, "SLP", "50 Pro", 2 },
                    { 12, 3, 0, "Philco", "E-Comfort", 1 },
                    { 13, 2, 0, "Giant", "Talon 3", 2 }
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 4, "Paseo" },
                    { 5, "Plegable" }
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Apellido", "Documento", "Email", "FechaAlta", "Nombre", "Telefono", "TipoDocumento" },
                values: new object[,]
                {
                    { 3, "Rossi", "38333444", "maria.rossi@gmail.com", new DateOnly(2026, 3, 1), "Maria", "3414001003", 0 },
                    { 4, "Alvarez", "42555666", "julian.alvarez@gmail.com", new DateOnly(2026, 3, 20), "Julian", "3414001004", 0 },
                    { 5, "Diaz", "39777888", "valen.diaz@gmail.com", new DateOnly(2026, 4, 12), "Valentina", "3414001005", 0 },
                    { 6, "Romero", "37999000", "facu.romero@gmail.com", new DateOnly(2026, 5, 5), "Facundo", "3414001006", 0 },
                    { 7, "Benitez", "41111222", "camila.b@gmail.com", new DateOnly(2026, 6, 18), "Camila", "3414001007", 0 },
                    { 8, "Herrera", "43333444", "nico.herrera@gmail.com", new DateOnly(2026, 7, 22), "Nicolas", "3414001008", 0 }
                });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "Id", "Apellido", "Documento", "Legajo", "Nombre", "SucursalId", "Telefono", "TipoDocumento" },
                values: new object[] { 5, "Fernandez", "33888999", 1005, "Lucas", 1, "3414001014", 0 });

            migrationBuilder.InsertData(
                table: "Sucursales",
                columns: new[] { "Id", "Capacidad", "Direccion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 3, 25, "Av. Del Huerto 1100", "BiciPaseo Costanera", "3414003000" },
                    { 4, 18, "Av. Pellegrini 2100", "EcoBici Pellegrini", "3414004000" }
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "PasswordHash", "Salt" },
                values: new object[] { new DateTime(2026, 10, 24, 22, 14, 17, 497, DateTimeKind.Local).AddTicks(9223), "NCNMjylAV5fXMY7GV39k59Bi1kJQGP2HYFt2Xyy0XcE=", "0od4+qfRLye6AoLyBKaw2ibHPM948F43EFEagxhMkZY=" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "PasswordHash", "Salt" },
                values: new object[] { new DateTime(2026, 10, 24, 22, 14, 17, 501, DateTimeKind.Local).AddTicks(5596), "5UdEMInKkmNP+EjTkCJB6Xdyh3Lxggh2MuCCO4GlFWQ=", "N6YUz4XIOPrkQGDjBIVu+O4EhaH5MZO+ZMoNB/r+pDw=" });

            migrationBuilder.InsertData(
                table: "Alquileres",
                columns: new[] { "Id", "ClienteId", "EmpleadoId", "EstadoAlquiler", "FechaAlquiler" },
                values: new object[,]
                {
                    { 5, 5, 1, 1, new DateTime(2026, 7, 5, 9, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 6, 2, 1, new DateTime(2026, 7, 16, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 8, 1, 1, new DateTime(2026, 8, 4, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 4, 5, 1, new DateTime(2026, 8, 29, 16, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 5, 1, 1, new DateTime(2026, 9, 3, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 6, 2, 1, new DateTime(2026, 9, 9, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 3, 1, 1, new DateTime(2026, 10, 5, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 4, 2, 1, new DateTime(2026, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 6, 1, 2, new DateTime(2026, 10, 20, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 7, 1, 0, new DateTime(2026, 10, 24, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 8, 2, 0, new DateTime(2026, 10, 24, 17, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Bicicletas",
                columns: new[] { "Id", "CategoriaId", "Estado", "Marca", "Modelo", "SucursalId" },
                values: new object[,]
                {
                    { 6, 2, 0, "Specialized", "Rockhopper", 3 },
                    { 7, 4, 0, "Olmo", "Amelie", 3 },
                    { 9, 2, 0, "Scott", "Aspect 950", 4 },
                    { 10, 5, 0, "Aurora", "Folding", 4 },
                    { 11, 2, 2, "Vairo", "XR 3.8", 3 },
                    { 14, 1, 2, "Zenith", "Riva", 4 },
                    { 15, 4, 0, "Firebird", "Tour", 1 }
                });

            migrationBuilder.InsertData(
                table: "DetalleAlquiler",
                columns: new[] { "AlquilerId", "Id", "BicicletaId", "Estado", "HoraFin", "HoraInicio", "PrecioHora", "Subtotal" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, new DateTime(2026, 5, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), 1500m, 3000m },
                    { 1, 2, 2, 1, new DateTime(2026, 5, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), 2500m, 5000m },
                    { 2, 3, 3, 1, new DateTime(2026, 5, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), 3500m, 7000m },
                    { 2, 4, 4, 1, new DateTime(2026, 5, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), 2500m, 7500m },
                    { 9, 20, 3, 1, new DateTime(2026, 8, 12, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 12, 14, 0, 0, 0, DateTimeKind.Unspecified), 3500m, 7000m },
                    { 9, 21, 4, 1, new DateTime(2026, 8, 12, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 12, 14, 0, 0, 0, DateTimeKind.Unspecified), 2500m, 5000m },
                    { 17, 37, 1, 1, new DateTime(2026, 9, 26, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), 1500m, 3000m },
                    { 17, 38, 5, 1, new DateTime(2026, 9, 26, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), 2500m, 5000m },
                    { 17, 39, 12, 1, new DateTime(2026, 9, 26, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), 3500m, 7000m },
                    { 18, 40, 1, 1, new DateTime(2026, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 30, 15, 0, 0, 0, DateTimeKind.Unspecified), 1500m, 3000m },
                    { 18, 41, 4, 1, new DateTime(2026, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 30, 15, 0, 0, 0, DateTimeKind.Unspecified), 2500m, 5000m }
                });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "Id", "Apellido", "Documento", "Legajo", "Nombre", "SucursalId", "Telefono", "TipoDocumento" },
                values: new object[,]
                {
                    { 3, "Rodriguez", "32444555", 1003, "Carlos", 3, "3414001012", 0 },
                    { 4, "Martinez", "35666777", 1004, "Sofia", 4, "3414001013", 0 }
                });

            migrationBuilder.InsertData(
                table: "Pagos",
                columns: new[] { "IdPago", "FechaPago", "IdAlquiler", "Metodo", "Monto" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 10, 12, 5, 0, 0, DateTimeKind.Unspecified), 1, 0, 8000m },
                    { 2, new DateTime(2026, 5, 22, 17, 5, 0, 0, DateTimeKind.Unspecified), 2, 2, 14500m },
                    { 9, new DateTime(2026, 8, 12, 16, 10, 0, 0, DateTimeKind.Unspecified), 9, 0, 12000m },
                    { 17, new DateTime(2026, 9, 26, 12, 35, 0, 0, DateTimeKind.Unspecified), 17, 1, 15000m },
                    { 18, new DateTime(2026, 9, 30, 17, 5, 0, 0, DateTimeKind.Unspecified), 18, 3, 8000m }
                });

            migrationBuilder.InsertData(
                table: "Tarifas",
                columns: new[] { "Id", "CategoriaId", "FechaDesde", "FechaHasta", "PrecioHora" },
                values: new object[,]
                {
                    { 4, 4, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1800m },
                    { 5, 5, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2000m }
                });

            migrationBuilder.InsertData(
                table: "Alquileres",
                columns: new[] { "Id", "ClienteId", "EmpleadoId", "EstadoAlquiler", "FechaAlquiler" },
                values: new object[,]
                {
                    { 3, 3, 3, 1, new DateTime(2026, 6, 8, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, 4, 1, new DateTime(2026, 6, 25, 15, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 7, 3, 1, new DateTime(2026, 7, 28, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 2, 3, 1, new DateTime(2026, 8, 18, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 3, 4, 1, new DateTime(2026, 8, 23, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 7, 3, 1, new DateTime(2026, 9, 15, 11, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 8, 4, 1, new DateTime(2026, 9, 21, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 5, 3, 1, new DateTime(2026, 10, 17, 11, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "DetalleAlquiler",
                columns: new[] { "AlquilerId", "Id", "BicicletaId", "Estado", "HoraFin", "HoraInicio", "PrecioHora", "Subtotal" },
                values: new object[,]
                {
                    { 5, 9, 1, 1, new DateTime(2026, 7, 5, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 7, 5, 9, 30, 0, 0, DateTimeKind.Unspecified), 1500m, 3000m },
                    { 5, 10, 5, 1, new DateTime(2026, 7, 5, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 7, 5, 9, 30, 0, 0, DateTimeKind.Unspecified), 2500m, 7500m },
                    { 5, 11, 12, 1, new DateTime(2026, 7, 5, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 7, 5, 9, 30, 0, 0, DateTimeKind.Unspecified), 3500m, 7000m },
                    { 6, 12, 4, 1, new DateTime(2026, 7, 16, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 7, 16, 16, 0, 0, 0, DateTimeKind.Unspecified), 2500m, 5000m },
                    { 6, 13, 6, 1, new DateTime(2026, 7, 16, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 7, 16, 16, 0, 0, 0, DateTimeKind.Unspecified), 2500m, 5000m },
                    { 6, 14, 13, 1, new DateTime(2026, 7, 16, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 7, 16, 16, 0, 0, 0, DateTimeKind.Unspecified), 2500m, 5000m },
                    { 8, 17, 1, 1, new DateTime(2026, 8, 4, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 4, 11, 0, 0, 0, DateTimeKind.Unspecified), 1500m, 3000m },
                    { 8, 18, 2, 1, new DateTime(2026, 8, 4, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 4, 11, 0, 0, 0, DateTimeKind.Unspecified), 2500m, 5000m },
                    { 8, 19, 5, 1, new DateTime(2026, 8, 4, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 4, 11, 0, 0, 0, DateTimeKind.Unspecified), 2500m, 5000m },
                    { 12, 26, 1, 1, new DateTime(2026, 8, 29, 18, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 29, 16, 30, 0, 0, DateTimeKind.Unspecified), 1500m, 3000m },
                    { 12, 27, 15, 1, new DateTime(2026, 8, 29, 18, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 29, 16, 30, 0, 0, DateTimeKind.Unspecified), 1800m, 3600m },
                    { 12, 28, 12, 1, new DateTime(2026, 8, 29, 18, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 29, 16, 30, 0, 0, DateTimeKind.Unspecified), 3500m, 7000m },
                    { 13, 29, 1, 1, new DateTime(2026, 9, 3, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), 1500m, 3000m },
                    { 13, 30, 2, 1, new DateTime(2026, 9, 3, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), 2500m, 5000m },
                    { 14, 31, 3, 1, new DateTime(2026, 9, 9, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 9, 14, 0, 0, 0, DateTimeKind.Unspecified), 3500m, 7000m },
                    { 14, 32, 4, 1, new DateTime(2026, 9, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 9, 14, 0, 0, 0, DateTimeKind.Unspecified), 2500m, 7500m },
                    { 19, 42, 1, 1, new DateTime(2026, 10, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), 1500m, 3000m },
                    { 19, 43, 2, 1, new DateTime(2026, 10, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), 2500m, 5000m },
                    { 20, 44, 3, 1, new DateTime(2026, 10, 11, 16, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), 3500m, 7000m },
                    { 20, 45, 4, 1, new DateTime(2026, 10, 11, 16, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), 2500m, 5000m },
                    { 20, 46, 8, 1, new DateTime(2026, 10, 11, 16, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), 1500m, 3000m },
                    { 22, 49, 2, 0, null, new DateTime(2026, 10, 20, 16, 0, 0, 0, DateTimeKind.Unspecified), 2500m, 0m },
                    { 23, 50, 5, 0, null, new DateTime(2026, 10, 24, 16, 0, 0, 0, DateTimeKind.Unspecified), 2500m, 0m },
                    { 24, 51, 8, 0, null, new DateTime(2026, 10, 24, 17, 30, 0, 0, DateTimeKind.Unspecified), 1500m, 0m }
                });

            migrationBuilder.InsertData(
                table: "Pagos",
                columns: new[] { "IdPago", "FechaPago", "IdAlquiler", "Metodo", "Monto" },
                values: new object[,]
                {
                    { 5, new DateTime(2026, 7, 5, 12, 35, 0, 0, DateTimeKind.Unspecified), 5, 0, 17500m },
                    { 6, new DateTime(2026, 7, 16, 18, 5, 0, 0, DateTimeKind.Unspecified), 6, 3, 15000m },
                    { 8, new DateTime(2026, 8, 4, 13, 5, 0, 0, DateTimeKind.Unspecified), 8, 1, 13000m },
                    { 12, new DateTime(2026, 8, 29, 18, 35, 0, 0, DateTimeKind.Unspecified), 12, 0, 13600m },
                    { 13, new DateTime(2026, 9, 3, 12, 5, 0, 0, DateTimeKind.Unspecified), 13, 1, 8000m },
                    { 14, new DateTime(2026, 9, 9, 17, 5, 0, 0, DateTimeKind.Unspecified), 14, 3, 14500m },
                    { 19, new DateTime(2026, 10, 5, 12, 5, 0, 0, DateTimeKind.Unspecified), 19, 0, 8000m },
                    { 20, new DateTime(2026, 10, 11, 16, 35, 0, 0, DateTimeKind.Unspecified), 20, 2, 15000m }
                });

            migrationBuilder.InsertData(
                table: "DetalleAlquiler",
                columns: new[] { "AlquilerId", "Id", "BicicletaId", "Estado", "HoraFin", "HoraInicio", "PrecioHora", "Subtotal" },
                values: new object[,]
                {
                    { 3, 5, 6, 1, new DateTime(2026, 6, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), 2500m, 5000m },
                    { 3, 6, 7, 1, new DateTime(2026, 6, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), 1800m, 3600m },
                    { 4, 7, 9, 1, new DateTime(2026, 6, 25, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 25, 15, 30, 0, 0, DateTimeKind.Unspecified), 2500m, 5000m },
                    { 4, 8, 10, 1, new DateTime(2026, 6, 25, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 25, 15, 30, 0, 0, DateTimeKind.Unspecified), 2000m, 4000m },
                    { 7, 15, 6, 1, new DateTime(2026, 7, 28, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 7, 28, 10, 0, 0, 0, DateTimeKind.Unspecified), 2500m, 7500m },
                    { 7, 16, 2, 1, new DateTime(2026, 7, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 7, 28, 10, 0, 0, 0, DateTimeKind.Unspecified), 2500m, 5000m },
                    { 10, 22, 7, 1, new DateTime(2026, 8, 18, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 18, 15, 0, 0, 0, DateTimeKind.Unspecified), 1800m, 5400m },
                    { 10, 23, 3, 1, new DateTime(2026, 8, 18, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 18, 15, 0, 0, 0, DateTimeKind.Unspecified), 3500m, 7000m },
                    { 11, 24, 9, 1, new DateTime(2026, 8, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 23, 10, 0, 0, 0, DateTimeKind.Unspecified), 2500m, 5000m },
                    { 11, 25, 2, 1, new DateTime(2026, 8, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 23, 10, 0, 0, 0, DateTimeKind.Unspecified), 2500m, 5000m },
                    { 15, 33, 6, 1, new DateTime(2026, 9, 15, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 15, 11, 30, 0, 0, DateTimeKind.Unspecified), 2500m, 5000m },
                    { 15, 34, 7, 1, new DateTime(2026, 9, 15, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 15, 11, 30, 0, 0, DateTimeKind.Unspecified), 1800m, 3600m },
                    { 16, 35, 9, 1, new DateTime(2026, 9, 21, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 21, 16, 0, 0, 0, DateTimeKind.Unspecified), 2500m, 5000m },
                    { 16, 36, 4, 1, new DateTime(2026, 9, 21, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 21, 16, 0, 0, 0, DateTimeKind.Unspecified), 2500m, 5000m },
                    { 21, 47, 6, 1, new DateTime(2026, 10, 17, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 17, 11, 0, 0, 0, DateTimeKind.Unspecified), 2500m, 5000m },
                    { 21, 48, 7, 1, new DateTime(2026, 10, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 17, 11, 0, 0, 0, DateTimeKind.Unspecified), 1800m, 5400m }
                });

            migrationBuilder.InsertData(
                table: "Pagos",
                columns: new[] { "IdPago", "FechaPago", "IdAlquiler", "Metodo", "Monto" },
                values: new object[,]
                {
                    { 3, new DateTime(2026, 6, 8, 13, 10, 0, 0, DateTimeKind.Unspecified), 3, 3, 8600m },
                    { 4, new DateTime(2026, 6, 25, 17, 35, 0, 0, DateTimeKind.Unspecified), 4, 1, 9000m },
                    { 7, new DateTime(2026, 7, 28, 13, 5, 0, 0, DateTimeKind.Unspecified), 7, 2, 12500m },
                    { 10, new DateTime(2026, 8, 18, 18, 5, 0, 0, DateTimeKind.Unspecified), 10, 3, 12400m },
                    { 11, new DateTime(2026, 8, 23, 12, 5, 0, 0, DateTimeKind.Unspecified), 11, 2, 10000m },
                    { 15, new DateTime(2026, 9, 15, 13, 35, 0, 0, DateTimeKind.Unspecified), 15, 2, 8600m },
                    { 16, new DateTime(2026, 9, 21, 18, 5, 0, 0, DateTimeKind.Unspecified), 16, 0, 10000m },
                    { 21, new DateTime(2026, 10, 17, 14, 5, 0, 0, DateTimeKind.Unspecified), 21, 3, 10400m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 5, 10 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 5, 11 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 6, 12 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 6, 13 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 6, 14 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 7, 15 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 7, 16 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 8, 17 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 8, 18 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 8, 19 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 9, 20 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 9, 21 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 10, 22 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 10, 23 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 11, 24 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 11, 25 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 12, 26 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 12, 27 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 12, 28 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 13, 29 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 13, 30 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 14, 31 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 14, 32 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 15, 33 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 15, 34 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 16, 35 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 16, 36 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 17, 37 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 17, 38 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 17, 39 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 18, 40 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 18, 41 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 19, 42 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 19, 43 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 20, 44 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 20, 45 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 20, 46 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 21, 47 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 21, 48 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 22, 49 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 23, 50 });

            migrationBuilder.DeleteData(
                table: "DetalleAlquiler",
                keyColumns: new[] { "AlquilerId", "Id" },
                keyValues: new object[] { 24, 51 });

            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "IdPago",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "IdPago",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "IdPago",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "IdPago",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "IdPago",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "IdPago",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "IdPago",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "IdPago",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "IdPago",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "IdPago",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "IdPago",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "IdPago",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "IdPago",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "IdPago",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "IdPago",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "IdPago",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "IdPago",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "IdPago",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "IdPago",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "IdPago",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "IdPago",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Tarifas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tarifas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Alquileres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Alquileres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Alquileres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Alquileres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Alquileres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Alquileres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Alquileres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Alquileres",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Alquileres",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Alquileres",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Alquileres",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Alquileres",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Alquileres",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Alquileres",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Alquileres",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Alquileres",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Alquileres",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Alquileres",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Alquileres",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Alquileres",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Alquileres",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Alquileres",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Alquileres",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Alquileres",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sucursales",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sucursales",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "PasswordHash", "Salt" },
                values: new object[] { new DateTime(2026, 10, 24, 14, 7, 33, 179, DateTimeKind.Local).AddTicks(7360), "IJRqOq0OxrMAYbrBivtT6a0uDHQ3mREjjqXMViNy03w=", "+dENJ8kHoIn6kXeiI6k4P474qYI5b4wqwmCpYR0tarw=" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "PasswordHash", "Salt" },
                values: new object[] { new DateTime(2026, 10, 24, 14, 7, 33, 182, DateTimeKind.Local).AddTicks(3958), "+wqvzGEjwiU0q2iIHTSiHLs8GqwmTVjyvQ/VqTheu3Y=", "9N37sC9Dw6wolltGrjBwjESZZuof8PJO2W3g3466618=" });
        }
    }
}
