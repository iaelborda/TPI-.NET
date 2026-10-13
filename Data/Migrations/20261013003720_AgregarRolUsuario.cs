using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRolUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Activo", "Email", "FechaCreacion", "PasswordHash", "Rol", "Salt", "Username" },
                values: new object[,]
                {
                    { 1, true, "admin@tpi.com", new DateTime(2026, 10, 12, 21, 37, 20, 44, DateTimeKind.Local).AddTicks(4840), "s00STL62jRmOM633Nt+ed6YHVSzx5CT9p2MgZuM0zmk=", 0, "6Ypt1HXjEVl/wDsz4Yiql7D5l1FVouk6QAaa6/akyAE=", "admin" },
                    { 2, true, "empleado@tpi.com", new DateTime(2026, 10, 12, 21, 37, 20, 48, DateTimeKind.Local).AddTicks(3298), "wGsmuUdZCTrW+d5BmK66GbKyIt5Lry7ps6RMwEoOXa8=", 1, "m7a7dBKMqCgeeDrnXBS3WwHNIn5o0TvhPbOQyCxXQjI=", "empleado" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Username",
                table: "Usuarios",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
