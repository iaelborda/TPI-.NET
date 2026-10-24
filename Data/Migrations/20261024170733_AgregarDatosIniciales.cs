using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregarDatosIniciales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Apellido", "Documento", "Email", "FechaAlta", "Nombre", "Telefono", "TipoDocumento" },
                values: new object[,]
                {
                    { 1, "Perez", "36111222", "lucia@gmail.com", new DateOnly(2026, 1, 10), "Lucia", "3414001001", 0 },
                    { 2, "Gomez", "40222333", "martin@gmail.com", new DateOnly(2026, 2, 15), "Martin", "3414001002", 0 }
                });

            migrationBuilder.InsertData(
                table: "Sucursales",
                columns: new[] { "Id", "Capacidad", "Direccion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, 20, "Mitre 1200", "BiciMania", "3414001000" },
                    { 2, 15, "Zeballos 1500", "Bicicletas Ya!", "3414002000" }
                });

            migrationBuilder.InsertData(
                table: "Tarifas",
                columns: new[] { "Id", "CategoriaId", "FechaDesde", "FechaHasta", "PrecioHora" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1500m },
                    { 2, 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2500m },
                    { 3, 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3500m }
                });

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

            migrationBuilder.InsertData(
                table: "Bicicletas",
                columns: new[] { "Id", "CategoriaId", "Estado", "Marca", "Modelo", "SucursalId" },
                values: new object[,]
                {
                    { 1, 1, 0, "Venzo", "Raptor", 1 },
                    { 2, 2, 0, "TopMega", "City", 1 },
                    { 3, 3, 0, "Volta", "E-Bike", 2 }
                });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "Id", "Apellido", "Documento", "Legajo", "Nombre", "SucursalId", "Telefono", "TipoDocumento" },
                values: new object[,]
                {
                    { 1, "Lopez", "30111222", 1001, "Ana", 1, "3414001010", 0 },
                    { 2, "Diaz", "30222333", 1002, "Juan", 2, "3414001011", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tarifas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tarifas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tarifas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sucursales",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sucursales",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "PasswordHash", "Salt" },
                values: new object[] { new DateTime(2026, 10, 21, 23, 27, 15, 651, DateTimeKind.Local).AddTicks(5063), "Pbf5enu0L2D5iqmvpB5nkQ21A+fdiyvx+MSe75RMEWI=", "dwXpeHGKn1WVhcLQJCaupbWpds7K7UG+rnqETWvuSOg=" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "PasswordHash", "Salt" },
                values: new object[] { new DateTime(2026, 10, 21, 23, 27, 15, 654, DateTimeKind.Local).AddTicks(143), "GZBOsiaZNdPLZhm2v/Tdy+6LaQaHZ9XfBcqs0MasNMk=", "AipMYU6fxrodKdV6EGNwHZOnAGUe102x3aFUnSChQ/Y=" });
        }
    }
}
