using Atelie.Cadastro.Materiais;
using Atelie.Cadastro.Materiais.Componentes;
using Atelie.Cadastro.Materiais.Fabricantes;
using Atelie.Cadastro.Materiais.Fornecedores;
using Atelie.Cadastro.Modelos;
using Atelie.Cadastro.Modelos.Investimentos;
using Atelie.Cadastro.Modelos.Producao;
using Atelie.Cadastro.Modelos.Producao.Ferramentas;
using Atelie.Cadastro.Unidades;
using Atelie.Comum;
using Atelie.Decisoes.Comerciais;
using Microsoft.EntityFrameworkCore;

namespace Atelie
{
    public class AtelieDbContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }

        public DbSet<Unidade> Unidades { get; set; }

        //public DbSet<Tamanho> Tamanhos { get; set; }

        //public DbSet<CorInterna> CoresInternas { get; set; }

        //public DbSet<CorDeFabricante> CoresDeFabricantes { get; set; }

        public DbSet<Material> Materiais { get; set; }

        public DbSet<FornecimentoDeMaterial> FornecimentosDeMateriais { get; set; }

        public DbSet<Componente> Componentes { get; set; }

        public DbSet<Fabricante> Fabricantes { get; set; }

        public DbSet<FabricacaoDeComponente> FabricacoesDeComponentes { get; set; }

        public DbSet<DisponibilidadeDeMeioDePagamento> DisponibilidadesDeMeiosDePagamento { get; set; }

        public DbSet<Modelo> Modelos { get; set; }

        public DbSet<Investimento> Investimentos { get; set; }

        public DbSet<PlanoComercial> PlanosComerciais { get; set; }

        //public AtelieDbContext()
        //{

        //}

        public AtelieDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder
            //    //.UseLazyLoadingProxies()
            //    .UseSqlite("Data Source=atelie.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Comum.

            //modelBuilder.Entity<Pessoa>()
            //    .OwnsOne(p => p.Endereco);

            //modelBuilder.Entity<PessoaJuridica>()
            //    .OwnsOne(p => p.InformacoesBancarias);

            modelBuilder.Entity<Pessoa>()
                .OwnsMany(p => p.ContatosDeTelefone);

            modelBuilder.Entity<ContatoDeTelefone>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<ContatoDeTelefone>()
                .OwnsOne(p => p.Telefone);

            modelBuilder.Entity<Pessoa>()
                .OwnsMany(p => p.ContatosDeEmail);

            modelBuilder.Entity<ContatoDeEmail>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<ContatoDeEmail>()
                .OwnsOne(p => p.Email);

            modelBuilder.Entity<Unidade>()
                .HasKey(p => p.Sigla);

            // Cadastro - Unidades.

            // Cadastro - Cores.

            //modelBuilder.Entity<CorInterna>()
            //    .HasKey(p => p.Codigo);

            // Cadastro - Materiais - Fabricantes.

            //modelBuilder.Entity<CorDeFabricante>()
            //    .HasKey(p => new { p.FabricanteId, p.ComponenteId, p.CatalogoNome, p.Codigo });

            //modelBuilder.Entity<CorDeFabricante>()
            //    .Property(p => p.CustoPadrao)
            //    .HasColumnType("DECIMAL (18, 2)");

            //modelBuilder.Entity<CorDeFabricante>()
            //    .HasOne(p => p.CorDeUsoInterno)
            //    .WithMany()
            //    .HasForeignKey(p => p.CorDeUsoInternoCodigo);

            //modelBuilder.Entity<CorDeFabricante>()
            //    .HasOne(p => p.Catalogo)
            //    .WithMany(p => p.Cores)
            //    .HasForeignKey(p => new { p.FabricanteId, p.ComponenteId, p.CatalogoNome })
            //    .IsRequired();

            modelBuilder.Entity<FabricacaoDeComponente>()
                .HasKey(p => new { p.FabricanteId, p.ComponenteId });

            modelBuilder.Entity<FabricacaoDeComponente>()
                .HasOne(p => p.Componente)
                .WithMany(p => p.Fabricantes)
                .HasForeignKey(p => p.ComponenteId);

            modelBuilder.Entity<FabricacaoDeComponente>()
                .HasOne(p => p.Fabricante)
                .WithMany(p => p.ComponentesFabricados)
                .HasForeignKey(p => p.FabricanteId);

            //modelBuilder.Entity<Catalogo>()
            //    .HasKey(p => new { p.FabricanteId, p.ComponenteId, p.Nome });

            //modelBuilder.Entity<Catalogo>()
            //    .HasMany(p => p.Cores)
            //    .WithOne(p => p.Catalogo)
            //    .HasForeignKey(p => new { p.FabricanteId, p.ComponenteId, p.CatalogoNome })
            //    .IsRequired();

            //modelBuilder.Entity<DisponibilidadeDeEmbalagem>()
            //    .HasKey(p => new { p.FabricanteId, p.ComponenteId, p.CatalogoNome, p.EmbalagemNome });

            //modelBuilder.Entity<DisponibilidadeDeEmbalagem>()
            //    .OwnsOne(p => p.Embalagem);

            // Cadastro - Materiais - Fornecedores.

            modelBuilder.Entity<FornecimentoDeMaterial>()
                .HasKey(p => new { p.FornecedorId, p.MaterialId });

            //modelBuilder.Entity<FornecimentoDeMaterial>()
            //    .OwnsOne(p => p.TamanhoMinimoPorPedido);

            modelBuilder.Entity<FornecimentoDeMaterial>()
                .Property(p => p.UltimoPreco)
                .HasColumnType("DECIMAL (18, 2)");

            modelBuilder.Entity<DisponibilidadeDeMeioDePagamento>()
                .HasKey(p => new { p.FornecedorId, p.MeioDePagamentoId });

            // Cadastro - Materiais - Fornecedores.

            //modelBuilder.Entity<Material>()
            //    .OwnsOne(p => p.Embalagem);

            modelBuilder.Entity<Material>()
                .Property(p => p.CustoPadrao)
                .HasColumnType("DECIMAL (18, 2)");

            //

            modelBuilder.Entity<AplicacaoDeInvestimento>()
                .HasKey(p => new { p.ModeloCodigo, p.InvestimentoId });

            modelBuilder.Entity<Modelo>()
                .HasKey(p => p.Codigo);

            modelBuilder.Entity<TamanhoDeModelo>()
                .HasKey(p => p.Sigla);

            modelBuilder.Entity<NecessidadeDeFerramentaDeProducao>()
                .HasKey(p => new { p.EtapaDeProducaoId, p.FerramentaId });

            modelBuilder.Entity<NecessidadeDeMaterial>()
                .HasKey(p => new { p.ModeloCodigo, p.MaterialId });

            modelBuilder.Entity<NecessidadeDeTipoDeRecurso>()
                .HasKey(p => new { p.EtapaId, p.TipoDeRecursoId });

            modelBuilder.Entity<PlanoComercial>()
                .OwnsMany(p => p.CustosFixos);

            modelBuilder.Entity<PlanoComercial>()
                .OwnsMany(p => p.CustosVariaveis);

            modelBuilder.Entity<ItemDePlanoComercial>()
                .OwnsOne(p => p.CustoDeProducao);

            modelBuilder.Entity<CustoFixo>()
                .HasKey(p => p.Descricao);

            modelBuilder.Entity<CustoVariavel>()
                .HasKey(p => p.Descricao);

            //


            // Seed.


            //

            modelBuilder.Entity<UnidadeDeMedida>().HasData(
                new UnidadeDeMedida { Sigla = "unid", NomeNoSingular = "Unidade", NomeNoPlural = "Unidades" },
                new UnidadeDeMedida { Sigla = "m", NomeNoSingular = "Metro", NomeNoPlural = "Metros" },
                new UnidadeDeMedida { Sigla = "J", NomeNoSingular = "Jarda", NomeNoPlural = "Jardas" },
                new UnidadeDeMedida { Sigla = "cm", NomeNoSingular = "Centímetro", NomeNoPlural = "Centímetros" }
                //new UnidadeDeMedida { Sigla = "cx", NomeNoSingular = "Caixa", NomeNoPlural = "Caixas" },
                //new UnidadeDeMedida { Sigla = "cn", NomeNoSingular = "Cone", NomeNoPlural = "Cones" },
                //new UnidadeDeMedida { Sigla = "nv", NomeNoSingular = "Novelo", NomeNoPlural = "Novelos" },
                //new UnidadeDeMedida { Sigla = "pc", NomeNoSingular = "Pacote", NomeNoPlural = "Pacotes" },
                //new UnidadeDeMedida { Sigla = "bb", NomeNoSingular = "Bobina", NomeNoPlural = "Bobinas" }
            );

            modelBuilder.Entity<Componente>().HasData(
                new Componente { Id = 1, Nome = "Botão", ComponentePaiId = null, UnidadePadraoSigla = "unid" },
                new Componente { Id = 2, Nome = "Botão com casa", ComponentePaiId = 1, UnidadePadraoSigla = "unid" },
                new Componente { Id = 3, Nome = "Botão de pressão", ComponentePaiId = 1, UnidadePadraoSigla = "unid" },
                new Componente { Id = 4, Nome = "Botão de pressão grande", ComponentePaiId = 3, UnidadePadraoSigla = "unid" },
                new Componente { Id = 5, Nome = "Botão de pressão pequeno", ComponentePaiId = 3, UnidadePadraoSigla = "unid" },
                new Componente { Id = 6, Nome = "Cordão", ComponentePaiId = null, UnidadePadraoSigla = "m" },
                new Componente { Id = 7, Nome = "Cordinha", ComponentePaiId = null, UnidadePadraoSigla = "m" },
                new Componente { Id = 8, Nome = "Cordinha para o tag", ComponentePaiId = 7, UnidadePadraoSigla = "m" },
                new Componente { Id = 9, Nome = "Elástico", ComponentePaiId = null, UnidadePadraoSigla = "m" },
                new Componente { Id = 10, Nome = "Entretela", ComponentePaiId = null, UnidadePadraoSigla = "unid" },
                new Componente { Id = 11, Nome = "Etiqueta", ComponentePaiId = null, UnidadePadraoSigla = "unid" },
                new Componente { Id = 12, Nome = "Etiqueta bordada", ComponentePaiId = 11, UnidadePadraoSigla = "unid" },
                new Componente { Id = 13, Nome = "Etiqueta de composição", ComponentePaiId = 11, UnidadePadraoSigla = "unid" },
                new Componente { Id = 14, Nome = "Etiqueta de tamanho", ComponentePaiId = 11, UnidadePadraoSigla = "unid" },
                new Componente { Id = 15, Nome = "Fio", ComponentePaiId = null, UnidadePadraoSigla = "m" },
                new Componente { Id = 16, Nome = "Fio para overlock", ComponentePaiId = 15, UnidadePadraoSigla = "m" },
                new Componente { Id = 17, Nome = "Ilhós", ComponentePaiId = null, UnidadePadraoSigla = "unid" },
                new Componente { Id = 18, Nome = "Linha", ComponentePaiId = null, UnidadePadraoSigla = "m" },
                new Componente { Id = 19, Nome = "Papel", ComponentePaiId = null, UnidadePadraoSigla = "m" },
                new Componente { Id = 20, Nome = "Papel de embrulho", ComponentePaiId = 19, UnidadePadraoSigla = "m" },
                new Componente { Id = 21, Nome = "Plástico", ComponentePaiId = null, UnidadePadraoSigla = "unid" },
                new Componente { Id = 22, Nome = "Sacola plástica", ComponentePaiId = 21, UnidadePadraoSigla = "unid" },
                new Componente { Id = 23, Nome = "Sacos plástica", ComponentePaiId = 21, UnidadePadraoSigla = "unid" },
                new Componente { Id = 24, Nome = "Bobinas plásticas", ComponentePaiId = 21, UnidadePadraoSigla = "unid" },
                new Componente { Id = 25, Nome = "Tag", ComponentePaiId = null, UnidadePadraoSigla = "unid" },
                new Componente { Id = 26, Nome = "Tecido", ComponentePaiId = null, UnidadePadraoSigla = "m" },
                new Componente { Id = 27, Nome = "Tecido (brim)", ComponentePaiId = 26, UnidadePadraoSigla = "m" },
                new Componente { Id = 28, Nome = "Tecido (cupro)", ComponentePaiId = 26, UnidadePadraoSigla = "m" },
                new Componente { Id = 29, Nome = "Tecido (seda)", ComponentePaiId = 26, UnidadePadraoSigla = "m" },
                new Componente { Id = 30, Nome = "Tecido (seda lavada)", ComponentePaiId = 26, UnidadePadraoSigla = "m" },
                new Componente { Id = 31, Nome = "Viés", ComponentePaiId = null, UnidadePadraoSigla = "unid" },
                new Componente { Id = 32, Nome = "Viés para cordão", ComponentePaiId = 31, UnidadePadraoSigla = "unid" },
                new Componente { Id = 33, Nome = "Ziper", ComponentePaiId = null, UnidadePadraoSigla = "unid" }
            );

            modelBuilder.Entity<Fabricante>().HasData(
                new Fabricante { Id = 1, Nome = "Genérico", Marca = "Genérica", Site = null, },
                new Fabricante { Id = 2, Nome = "Baxmann", Marca = "Baxmann", Site = "https://www.baxmann.com.br", },
                new Fabricante { Id = 3, Nome = "Coats", Marca = "Coats", Site = "http://www.coatscorrente.com.br", },
                new Fabricante { Id = 4, Nome = "Cordex", Marca = "Cordex", Site = "https://www.cordex.com.br", },
                new Fabricante { Id = 5, Nome = "Eberler Fashion", Marca = "Eberler", Site = "http://www.eberlefashion.com.br", }, //http://www.eberle.com.br
                new Fabricante { Id = 6, Nome = "Helvetia", Marca = "Helvetia", Site = "https://www.helvetia.com.br", },
                new Fabricante { Id = 7, Nome = "Lainière de Picardie", Marca = "Picardie", Site = "http://www.lainieredepicardie.com.br", },
                new Fabricante { Id = 8, Nome = "Lamar Etiquetas", Marca = "Lamar", Site = "http://www.etiquetaslamar.com.br", },
                new Fabricante { Id = 9, Nome = "Linhas Bonfio", Marca = "Bonfio", Site = "http://www.bonfio.com.br", },
                new Fabricante { Id = 10, Nome = "Linhas Setta", Marca = "Setta", Site = "http://www.setta.com.br", },
                new Fabricante { Id = 11, Nome = "RenauxView", Marca = "RenauxView", Site = "https://renauxview.com.br", },
                new Fabricante { Id = 12, Nome = "Speedpel", Marca = "Speedpel", Site = "http://www.speedpel.com.br", },
                new Fabricante { Id = 13, Nome = "Tekla", Marca = "Tekla", Site = "http://www.tekla.com.br", },
                new Fabricante { Id = 14, Nome = "Werner", Marca = "Werner", Site = "https://wernertecidos.com.br", },
                new Fabricante { Id = 15, Nome = "YKK", Marca = "YKK", Site = "https://www.ykkfastening.com", },
                new Fabricante { Id = 16, Nome = "Helioplast", Marca = "Helioplast", Site = "http://helioplast.com.br", },
                new Fabricante { Id = 17, Nome = "Público Alvo Embalagens", Marca = "Público Alvo", Site = "https://www.publicoalvoembalagens.com.br", }
            );

            modelBuilder.Entity<FabricacaoDeComponente>().HasData(
                new FabricacaoDeComponente { FabricanteId = 9, ComponenteId = 18 },
                new FabricacaoDeComponente { FabricanteId = 10, ComponenteId = 18 },
                new FabricacaoDeComponente { FabricanteId = 16, ComponenteId = 22 },
                new FabricacaoDeComponente { FabricanteId = 16, ComponenteId = 23 },
                new FabricacaoDeComponente { FabricanteId = 16, ComponenteId = 24 },
                new FabricacaoDeComponente { FabricanteId = 17, ComponenteId = 22 }
            );

            //modelBuilder.Entity<Catalogo>().HasData(
            //    new Catalogo
            //    {
            //        FabricanteId = 10,
            //        ComponenteId = 18,
            //        Nome = "Xik poliéster",
            //        Site = "http://setta.com.br/produto/xik-poliester",
            //        //Embalagens = new HashSet<DisponibilidadeDeEmbalagem>
            //        //{
            //        //    new DisponibilidadeDeEmbalagem { FabricanteId = 15, ComponenteId = 2, CatalogoNome = "Xik poliéster", EmbalagemNome = "Etiqueta 120 - Cones c/ 2000 Jardas", Embalagem = new Embalagem{ UnidadeSigla = "pc", Valor = 10, UnidadeBaseSigla = "cn"  } }
            //        //}
            //    },
            //    new Catalogo
            //    {
            //        FabricanteId = 16,
            //        ComponenteId = 22,
            //        Nome = "Sacos com aba - PEDB (polietileno de baixa densidade)",
            //        Site = "http://helioplast.com.br/produtos/sacos-plasticos/com-aba",
            //        //Cores = new HashSet<CorDeFabricante>
            //        //{
            //        //    new CorDeFabricante { FabricanteId = 16, ComponenteId = 22, Codigo = "Transparente", Nome = "Transparente", },
            //        //    new CorDeFabricante { FabricanteId = 16, ComponenteId = 22, Codigo = "+30Cores", Nome = "+30Cores", }
            //        //},
            //    },
            //    new Catalogo
            //    {
            //        FabricanteId = 16,
            //        ComponenteId = 22,
            //        Nome = "Sacos com aba - PEAD (polietileno de alta densidade)",
            //        Site = "http://helioplast.com.br/produtos/sacos-plasticos/com-aba",
            //        //Cores = new HashSet<CorDeFabricante>
            //        //{
            //        //    new CorDeFabricante { FabricanteId = 16, ComponenteId = 22, Codigo = "Transparente", Nome = "Transparente", },
            //        //    new CorDeFabricante { FabricanteId = 16, ComponenteId = 22, Codigo = "+30Cores", Nome = "+30Cores", }
            //        //}
            //    },
            //    new Catalogo
            //    {
            //        FabricanteId = 16,
            //        ComponenteId = 22,
            //        Nome = "Sacos com aba - PP (polipropileno)",
            //        Site = "http://helioplast.com.br/produtos/sacos-plasticos/com-aba",
            //        //Cores = new HashSet<CorDeFabricante>
            //        //{
            //        //    new CorDeFabricante { FabricanteId = 16, ComponenteId = 22, Codigo = "Padrão", Nome = "Padrão", },
            //        //}
            //    },
            //    new Catalogo
            //    {
            //        FabricanteId = 16,
            //        ComponenteId = 22,
            //        Nome = "Sacos com aba - BOPP (polipropileno bi orientado)",
            //        Site = "http://helioplast.com.br/produtos/sacos-plasticos/com-aba",
            //        //Cores = new HashSet<CorDeFabricante>
            //        //{
            //        //    new CorDeFabricante { FabricanteId = 16, ComponenteId = 22, Codigo = "Padrão", Nome = "Padrão", },
            //        //}
            //    },
            //    new Catalogo
            //    {
            //        FabricanteId = 17,
            //        ComponenteId = 22,
            //        Nome = "Plástico fosco transparente (alta densidade) medindo 46 x 60 x 18 com alça especial",
            //        Site = null,
            //        //Cores = new HashSet<CorDeFabricante>
            //        //{
            //        //    new CorDeFabricante { FabricanteId = 17, ComponenteId = 22, Codigo = "Transparente", Nome = "Plástico fosco transparente", },
            //        //}
            //    },
            //    new Catalogo
            //    {
            //        FabricanteId = 17,
            //        ComponenteId = 22,
            //        Nome = "Sacola em plástico bolha transparente com alça de mão branca",
            //        Site = "https://www.publicoalvoembalagens.com.br/produtos/sacola-em-plastico-bolha-transparente-com-alca-de-mao-branca-/133",
            //        //Cores = new HashSet<CorDeFabricante>
            //        //{
            //        //    new CorDeFabricante { FabricanteId = 17, ComponenteId = 22, Codigo = "Transparente", Nome = "Transparente", },
            //        //},
            //        //Embalagens = new HashSet<DisponibilidadeDeEmbalagem>
            //        //{
            //        //    new DisponibilidadeDeEmbalagem { FabricanteId = 15, ComponenteId = 2, CatalogoNome = "" }
            //        //}
            //    }
            //);

            //modelBuilder.Entity<CorDeFabricante>().HasData(
            //    new CorDeFabricante { FabricanteId = 10, ComponenteId = 18, Codigo = "0011", CatalogoNome = "Xik poliéster", Nome = "Preto", },
            //    new CorDeFabricante { FabricanteId = 10, ComponenteId = 18, Codigo = "0012", CatalogoNome = "Xik poliéster", Nome = "Marinho Forte", },
            //    new CorDeFabricante { FabricanteId = 10, ComponenteId = 18, Codigo = "0421", CatalogoNome = "Xik poliéster", Nome = "Fuzil", },
            //    new CorDeFabricante { FabricanteId = 10, ComponenteId = 18, Codigo = "0428", CatalogoNome = "Xik poliéster", Nome = "Fox", }
            //);

            modelBuilder.Entity<Fornecedor>().HasData(
                new Fornecedor { Id = 1, Nome = "Werner", Site = "https://wernertecidos.com.br" },
                new Fornecedor { Id = 2, Nome = "Armarinhos 25", Site = "https://www.armarinhos25.com.br" },
                new Fornecedor { Id = 3, Nome = "Casa Ferro", Site = "https://www.armarinhos25.com.br" },
                new Fornecedor { Id = 4, Nome = "Helvetia", Site = "https://www.helvetia.com.br" },
                new Fornecedor { Id = 5, Nome = "Lamar Etiquetas", Site = "http://www.etiquetaslamar.com.br" },
                new Fornecedor { Id = 6, Nome = "Motta Carvalho", Site = null },
                new Fornecedor { Id = 7, Nome = "Amsterdam", Site = null },
                new Fornecedor { Id = 8, Nome = "Caçula de São Cristovão", Site = null },
                new Fornecedor { Id = 9, Nome = "Helioplast", Site = "http://helioplast.com.br" },
                new Fornecedor { Id = 10, Nome = "Público Alvo", Site = "https://www.publicoalvoembalagens.com.br" },
                new Fornecedor { Id = 11, Nome = "Speedpel", Site = "http://www.speedpel.com.br" },
                new Fornecedor { Id = 12, Nome = "Oeste Aviamentos", Site = "https://www.oesteaviamentos.com" }
            );

            modelBuilder.Entity<Material>().HasData(
                new Material { Id = 1, Nome = "Linha Xik Poliester 2000J N. 120", FabricanteId = 10, ComponenteId = 18, UnidadeSigla = "m", Descricao = null },
                new Material { Id = 2, Nome = "Linha Xik Poliester 5000J N. 120", FabricanteId = 10, ComponenteId = 18, UnidadeSigla = "m", Descricao = null },
                new Material { Id = 3, Nome = "Entretela 2805/325 da marca Lainière, 1,50cmX25cm", FabricanteId = 7, ComponenteId = 10, UnidadeSigla = "unid", Descricao = null },
                new Material { Id = 4, Nome = "Fio da marca Bonfio 300g", FabricanteId = 9, ComponenteId = 16, UnidadeSigla = "m", Descricao = null },
                new Material { Id = 5, Nome = "Fio Soltex 300g da marca Coats Corrente", FabricanteId = 3, ComponenteId = 16, UnidadeSigla = "m", Descricao = null },
                new Material { Id = 6, Nome = "Tecido artigo 1198/6", FabricanteId = 14, ComponenteId = 24, UnidadeSigla = "m", Descricao = null },
                new Material { Id = 7, Nome = "Tecido artigo 1198/6 com defeito", FabricanteId = 14, ComponenteId = 24, UnidadeSigla = "m", Descricao = null },
                new Material { Id = 8, Nome = "Sacos com aba - PEAD (polietileno de alta densidade)", FabricanteId = 16, ComponenteId = 22, UnidadeSigla = "unid", Descricao = "São entregues em pacotes de papel craft com quantidades programadas pelos clientes ou em caixas de papelão (sob consulta)." },
                new Material { Id = 9, Nome = "Plástico fosco transparente (alta densidade) medindo 46 x 60 x 18 com alça especial", FabricanteId = 17, ComponenteId = 22, UnidadeSigla = "unid", Descricao = null }
            );

            //modelBuilder.Entity<FornecimentoDeMaterial>().HasData(
            //    new FornecimentoDeMaterial { FornecedorId = 12, MaterialId = 1, NomeComercial = "Linha Setta XIK Poliéster 120 Cone com 2000 Yd (Jardas)", UltimoPreco = 3.69m, TamanhoMinimoPorPedido = new Tamanho { } },
            //    new FornecimentoDeMaterial { FornecedorId = 2, MaterialId = 1, NomeComercial = "Linha de poliéster para costura Setta ref. Xik 120 cores c/ 2000 j", UltimoPreco = 3.69m },
            //    new FornecimentoDeMaterial { FornecedorId = 8, MaterialId = 1, NomeComercial = "Linha Xik Poliester 2000J N. 120, marca Linhas Setta" },
            //    new FornecimentoDeMaterial { FornecedorId = 8, MaterialId = 2, NomeComercial = "Linha Xik Poliester 5000J N. 120, marca Linhas Setta" },
            //    new FornecimentoDeMaterial { FornecedorId = 9, MaterialId = 8, NomeComercial = "Sacos com aba - PEAD (polietileno de alta densidade)?" },
            //    new FornecimentoDeMaterial { FornecedorId = 10, MaterialId = 9, NomeComercial = "Plástico fosco transparente (alta densidade) medindo 46 x 60 x 18 com alça especial?" }
            //);

            modelBuilder.Entity<Modelo>().HasData(
                new Modelo { Codigo = "1", Nome = "TatiModel"}
            );
        }
    }
}
