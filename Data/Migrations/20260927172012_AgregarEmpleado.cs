using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregarEmpleado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Legajo = table.Column<int>(type: "int", nullable: false),
                    SucursalId = table.Column<int>(type: "int", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TipoDocumento = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleados_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Documento",
                table: "Empleados",
                column: "Documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Legajo",
                table: "Empleados",
                column: "Legajo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_SucursalId",
                table: "Empleados",
                column: "SucursalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");
        }
    }
}
