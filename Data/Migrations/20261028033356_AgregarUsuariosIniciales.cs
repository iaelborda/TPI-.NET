using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregarUsuariosIniciales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "PasswordHash", "Salt" },
                values: new object[] { new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "t0CsZB4gNrdk4jfMtIKamEVRH3tJdMvDLPvUXObxx4U=", "86uVVoCfMxCiz2a4vacAVNjoSDE3bu7udcVHWFTxvlM=" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "PasswordHash", "Salt" },
                values: new object[] { new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6JVKH2BWRFvRztp+4eeFf8mfPmft4cmejR8wO9Vy3cs=", "4hwB3CKniFaVByltL9svY2EP7bbmBWjij34QAMN3LUY=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
