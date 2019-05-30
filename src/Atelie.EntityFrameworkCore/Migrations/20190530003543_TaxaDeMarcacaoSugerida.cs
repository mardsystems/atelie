using Microsoft.EntityFrameworkCore.Migrations;

namespace Atelie.Migrations
{
    public partial class TaxaDeMarcacaoSugerida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TaxaDeMarcacaoSugerida",
                table: "PlanosComerciais",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaxaDeMarcacaoSugerida",
                table: "PlanosComerciais");
        }
    }
}
