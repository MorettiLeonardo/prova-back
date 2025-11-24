using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chamados",
                columns: table => new
                {
                    ChamadoId = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chamados", x => x.ChamadoId);
                });

            migrationBuilder.InsertData(
                table: "Chamados",
                columns: new[] { "ChamadoId", "CriadoEm", "Descricao", "Status" },
                values: new object[,]
                {
                    { "2f1b7dc1-3b9a-4e1a-a389-7f5d2f1c8f3e", new DateTime(2025, 11, 27, 19, 33, 17, 731, DateTimeKind.Local).AddTicks(882), "Trocar tinta da impressora", "Aberto" },
                    { "6a8b3e4d-5e4e-4f7e-bdc9-9181e456ad0e", new DateTime(2025, 12, 1, 19, 33, 17, 731, DateTimeKind.Local).AddTicks(870), "Formatar computador", "Aberto" },
                    { "e5d4a7b9-1f9e-4c4a-ae3b-5b7c1a9d2e3f", new DateTime(2025, 12, 8, 19, 33, 17, 731, DateTimeKind.Local).AddTicks(889), "Trocar teclado", "Aberto" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chamados");
        }
    }
}
