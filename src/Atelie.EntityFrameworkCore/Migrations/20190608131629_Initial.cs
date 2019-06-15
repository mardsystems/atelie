using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Atelie.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Codigo = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "PlanosComerciais",
                columns: table => new
                {
                    Codigo = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    RendaBrutaMensal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanosComerciais", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Recurso",
                columns: table => new
                {
                    Descricao = table.Column<string>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    Custo = table.Column<decimal>(nullable: false),
                    Unidades = table.Column<int>(nullable: false),
                    ModeloCodigo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recurso", x => x.Descricao);
                    table.ForeignKey(
                        name: "FK_Recurso_Modelos_ModeloCodigo",
                        column: x => x.ModeloCodigo,
                        principalTable: "Modelos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Custo",
                columns: table => new
                {
                    Descricao = table.Column<string>(nullable: false),
                    PlanoComercialCodigo = table.Column<string>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    Percentual = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Custo", x => new { x.PlanoComercialCodigo, x.Descricao });
                    table.ForeignKey(
                        name: "FK_Custo_PlanosComerciais_PlanoComercialCodigo",
                        column: x => x.PlanoComercialCodigo,
                        principalTable: "PlanosComerciais",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemDePlanoComercial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    PlanoComercialCodigo = table.Column<string>(nullable: false),
                    Margem = table.Column<decimal>(nullable: false),
                    MargemPercentual = table.Column<decimal>(nullable: false),
                    TaxaDeMarcacaoSugerida = table.Column<decimal>(nullable: true),
                    PrecoDeVendaDesejado = table.Column<decimal>(nullable: true),
                    ModeloCodigo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDePlanoComercial", x => new { x.PlanoComercialCodigo, x.Id });
                    table.ForeignKey(
                        name: "FK_ItemDePlanoComercial_Modelos_ModeloCodigo",
                        column: x => x.ModeloCodigo,
                        principalTable: "Modelos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemDePlanoComercial_PlanosComerciais_PlanoComercialCodigo",
                        column: x => x.PlanoComercialCodigo,
                        principalTable: "PlanosComerciais",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "Codigo", "Nome" },
                values: new object[] { "TM01", "Tati Model 01" });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "Codigo", "Nome" },
                values: new object[] { "TM02", "Tati Model 02" });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "Codigo", "Nome" },
                values: new object[] { "TM03", "Tati Model 03" });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "Codigo", "Nome" },
                values: new object[] { "TM04", "Tati Model 04" });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "Codigo", "Nome" },
                values: new object[] { "TM05", "Tati Model 05" });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "Codigo", "Nome" },
                values: new object[] { "TM06", "Tati Model 06" });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "Codigo", "Nome" },
                values: new object[] { "TM07", "Tati Model 07" });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "Codigo", "Nome" },
                values: new object[] { "TM08", "Tati Model 08" });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "Codigo", "Nome" },
                values: new object[] { "TM09", "Tati Model 09" });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "Codigo", "Nome" },
                values: new object[] { "TM10", "Tati Model 10" });

            migrationBuilder.InsertData(
                table: "PlanosComerciais",
                columns: new[] { "Codigo", "Data", "Nome", "RendaBrutaMensal" },
                values: new object[] { "PC01.A", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Normal", 6000m });

            migrationBuilder.InsertData(
                table: "PlanosComerciais",
                columns: new[] { "Codigo", "Data", "Nome", "RendaBrutaMensal" },
                values: new object[] { "PC01.B", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moderado", 0m });

            migrationBuilder.InsertData(
                table: "PlanosComerciais",
                columns: new[] { "Codigo", "Data", "Nome", "RendaBrutaMensal" },
                values: new object[] { "PC01.C", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ousado", 0m });

            migrationBuilder.InsertData(
                table: "Custo",
                columns: new[] { "PlanoComercialCodigo", "Descricao", "Percentual", "Tipo", "Valor" },
                values: new object[] { "PC01.A", "Comissão", 10m, 1, 0m });

            migrationBuilder.InsertData(
                table: "Custo",
                columns: new[] { "PlanoComercialCodigo", "Descricao", "Percentual", "Tipo", "Valor" },
                values: new object[] { "PC01.A", "Prolabore", 0m, 0, 1000m });

            migrationBuilder.InsertData(
                table: "Custo",
                columns: new[] { "PlanoComercialCodigo", "Descricao", "Percentual", "Tipo", "Valor" },
                values: new object[] { "PC01.A", "Aluguel", 0m, 0, 900m });

            migrationBuilder.InsertData(
                table: "Custo",
                columns: new[] { "PlanoComercialCodigo", "Descricao", "Percentual", "Tipo", "Valor" },
                values: new object[] { "PC01.A", "Cartão", 10m, 1, 0m });

            migrationBuilder.InsertData(
                table: "Custo",
                columns: new[] { "PlanoComercialCodigo", "Descricao", "Percentual", "Tipo", "Valor" },
                values: new object[] { "PC01.A", "Perda", 2m, 1, 0m });

            migrationBuilder.InsertData(
                table: "ItemDePlanoComercial",
                columns: new[] { "PlanoComercialCodigo", "Id", "Margem", "MargemPercentual", "ModeloCodigo", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "PC01.B", 6, 0m, 0m, "TM06", null, null });

            migrationBuilder.InsertData(
                table: "ItemDePlanoComercial",
                columns: new[] { "PlanoComercialCodigo", "Id", "Margem", "MargemPercentual", "ModeloCodigo", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "PC01.B", 7, 0m, 0m, "TM07", null, null });

            migrationBuilder.InsertData(
                table: "ItemDePlanoComercial",
                columns: new[] { "PlanoComercialCodigo", "Id", "Margem", "MargemPercentual", "ModeloCodigo", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "PC01.B", 8, 0m, 0m, "TM08", null, null });

            migrationBuilder.InsertData(
                table: "ItemDePlanoComercial",
                columns: new[] { "PlanoComercialCodigo", "Id", "Margem", "MargemPercentual", "ModeloCodigo", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "PC01.B", 9, 0m, 0m, "TM09", null, null });

            migrationBuilder.InsertData(
                table: "ItemDePlanoComercial",
                columns: new[] { "PlanoComercialCodigo", "Id", "Margem", "MargemPercentual", "ModeloCodigo", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "PC01.B", 10, 0m, 0m, "TM10", null, null });

            migrationBuilder.InsertData(
                table: "ItemDePlanoComercial",
                columns: new[] { "PlanoComercialCodigo", "Id", "Margem", "MargemPercentual", "ModeloCodigo", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "PC01.B", 1, 0m, 0m, "TM01", null, null });

            migrationBuilder.InsertData(
                table: "ItemDePlanoComercial",
                columns: new[] { "PlanoComercialCodigo", "Id", "Margem", "MargemPercentual", "ModeloCodigo", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "PC01.C", 5, 0m, 0m, "TM05", null, null });

            migrationBuilder.InsertData(
                table: "ItemDePlanoComercial",
                columns: new[] { "PlanoComercialCodigo", "Id", "Margem", "MargemPercentual", "ModeloCodigo", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "PC01.C", 6, 0m, 0m, "TM06", null, null });

            migrationBuilder.InsertData(
                table: "ItemDePlanoComercial",
                columns: new[] { "PlanoComercialCodigo", "Id", "Margem", "MargemPercentual", "ModeloCodigo", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "PC01.C", 7, 0m, 0m, "TM07", null, null });

            migrationBuilder.InsertData(
                table: "ItemDePlanoComercial",
                columns: new[] { "PlanoComercialCodigo", "Id", "Margem", "MargemPercentual", "ModeloCodigo", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "PC01.C", 8, 0m, 0m, "TM08", null, null });

            migrationBuilder.InsertData(
                table: "ItemDePlanoComercial",
                columns: new[] { "PlanoComercialCodigo", "Id", "Margem", "MargemPercentual", "ModeloCodigo", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "PC01.B", 5, 0m, 0m, "TM05", null, null });

            migrationBuilder.InsertData(
                table: "ItemDePlanoComercial",
                columns: new[] { "PlanoComercialCodigo", "Id", "Margem", "MargemPercentual", "ModeloCodigo", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "PC01.B", 4, 0m, 0m, "TM04", null, null });

            migrationBuilder.InsertData(
                table: "ItemDePlanoComercial",
                columns: new[] { "PlanoComercialCodigo", "Id", "Margem", "MargemPercentual", "ModeloCodigo", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "PC01.C", 10, 0m, 0m, "TM10", null, null });

            migrationBuilder.InsertData(
                table: "ItemDePlanoComercial",
                columns: new[] { "PlanoComercialCodigo", "Id", "Margem", "MargemPercentual", "ModeloCodigo", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "PC01.B", 2, 0m, 0m, "TM02", null, null });

            migrationBuilder.InsertData(
                table: "ItemDePlanoComercial",
                columns: new[] { "PlanoComercialCodigo", "Id", "Margem", "MargemPercentual", "ModeloCodigo", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "PC01.C", 9, 0m, 0m, "TM09", null, null });

            migrationBuilder.InsertData(
                table: "ItemDePlanoComercial",
                columns: new[] { "PlanoComercialCodigo", "Id", "Margem", "MargemPercentual", "ModeloCodigo", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "PC01.A", 10, 0m, 0m, "TM10", null, null });

            migrationBuilder.InsertData(
                table: "ItemDePlanoComercial",
                columns: new[] { "PlanoComercialCodigo", "Id", "Margem", "MargemPercentual", "ModeloCodigo", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "PC01.A", 3, 0m, 0m, "TM03", null, null });

            migrationBuilder.InsertData(
                table: "ItemDePlanoComercial",
                columns: new[] { "PlanoComercialCodigo", "Id", "Margem", "MargemPercentual", "ModeloCodigo", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "PC01.A", 2, 0m, 0m, "TM02", null, null });

            migrationBuilder.InsertData(
                table: "ItemDePlanoComercial",
                columns: new[] { "PlanoComercialCodigo", "Id", "Margem", "MargemPercentual", "ModeloCodigo", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "PC01.A", 1, 0m, 1.93m, "TM01", null, null });

            migrationBuilder.InsertData(
                table: "ItemDePlanoComercial",
                columns: new[] { "PlanoComercialCodigo", "Id", "Margem", "MargemPercentual", "ModeloCodigo", "PrecoDeVendaDesejado", "TaxaDeMarcacaoSugerida" },
                values: new object[] { "PC01.B", 3, 0m, 0m, "TM03", null, null });

            migrationBuilder.InsertData(
                table: "Recurso",
                columns: new[] { "Descricao", "Custo", "ModeloCodigo", "Tipo", "Unidades" },
                values: new object[] { "Costureira", 5m, "TM01", 2, 1 });

            migrationBuilder.InsertData(
                table: "Recurso",
                columns: new[] { "Descricao", "Custo", "ModeloCodigo", "Tipo", "Unidades" },
                values: new object[] { "Transporte", 100m, "TM01", 1, 50 });

            migrationBuilder.InsertData(
                table: "Recurso",
                columns: new[] { "Descricao", "Custo", "ModeloCodigo", "Tipo", "Unidades" },
                values: new object[] { "Outros", 5m, "TM01", 0, 1 });

            migrationBuilder.InsertData(
                table: "Recurso",
                columns: new[] { "Descricao", "Custo", "ModeloCodigo", "Tipo", "Unidades" },
                values: new object[] { "Linha", 4m, "TM01", 0, 20 });

            migrationBuilder.InsertData(
                table: "Recurso",
                columns: new[] { "Descricao", "Custo", "ModeloCodigo", "Tipo", "Unidades" },
                values: new object[] { "Tecido", 20m, "TM01", 0, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_ItemDePlanoComercial_ModeloCodigo",
                table: "ItemDePlanoComercial",
                column: "ModeloCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Recurso_ModeloCodigo",
                table: "Recurso",
                column: "ModeloCodigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Custo");

            migrationBuilder.DropTable(
                name: "ItemDePlanoComercial");

            migrationBuilder.DropTable(
                name: "Recurso");

            migrationBuilder.DropTable(
                name: "PlanosComerciais");

            migrationBuilder.DropTable(
                name: "Modelos");
        }
    }
}
