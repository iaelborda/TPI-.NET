using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregarPago : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    IdPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAlquiler = table.Column<int>(type: "int", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Metodo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.IdPago);
                    table.ForeignKey(
                        name: "FK_Pagos_Alquileres_IdAlquiler",
                        column: x => x.IdAlquiler,
                        principalTable: "Alquileres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_IdAlquiler",
                table: "Pagos",
                column: "IdAlquiler",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "PasswordHash", "Salt" },
                values: new object[] { new DateTime(2026, 10, 12, 21, 37, 20, 44, DateTimeKind.Local).AddTicks(4840), "s00STL62jRmOM633Nt+ed6YHVSzx5CT9p2MgZuM0zmk=", "6Ypt1HXjEVl/wDsz4Yiql7D5l1FVouk6QAaa6/akyAE=" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "PasswordHash", "Salt" },
                values: new object[] { new DateTime(2026, 10, 12, 21, 37, 20, 48, DateTimeKind.Local).AddTicks(3298), "wGsmuUdZCTrW+d5BmK66GbKyIt5Lry7ps6RMwEoOXa8=", "m7a7dBKMqCgeeDrnXBS3WwHNIn5o0TvhPbOQyCxXQjI=" });
        }
    }
}
