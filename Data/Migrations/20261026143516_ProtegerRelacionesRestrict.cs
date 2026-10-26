using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ProtegerRelacionesRestrict : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alquileres_Clientes_ClienteId",
                table: "Alquileres");

            migrationBuilder.DropForeignKey(
                name: "FK_Alquileres_Empleados_EmpleadoId",
                table: "Alquileres");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleAlquiler_Bicicletas_BicicletaId",
                table: "DetalleAlquiler");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "PasswordHash", "Salt" },
                values: new object[] { new DateTime(2026, 10, 26, 11, 35, 15, 762, DateTimeKind.Local).AddTicks(8759), "Pu1e30vgLoBNdvSfktvYhvHWoTvYx9vdxXF18/msp40=", "3aPtUGe6vqpQhVysYBnNn3I3Nnz4QDX+UcjaiBe2f7I=" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "PasswordHash", "Salt" },
                values: new object[] { new DateTime(2026, 10, 26, 11, 35, 15, 765, DateTimeKind.Local).AddTicks(5388), "UbuztOnQIHqU1kGCx5RqwWvNPnZMBdMfWfcGQkw0oIQ=", "zHzSu7S3YvTZcjNJVqVEqnKECJf5EVR8CyOd2OPA9gI=" });

            migrationBuilder.AddForeignKey(
                name: "FK_Alquileres_Clientes_ClienteId",
                table: "Alquileres",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alquileres_Empleados_EmpleadoId",
                table: "Alquileres",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleAlquiler_Bicicletas_BicicletaId",
                table: "DetalleAlquiler",
                column: "BicicletaId",
                principalTable: "Bicicletas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alquileres_Clientes_ClienteId",
                table: "Alquileres");

            migrationBuilder.DropForeignKey(
                name: "FK_Alquileres_Empleados_EmpleadoId",
                table: "Alquileres");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleAlquiler_Bicicletas_BicicletaId",
                table: "DetalleAlquiler");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Alquileres_Clientes_ClienteId",
                table: "Alquileres",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alquileres_Empleados_EmpleadoId",
                table: "Alquileres",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleAlquiler_Bicicletas_BicicletaId",
                table: "DetalleAlquiler",
                column: "BicicletaId",
                principalTable: "Bicicletas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
