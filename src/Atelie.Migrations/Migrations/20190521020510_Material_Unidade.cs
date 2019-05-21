using Microsoft.EntityFrameworkCore.Migrations;

namespace Atelie.Migrations
{
    public partial class Material_Unidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Materiais",
                keyColumn: "Id",
                keyValue: 1,
                column: "UnidadeSigla",
                value: "m");

            migrationBuilder.UpdateData(
                table: "Materiais",
                keyColumn: "Id",
                keyValue: 2,
                column: "UnidadeSigla",
                value: "m");

            migrationBuilder.UpdateData(
                table: "Materiais",
                keyColumn: "Id",
                keyValue: 3,
                column: "UnidadeSigla",
                value: "unid");

            migrationBuilder.UpdateData(
                table: "Materiais",
                keyColumn: "Id",
                keyValue: 4,
                column: "UnidadeSigla",
                value: "m");

            migrationBuilder.UpdateData(
                table: "Materiais",
                keyColumn: "Id",
                keyValue: 5,
                column: "UnidadeSigla",
                value: "m");

            migrationBuilder.UpdateData(
                table: "Materiais",
                keyColumn: "Id",
                keyValue: 6,
                column: "UnidadeSigla",
                value: "m");

            migrationBuilder.UpdateData(
                table: "Materiais",
                keyColumn: "Id",
                keyValue: 7,
                column: "UnidadeSigla",
                value: "m");

            migrationBuilder.UpdateData(
                table: "Materiais",
                keyColumn: "Id",
                keyValue: 8,
                column: "UnidadeSigla",
                value: "unid");

            migrationBuilder.UpdateData(
                table: "Materiais",
                keyColumn: "Id",
                keyValue: 9,
                column: "UnidadeSigla",
                value: "unid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Materiais",
                keyColumn: "Id",
                keyValue: 1,
                column: "UnidadeSigla",
                value: null);

            migrationBuilder.UpdateData(
                table: "Materiais",
                keyColumn: "Id",
                keyValue: 2,
                column: "UnidadeSigla",
                value: null);

            migrationBuilder.UpdateData(
                table: "Materiais",
                keyColumn: "Id",
                keyValue: 3,
                column: "UnidadeSigla",
                value: null);

            migrationBuilder.UpdateData(
                table: "Materiais",
                keyColumn: "Id",
                keyValue: 4,
                column: "UnidadeSigla",
                value: null);

            migrationBuilder.UpdateData(
                table: "Materiais",
                keyColumn: "Id",
                keyValue: 5,
                column: "UnidadeSigla",
                value: null);

            migrationBuilder.UpdateData(
                table: "Materiais",
                keyColumn: "Id",
                keyValue: 6,
                column: "UnidadeSigla",
                value: null);

            migrationBuilder.UpdateData(
                table: "Materiais",
                keyColumn: "Id",
                keyValue: 7,
                column: "UnidadeSigla",
                value: null);

            migrationBuilder.UpdateData(
                table: "Materiais",
                keyColumn: "Id",
                keyValue: 8,
                column: "UnidadeSigla",
                value: null);

            migrationBuilder.UpdateData(
                table: "Materiais",
                keyColumn: "Id",
                keyValue: 9,
                column: "UnidadeSigla",
                value: null);
        }
    }
}
