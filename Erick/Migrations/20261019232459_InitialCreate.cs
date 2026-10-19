using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erick.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Folhas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    CPF = table.Column<string>(type: "TEXT", nullable: false),
                    Mes = table.Column<int>(type: "INTEGER", nullable: false),
                    Ano = table.Column<int>(type: "INTEGER", nullable: false),
                    horasTrabalhadas = table.Column<double>(type: "REAL", nullable: false),
                    ValorHora = table.Column<double>(type: "REAL", nullable: false),
                    ValorBruto = table.Column<double>(type: "REAL", nullable: false),
                    ImpostoRenda = table.Column<double>(type: "REAL", nullable: false),
                    inss = table.Column<double>(type: "REAL", nullable: false),
                    fgts = table.Column<double>(type: "REAL", nullable: false),
                    SalarioLiquido = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folhas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folhas");
        }
    }
}
