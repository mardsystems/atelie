using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Atelie.Migrations
{
    public partial class PlanoComercial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FerramentaDeProducao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FerramentaDeProducao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Investimentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<int>(nullable: false),
                    LivrosEObjetos = table.Column<decimal>(nullable: false),
                    Viagens = table.Column<decimal>(nullable: false),
                    Materiais = table.Column<decimal>(nullable: false),
                    MaoDeObra = table.Column<decimal>(nullable: false),
                    Terceiros = table.Column<decimal>(nullable: false),
                    CustoTotal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Codigo = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Preco = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "PlanosComerciais",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    ReceitaBrutaMensal = table.Column<decimal>(nullable: false),
                    CustoFixo = table.Column<decimal>(nullable: false),
                    CustoFixoPercentual = table.Column<decimal>(nullable: false),
                    CustoVariavel = table.Column<decimal>(nullable: false),
                    CustoPercentual = table.Column<decimal>(nullable: false),
                    Margem = table.Column<decimal>(nullable: false),
                    MargemPercentual = table.Column<decimal>(nullable: false),
                    TaxaDeMarcacao = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanosComerciais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TamanhoDeModelo",
                columns: table => new
                {
                    Sigla = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Posicao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TamanhoDeModelo", x => x.Sigla);
                });

            migrationBuilder.CreateTable(
                name: "UnidadeDeCusto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadeDeCusto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AplicacaoDeInvestimento",
                columns: table => new
                {
                    ModeloCodigo = table.Column<string>(nullable: false),
                    InvestimentoId = table.Column<int>(nullable: false),
                    ModeloCodigo1 = table.Column<string>(nullable: true),
                    Peso = table.Column<int>(nullable: false),
                    CustoProporcional = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AplicacaoDeInvestimento", x => new { x.ModeloCodigo, x.InvestimentoId });
                    table.ForeignKey(
                        name: "FK_AplicacaoDeInvestimento_Investimentos_InvestimentoId",
                        column: x => x.InvestimentoId,
                        principalTable: "Investimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AplicacaoDeInvestimento_Modelos_ModeloCodigo1",
                        column: x => x.ModeloCodigo1,
                        principalTable: "Modelos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EtapaDeProducao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ordem = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    ModeloCodigo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtapaDeProducao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EtapaDeProducao_Modelos_ModeloCodigo",
                        column: x => x.ModeloCodigo,
                        principalTable: "Modelos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustoFixo",
                columns: table => new
                {
                    Descricao = table.Column<string>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    ValorPercentual = table.Column<decimal>(nullable: false),
                    PlanoComercialId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustoFixo", x => x.Descricao);
                    table.ForeignKey(
                        name: "FK_CustoFixo_PlanosComerciais_PlanoComercialId",
                        column: x => x.PlanoComercialId,
                        principalTable: "PlanosComerciais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustoVariavel",
                columns: table => new
                {
                    Descricao = table.Column<string>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    ValorPercentual = table.Column<decimal>(nullable: false),
                    PlanoComercialId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustoVariavel", x => x.Descricao);
                    table.ForeignKey(
                        name: "FK_CustoVariavel_PlanosComerciais_PlanoComercialId",
                        column: x => x.PlanoComercialId,
                        principalTable: "PlanosComerciais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemDePlanoComercial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlanoComercialId = table.Column<string>(nullable: true),
                    ModeloCodigo = table.Column<string>(nullable: true),
                    CustoDeProducao_CustoDeComposicao = table.Column<decimal>(nullable: false),
                    CustoDeProducao_CustoDeConfeccao = table.Column<decimal>(nullable: false),
                    Margem = table.Column<decimal>(nullable: false),
                    MargemPercentual = table.Column<decimal>(nullable: false),
                    PrecoDeVenda = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDePlanoComercial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemDePlanoComercial_Modelos_ModeloCodigo",
                        column: x => x.ModeloCodigo,
                        principalTable: "Modelos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemDePlanoComercial_PlanosComerciais_PlanoComercialId",
                        column: x => x.PlanoComercialId,
                        principalTable: "PlanosComerciais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NecessidadeDeMaterial",
                columns: table => new
                {
                    ModeloCodigo = table.Column<string>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false),
                    TamanhoDeModeloSigla = table.Column<string>(nullable: true),
                    Quantidade = table.Column<double>(nullable: false),
                    CustoPadrao = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NecessidadeDeMaterial", x => new { x.ModeloCodigo, x.MaterialId });
                    table.ForeignKey(
                        name: "FK_NecessidadeDeMaterial_Materiais_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NecessidadeDeMaterial_Modelos_ModeloCodigo",
                        column: x => x.ModeloCodigo,
                        principalTable: "Modelos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NecessidadeDeMaterial_TamanhoDeModelo_TamanhoDeModeloSigla",
                        column: x => x.TamanhoDeModeloSigla,
                        principalTable: "TamanhoDeModelo",
                        principalColumn: "Sigla",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeRecurso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Interno = table.Column<bool>(nullable: false),
                    CustoPadrao = table.Column<decimal>(nullable: true),
                    MaximoDeHorasPorDia = table.Column<double>(nullable: true),
                    UnidadeDeCustoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeRecurso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoDeRecurso_UnidadeDeCusto_UnidadeDeCustoId",
                        column: x => x.UnidadeDeCustoId,
                        principalTable: "UnidadeDeCusto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NecessidadeDeFerramentaDeProducao",
                columns: table => new
                {
                    EtapaDeProducaoId = table.Column<int>(nullable: false),
                    FerramentaId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NecessidadeDeFerramentaDeProducao", x => new { x.EtapaDeProducaoId, x.FerramentaId });
                    table.ForeignKey(
                        name: "FK_NecessidadeDeFerramentaDeProducao_EtapaDeProducao_EtapaDeProducaoId",
                        column: x => x.EtapaDeProducaoId,
                        principalTable: "EtapaDeProducao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NecessidadeDeFerramentaDeProducao_FerramentaDeProducao_FerramentaId",
                        column: x => x.FerramentaId,
                        principalTable: "FerramentaDeProducao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NecessidadeDeTipoDeRecurso",
                columns: table => new
                {
                    EtapaId = table.Column<int>(nullable: false),
                    TipoDeRecursoId = table.Column<int>(nullable: false),
                    Tarefa = table.Column<string>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false),
                    Tempo = table.Column<double>(nullable: false),
                    CustoPadrao = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NecessidadeDeTipoDeRecurso", x => new { x.EtapaId, x.TipoDeRecursoId });
                    table.ForeignKey(
                        name: "FK_NecessidadeDeTipoDeRecurso_EtapaDeProducao_EtapaId",
                        column: x => x.EtapaId,
                        principalTable: "EtapaDeProducao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NecessidadeDeTipoDeRecurso_TipoDeRecurso_TipoDeRecursoId",
                        column: x => x.TipoDeRecursoId,
                        principalTable: "TipoDeRecurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AplicacaoDeInvestimento_InvestimentoId",
                table: "AplicacaoDeInvestimento",
                column: "InvestimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_AplicacaoDeInvestimento_ModeloCodigo1",
                table: "AplicacaoDeInvestimento",
                column: "ModeloCodigo1");

            migrationBuilder.CreateIndex(
                name: "IX_CustoFixo_PlanoComercialId",
                table: "CustoFixo",
                column: "PlanoComercialId");

            migrationBuilder.CreateIndex(
                name: "IX_CustoVariavel_PlanoComercialId",
                table: "CustoVariavel",
                column: "PlanoComercialId");

            migrationBuilder.CreateIndex(
                name: "IX_EtapaDeProducao_ModeloCodigo",
                table: "EtapaDeProducao",
                column: "ModeloCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDePlanoComercial_ModeloCodigo",
                table: "ItemDePlanoComercial",
                column: "ModeloCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDePlanoComercial_PlanoComercialId",
                table: "ItemDePlanoComercial",
                column: "PlanoComercialId");

            migrationBuilder.CreateIndex(
                name: "IX_NecessidadeDeFerramentaDeProducao_FerramentaId",
                table: "NecessidadeDeFerramentaDeProducao",
                column: "FerramentaId");

            migrationBuilder.CreateIndex(
                name: "IX_NecessidadeDeMaterial_MaterialId",
                table: "NecessidadeDeMaterial",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_NecessidadeDeMaterial_TamanhoDeModeloSigla",
                table: "NecessidadeDeMaterial",
                column: "TamanhoDeModeloSigla");

            migrationBuilder.CreateIndex(
                name: "IX_NecessidadeDeTipoDeRecurso_TipoDeRecursoId",
                table: "NecessidadeDeTipoDeRecurso",
                column: "TipoDeRecursoId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoDeRecurso_UnidadeDeCustoId",
                table: "TipoDeRecurso",
                column: "UnidadeDeCustoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AplicacaoDeInvestimento");

            migrationBuilder.DropTable(
                name: "CustoFixo");

            migrationBuilder.DropTable(
                name: "CustoVariavel");

            migrationBuilder.DropTable(
                name: "ItemDePlanoComercial");

            migrationBuilder.DropTable(
                name: "NecessidadeDeFerramentaDeProducao");

            migrationBuilder.DropTable(
                name: "NecessidadeDeMaterial");

            migrationBuilder.DropTable(
                name: "NecessidadeDeTipoDeRecurso");

            migrationBuilder.DropTable(
                name: "Investimentos");

            migrationBuilder.DropTable(
                name: "PlanosComerciais");

            migrationBuilder.DropTable(
                name: "FerramentaDeProducao");

            migrationBuilder.DropTable(
                name: "TamanhoDeModelo");

            migrationBuilder.DropTable(
                name: "EtapaDeProducao");

            migrationBuilder.DropTable(
                name: "TipoDeRecurso");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "UnidadeDeCusto");
        }
    }
}
