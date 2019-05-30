﻿// <auto-generated />
using System;
using Atelie;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Atelie.Migrations
{
    [DbContext(typeof(AtelieDbContext))]
    [Migration("20190530003543_TaxaDeMarcacaoSugerida")]
    partial class TaxaDeMarcacaoSugerida
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("Atelie.Cadastro.Modelos.Modelo", b =>
                {
                    b.Property<string>("Codigo");

                    b.Property<string>("Nome");

                    b.HasKey("Codigo");

                    b.ToTable("Modelos");

                    b.HasData(
                        new
                        {
                            Codigo = "TM01",
                            Nome = "Tati Model 01"
                        },
                        new
                        {
                            Codigo = "TM02",
                            Nome = "Tati Model 02"
                        },
                        new
                        {
                            Codigo = "TM03",
                            Nome = "Tati Model 03"
                        },
                        new
                        {
                            Codigo = "TM04",
                            Nome = "Tati Model 04"
                        },
                        new
                        {
                            Codigo = "TM05",
                            Nome = "Tati Model 05"
                        },
                        new
                        {
                            Codigo = "TM06",
                            Nome = "Tati Model 06"
                        },
                        new
                        {
                            Codigo = "TM07",
                            Nome = "Tati Model 07"
                        },
                        new
                        {
                            Codigo = "TM08",
                            Nome = "Tati Model 08"
                        },
                        new
                        {
                            Codigo = "TM09",
                            Nome = "Tati Model 09"
                        },
                        new
                        {
                            Codigo = "TM10",
                            Nome = "Tati Model 10"
                        });
                });

            modelBuilder.Entity("Atelie.Cadastro.Modelos.Recurso", b =>
                {
                    b.Property<string>("Descricao")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Custo");

                    b.Property<string>("ModeloCodigo");

                    b.Property<int>("Tipo");

                    b.Property<int>("Unidades");

                    b.HasKey("Descricao");

                    b.HasIndex("ModeloCodigo");

                    b.ToTable("Recurso");

                    b.HasData(
                        new
                        {
                            Descricao = "Tecido",
                            Custo = 20m,
                            ModeloCodigo = "TM01",
                            Tipo = 0,
                            Unidades = 2
                        },
                        new
                        {
                            Descricao = "Linha",
                            Custo = 4m,
                            ModeloCodigo = "TM01",
                            Tipo = 0,
                            Unidades = 20
                        },
                        new
                        {
                            Descricao = "Outros",
                            Custo = 5m,
                            ModeloCodigo = "TM01",
                            Tipo = 0,
                            Unidades = 1
                        },
                        new
                        {
                            Descricao = "Transporte",
                            Custo = 100m,
                            ModeloCodigo = "TM01",
                            Tipo = 1,
                            Unidades = 50
                        },
                        new
                        {
                            Descricao = "Costureira",
                            Custo = 5m,
                            ModeloCodigo = "TM01",
                            Tipo = 2,
                            Unidades = 1
                        });
                });

            modelBuilder.Entity("Atelie.Decisoes.Comerciais.Custo", b =>
                {
                    b.Property<string>("PlanoComercialCodigo");

                    b.Property<string>("Descricao");

                    b.Property<decimal>("Percentual");

                    b.Property<int>("Tipo");

                    b.Property<decimal>("Valor");

                    b.HasKey("PlanoComercialCodigo", "Descricao");

                    b.ToTable("Custo");

                    b.HasData(
                        new
                        {
                            PlanoComercialCodigo = "PC01.A",
                            Descricao = "Prolabore",
                            Percentual = 0m,
                            Tipo = 0,
                            Valor = 1000m
                        },
                        new
                        {
                            PlanoComercialCodigo = "PC01.A",
                            Descricao = "Aluguel",
                            Percentual = 0m,
                            Tipo = 0,
                            Valor = 900m
                        },
                        new
                        {
                            PlanoComercialCodigo = "PC01.A",
                            Descricao = "Cartão",
                            Percentual = 10m,
                            Tipo = 1,
                            Valor = 0m
                        },
                        new
                        {
                            PlanoComercialCodigo = "PC01.A",
                            Descricao = "Comissão",
                            Percentual = 10m,
                            Tipo = 1,
                            Valor = 0m
                        },
                        new
                        {
                            PlanoComercialCodigo = "PC01.A",
                            Descricao = "Perda",
                            Percentual = 2m,
                            Tipo = 1,
                            Valor = 0m
                        });
                });

            modelBuilder.Entity("Atelie.Decisoes.Comerciais.ItemDePlanoComercial", b =>
                {
                    b.Property<string>("PlanoComercialCodigo");

                    b.Property<int>("Id");

                    b.Property<string>("ModeloCodigo");

                    b.Property<decimal?>("PrecoDeVendaDesejado");

                    b.HasKey("PlanoComercialCodigo", "Id");

                    b.HasIndex("ModeloCodigo");

                    b.ToTable("ItemDePlanoComercial");

                    b.HasData(
                        new
                        {
                            PlanoComercialCodigo = "PC01.A",
                            Id = 1,
                            ModeloCodigo = "TM01"
                        },
                        new
                        {
                            PlanoComercialCodigo = "PC01.A",
                            Id = 2,
                            ModeloCodigo = "TM02"
                        },
                        new
                        {
                            PlanoComercialCodigo = "PC01.A",
                            Id = 3,
                            ModeloCodigo = "TM03"
                        },
                        new
                        {
                            PlanoComercialCodigo = "PC01.A",
                            Id = 10,
                            ModeloCodigo = "TM10"
                        },
                        new
                        {
                            PlanoComercialCodigo = "PC01.B",
                            Id = 1,
                            ModeloCodigo = "TM01"
                        },
                        new
                        {
                            PlanoComercialCodigo = "PC01.B",
                            Id = 2,
                            ModeloCodigo = "TM02"
                        },
                        new
                        {
                            PlanoComercialCodigo = "PC01.B",
                            Id = 3,
                            ModeloCodigo = "TM03"
                        },
                        new
                        {
                            PlanoComercialCodigo = "PC01.B",
                            Id = 4,
                            ModeloCodigo = "TM04"
                        },
                        new
                        {
                            PlanoComercialCodigo = "PC01.B",
                            Id = 5,
                            ModeloCodigo = "TM05"
                        },
                        new
                        {
                            PlanoComercialCodigo = "PC01.B",
                            Id = 6,
                            ModeloCodigo = "TM06"
                        },
                        new
                        {
                            PlanoComercialCodigo = "PC01.B",
                            Id = 7,
                            ModeloCodigo = "TM07"
                        },
                        new
                        {
                            PlanoComercialCodigo = "PC01.B",
                            Id = 8,
                            ModeloCodigo = "TM08"
                        },
                        new
                        {
                            PlanoComercialCodigo = "PC01.B",
                            Id = 9,
                            ModeloCodigo = "TM09"
                        },
                        new
                        {
                            PlanoComercialCodigo = "PC01.B",
                            Id = 10,
                            ModeloCodigo = "TM10"
                        },
                        new
                        {
                            PlanoComercialCodigo = "PC01.C",
                            Id = 5,
                            ModeloCodigo = "TM05"
                        },
                        new
                        {
                            PlanoComercialCodigo = "PC01.C",
                            Id = 6,
                            ModeloCodigo = "TM06"
                        },
                        new
                        {
                            PlanoComercialCodigo = "PC01.C",
                            Id = 7,
                            ModeloCodigo = "TM07"
                        },
                        new
                        {
                            PlanoComercialCodigo = "PC01.C",
                            Id = 8,
                            ModeloCodigo = "TM08"
                        },
                        new
                        {
                            PlanoComercialCodigo = "PC01.C",
                            Id = 9,
                            ModeloCodigo = "TM09"
                        },
                        new
                        {
                            PlanoComercialCodigo = "PC01.C",
                            Id = 10,
                            ModeloCodigo = "TM10"
                        });
                });

            modelBuilder.Entity("Atelie.Decisoes.Comerciais.PlanoComercial", b =>
                {
                    b.Property<string>("Codigo");

                    b.Property<DateTime>("Data");

                    b.Property<decimal>("Margem");

                    b.Property<decimal>("MargemPercentual");

                    b.Property<string>("Nome");

                    b.Property<decimal>("RendaBrutaMensal");

                    b.Property<decimal?>("TaxaDeMarcacaoSugerida");

                    b.HasKey("Codigo");

                    b.ToTable("PlanosComerciais");

                    b.HasData(
                        new
                        {
                            Codigo = "PC01.A",
                            Data = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Margem = 0m,
                            MargemPercentual = 1.93m,
                            Nome = "Normal",
                            RendaBrutaMensal = 6000m
                        },
                        new
                        {
                            Codigo = "PC01.B",
                            Data = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Margem = 0m,
                            MargemPercentual = 0m,
                            Nome = "Moderado",
                            RendaBrutaMensal = 0m
                        },
                        new
                        {
                            Codigo = "PC01.C",
                            Data = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Margem = 0m,
                            MargemPercentual = 0m,
                            Nome = "Ousado",
                            RendaBrutaMensal = 0m
                        });
                });

            modelBuilder.Entity("Atelie.Cadastro.Modelos.Recurso", b =>
                {
                    b.HasOne("Atelie.Cadastro.Modelos.Modelo", "Modelo")
                        .WithMany("Recursos")
                        .HasForeignKey("ModeloCodigo");
                });

            modelBuilder.Entity("Atelie.Decisoes.Comerciais.Custo", b =>
                {
                    b.HasOne("Atelie.Decisoes.Comerciais.PlanoComercial", "PlanoComercial")
                        .WithMany("Custos")
                        .HasForeignKey("PlanoComercialCodigo")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Atelie.Decisoes.Comerciais.ItemDePlanoComercial", b =>
                {
                    b.HasOne("Atelie.Cadastro.Modelos.Modelo", "Modelo")
                        .WithMany()
                        .HasForeignKey("ModeloCodigo");

                    b.HasOne("Atelie.Decisoes.Comerciais.PlanoComercial", "PlanoComercial")
                        .WithMany("Itens")
                        .HasForeignKey("PlanoComercialCodigo")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
