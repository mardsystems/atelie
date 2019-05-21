using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Atelie.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fabricantes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Site = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeioDePagamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeioDePagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    CNPJ = table.Column<string>(nullable: true),
                    Site = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    Sigla = table.Column<string>(nullable: false),
                    NomeNoSingular = table.Column<string>(nullable: true),
                    NomeNoPlural = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.Sigla);
                });

            migrationBuilder.CreateTable(
                name: "ContatoDeEmail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Principal = table.Column<bool>(nullable: false),
                    Email_Endereco = table.Column<string>(nullable: true),
                    PessoaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContatoDeEmail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContatoDeEmail_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContatoDeTelefone",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Principal = table.Column<bool>(nullable: false),
                    Telefone_DDD = table.Column<string>(nullable: true),
                    Telefone_Numero = table.Column<string>(nullable: true),
                    Telefone_Tipo = table.Column<int>(nullable: false),
                    PessoaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContatoDeTelefone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContatoDeTelefone_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisponibilidadesDeMeiosDePagamento",
                columns: table => new
                {
                    FornecedorId = table.Column<int>(nullable: false),
                    MeioDePagamentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisponibilidadesDeMeiosDePagamento", x => new { x.FornecedorId, x.MeioDePagamentoId });
                    table.ForeignKey(
                        name: "FK_DisponibilidadesDeMeiosDePagamento_Pessoas_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisponibilidadesDeMeiosDePagamento_MeioDePagamento_MeioDePagamentoId",
                        column: x => x.MeioDePagamentoId,
                        principalTable: "MeioDePagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Componentes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Version = table.Column<byte[]>(nullable: true),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    ComponentePaiId = table.Column<int>(nullable: true),
                    UnidadePadraoSigla = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Componentes_Componentes_ComponentePaiId",
                        column: x => x.ComponentePaiId,
                        principalTable: "Componentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Componentes_Unidades_UnidadePadraoSigla",
                        column: x => x.UnidadePadraoSigla,
                        principalTable: "Unidades",
                        principalColumn: "Sigla",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FabricacoesDeComponentes",
                columns: table => new
                {
                    FabricanteId = table.Column<int>(nullable: false),
                    ComponenteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FabricacoesDeComponentes", x => new { x.FabricanteId, x.ComponenteId });
                    table.ForeignKey(
                        name: "FK_FabricacoesDeComponentes_Componentes_ComponenteId",
                        column: x => x.ComponenteId,
                        principalTable: "Componentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FabricacoesDeComponentes_Fabricantes_FabricanteId",
                        column: x => x.FabricanteId,
                        principalTable: "Fabricantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materiais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Version = table.Column<byte[]>(nullable: true),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    CustoPadrao = table.Column<decimal>(type: "DECIMAL (18, 2)", nullable: true),
                    Cor = table.Column<string>(nullable: true),
                    Tamanho = table.Column<double>(nullable: false),
                    UnidadeSigla = table.Column<string>(nullable: true),
                    FabricanteId = table.Column<int>(nullable: false),
                    ComponenteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materiais_Componentes_ComponenteId",
                        column: x => x.ComponenteId,
                        principalTable: "Componentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materiais_Fabricantes_FabricanteId",
                        column: x => x.FabricanteId,
                        principalTable: "Fabricantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materiais_Unidades_UnidadeSigla",
                        column: x => x.UnidadeSigla,
                        principalTable: "Unidades",
                        principalColumn: "Sigla",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FornecimentosDeMateriais",
                columns: table => new
                {
                    FornecedorId = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false),
                    NomeComercial = table.Column<string>(nullable: true),
                    UltimoPreco = table.Column<decimal>(type: "DECIMAL (18, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FornecimentosDeMateriais", x => new { x.FornecedorId, x.MaterialId });
                    table.ForeignKey(
                        name: "FK_FornecimentosDeMateriais_Pessoas_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FornecimentosDeMateriais_Materiais_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Fabricantes",
                columns: new[] { "Id", "Marca", "Nome", "Site" },
                values: new object[,]
                {
                    { 1, "Genérica", "Genérico", null },
                    { 16, "Helioplast", "Helioplast", "http://helioplast.com.br" },
                    { 15, "YKK", "YKK", "https://www.ykkfastening.com" },
                    { 14, "Werner", "Werner", "https://wernertecidos.com.br" },
                    { 13, "Tekla", "Tekla", "http://www.tekla.com.br" },
                    { 12, "Speedpel", "Speedpel", "http://www.speedpel.com.br" },
                    { 11, "RenauxView", "RenauxView", "https://renauxview.com.br" },
                    { 10, "Setta", "Linhas Setta", "http://www.setta.com.br" },
                    { 17, "Público Alvo", "Público Alvo Embalagens", "https://www.publicoalvoembalagens.com.br" },
                    { 8, "Lamar", "Lamar Etiquetas", "http://www.etiquetaslamar.com.br" },
                    { 7, "Picardie", "Lainière de Picardie", "http://www.lainieredepicardie.com.br" },
                    { 6, "Helvetia", "Helvetia", "https://www.helvetia.com.br" },
                    { 5, "Eberler", "Eberler Fashion", "http://www.eberlefashion.com.br" },
                    { 4, "Cordex", "Cordex", "https://www.cordex.com.br" },
                    { 3, "Coats", "Coats", "http://www.coatscorrente.com.br" },
                    { 2, "Baxmann", "Baxmann", "https://www.baxmann.com.br" },
                    { 9, "Bonfio", "Linhas Bonfio", "http://www.bonfio.com.br" }
                });

            migrationBuilder.InsertData(
                table: "Pessoas",
                columns: new[] { "Id", "Discriminator", "Nome", "CNPJ", "Site" },
                values: new object[,]
                {
                    { 12, "Fornecedor", "Oeste Aviamentos", null, "https://www.oesteaviamentos.com" },
                    { 11, "Fornecedor", "Speedpel", null, "http://www.speedpel.com.br" },
                    { 10, "Fornecedor", "Público Alvo", null, "https://www.publicoalvoembalagens.com.br" },
                    { 9, "Fornecedor", "Helioplast", null, "http://helioplast.com.br" },
                    { 8, "Fornecedor", "Caçula de São Cristovão", null, null },
                    { 7, "Fornecedor", "Amsterdam", null, null },
                    { 4, "Fornecedor", "Helvetia", null, "https://www.helvetia.com.br" },
                    { 5, "Fornecedor", "Lamar Etiquetas", null, "http://www.etiquetaslamar.com.br" },
                    { 3, "Fornecedor", "Casa Ferro", null, "https://www.armarinhos25.com.br" },
                    { 2, "Fornecedor", "Armarinhos 25", null, "https://www.armarinhos25.com.br" },
                    { 1, "Fornecedor", "Werner", null, "https://wernertecidos.com.br" },
                    { 6, "Fornecedor", "Motta Carvalho", null, null }
                });

            migrationBuilder.InsertData(
                table: "Unidades",
                columns: new[] { "Sigla", "Discriminator", "NomeNoPlural", "NomeNoSingular" },
                values: new object[,]
                {
                    { "J", "UnidadeDeMedida", "Jardas", "Jarda" },
                    { "unid", "UnidadeDeMedida", "Unidades", "Unidade" },
                    { "m", "UnidadeDeMedida", "Metros", "Metro" },
                    { "cm", "UnidadeDeMedida", "Centímetros", "Centímetro" }
                });

            migrationBuilder.InsertData(
                table: "Componentes",
                columns: new[] { "Id", "ComponentePaiId", "CreateBy", "CreateOn", "ModifiedBy", "ModifiedOn", "Nome", "UnidadePadraoSigla", "Version" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Botão", "unid", null },
                    { 10, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Entretela", "unid", null },
                    { 11, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Etiqueta", "unid", null },
                    { 17, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ilhós", "unid", null },
                    { 21, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Plástico", "unid", null },
                    { 25, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tag", "unid", null },
                    { 31, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Viés", "unid", null },
                    { 33, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ziper", "unid", null },
                    { 6, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cordão", "m", null },
                    { 7, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cordinha", "m", null },
                    { 9, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elástico", "m", null },
                    { 15, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fio", "m", null },
                    { 18, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Linha", "m", null },
                    { 19, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Papel", "m", null },
                    { 26, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tecido", "m", null }
                });

            migrationBuilder.InsertData(
                table: "Componentes",
                columns: new[] { "Id", "ComponentePaiId", "CreateBy", "CreateOn", "ModifiedBy", "ModifiedOn", "Nome", "UnidadePadraoSigla", "Version" },
                values: new object[,]
                {
                    { 2, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Botão com casa", "unid", null },
                    { 28, 26, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tecido (cupro)", "m", null },
                    { 27, 26, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tecido (brim)", "m", null },
                    { 20, 19, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Papel de embrulho", "m", null },
                    { 16, 15, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fio para overlock", "m", null },
                    { 29, 26, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tecido (seda)", "m", null },
                    { 32, 31, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Viés para cordão", "unid", null },
                    { 24, 21, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bobinas plásticas", "unid", null },
                    { 8, 7, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cordinha para o tag", "m", null },
                    { 22, 21, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sacola plástica", "unid", null },
                    { 14, 11, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Etiqueta de tamanho", "unid", null },
                    { 13, 11, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Etiqueta de composição", "unid", null },
                    { 12, 11, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Etiqueta bordada", "unid", null },
                    { 3, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Botão de pressão", "unid", null },
                    { 23, 21, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sacos plástica", "unid", null },
                    { 30, 26, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tecido (seda lavada)", "m", null }
                });

            migrationBuilder.InsertData(
                table: "FabricacoesDeComponentes",
                columns: new[] { "FabricanteId", "ComponenteId" },
                values: new object[,]
                {
                    { 9, 18 },
                    { 10, 18 }
                });

            migrationBuilder.InsertData(
                table: "Materiais",
                columns: new[] { "Id", "ComponenteId", "Cor", "CreateBy", "CreateOn", "CustoPadrao", "Descricao", "FabricanteId", "ModifiedBy", "ModifiedOn", "Nome", "Tamanho", "UnidadeSigla", "Version" },
                values: new object[,]
                {
                    { 1, 18, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 10, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Linha Xik Poliester 2000J N. 120", 0.0, null, null },
                    { 2, 18, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 10, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Linha Xik Poliester 5000J N. 120", 0.0, null, null },
                    { 3, 10, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 7, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Entretela 2805/325 da marca Lainière, 1,50cmX25cm", 0.0, null, null }
                });

            migrationBuilder.InsertData(
                table: "Componentes",
                columns: new[] { "Id", "ComponentePaiId", "CreateBy", "CreateOn", "ModifiedBy", "ModifiedOn", "Nome", "UnidadePadraoSigla", "Version" },
                values: new object[,]
                {
                    { 4, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Botão de pressão grande", "unid", null },
                    { 5, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Botão de pressão pequeno", "unid", null }
                });

            migrationBuilder.InsertData(
                table: "FabricacoesDeComponentes",
                columns: new[] { "FabricanteId", "ComponenteId" },
                values: new object[,]
                {
                    { 16, 22 },
                    { 17, 22 },
                    { 16, 23 },
                    { 16, 24 }
                });

            migrationBuilder.InsertData(
                table: "Materiais",
                columns: new[] { "Id", "ComponenteId", "Cor", "CreateBy", "CreateOn", "CustoPadrao", "Descricao", "FabricanteId", "ModifiedBy", "ModifiedOn", "Nome", "Tamanho", "UnidadeSigla", "Version" },
                values: new object[,]
                {
                    { 8, 22, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "São entregues em pacotes de papel craft com quantidades programadas pelos clientes ou em caixas de papelão (sob consulta).", 16, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sacos com aba - PEAD (polietileno de alta densidade)", 0.0, null, null },
                    { 9, 22, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 17, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Plástico fosco transparente (alta densidade) medindo 46 x 60 x 18 com alça especial", 0.0, null, null },
                    { 6, 24, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 14, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tecido artigo 1198/6", 0.0, null, null },
                    { 7, 24, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 14, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tecido artigo 1198/6 com defeito", 0.0, null, null },
                    { 4, 16, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 9, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fio da marca Bonfio 300g", 0.0, null, null },
                    { 5, 16, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fio Soltex 300g da marca Coats Corrente", 0.0, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Componentes_ComponentePaiId",
                table: "Componentes",
                column: "ComponentePaiId");

            migrationBuilder.CreateIndex(
                name: "IX_Componentes_UnidadePadraoSigla",
                table: "Componentes",
                column: "UnidadePadraoSigla");

            migrationBuilder.CreateIndex(
                name: "IX_ContatoDeEmail_PessoaId",
                table: "ContatoDeEmail",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_ContatoDeTelefone_PessoaId",
                table: "ContatoDeTelefone",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_DisponibilidadesDeMeiosDePagamento_MeioDePagamentoId",
                table: "DisponibilidadesDeMeiosDePagamento",
                column: "MeioDePagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_FabricacoesDeComponentes_ComponenteId",
                table: "FabricacoesDeComponentes",
                column: "ComponenteId");

            migrationBuilder.CreateIndex(
                name: "IX_FornecimentosDeMateriais_MaterialId",
                table: "FornecimentosDeMateriais",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Materiais_ComponenteId",
                table: "Materiais",
                column: "ComponenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Materiais_FabricanteId",
                table: "Materiais",
                column: "FabricanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Materiais_UnidadeSigla",
                table: "Materiais",
                column: "UnidadeSigla");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContatoDeEmail");

            migrationBuilder.DropTable(
                name: "ContatoDeTelefone");

            migrationBuilder.DropTable(
                name: "DisponibilidadesDeMeiosDePagamento");

            migrationBuilder.DropTable(
                name: "FabricacoesDeComponentes");

            migrationBuilder.DropTable(
                name: "FornecimentosDeMateriais");

            migrationBuilder.DropTable(
                name: "MeioDePagamento");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Materiais");

            migrationBuilder.DropTable(
                name: "Componentes");

            migrationBuilder.DropTable(
                name: "Fabricantes");

            migrationBuilder.DropTable(
                name: "Unidades");
        }
    }
}
