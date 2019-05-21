using Atelie.Comum;
using System.Threading.Tasks;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public interface ICadastroDeFabricacoesDeComponentes
    {
        Task<IRespostaDeCadastroDeFabricacaoDeComponente> CadastraFabricacaoDeComponente(ISolicitacaoDeCadastroDeFabricacaoDeComponente solicitacao);

        Task<IRespostaDeCadastroDeFabricacaoDeComponente> AtualizaFabricacaoDeComponente(int fabricanteId, int componenteId, ISolicitacaoDeCadastroDeFabricacaoDeComponente solicitacao);

        Task ExcluiFabricacaoDeComponente(int fabricanteId, int componenteId);

        Task ExcluiFabricacaoDeComponentePorFabricante(int fabricanteId);

        ////

        //Task<IRespostaDeCadastroDeCatalogo> CadastraCatalogo(ISolicitacaoDeCadastroDeCatalogo solicitacao);

        //Task<IRespostaDeCadastroDeCatalogo> AtualizaCatalogo(int fabricanteId, int componenteId, string nome, ISolicitacaoDeCadastroDeCatalogo solicitacao);

        //Task ExcluiCatalogo(int fabricanteId, int componenteId, string nome);

        ////

        //Task<IRespostaDeDefinicaoDeCorNoCatalogo> DefineCorNoCatalogo(ISolicitacaoDeDefinicaoDeCorNoCatalogo solicitacao);

        //Task RemoveDefinicaoDeCorDoCatalogo(int fabricanteId, int componenteId, string catalogoNome, string embalagemNome);

        ////

        //Task<IRespostaDeDisponibilizacaoDeEmbalagemNoCatalogo> DisponibilizaEmbalagemNoCatalogo(ISolicitacaoDeDisponibilizacaoDeEmbalagemNoCatalogo solicitacao);

        //Task ExcluiDisponibilidadeDeEmbalagemDoCatalogo(int fabricanteId, int componenteId, string catalogoNome, string embalagemNome);
    }

    //

    public interface ISolicitacaoDeCadastroDeFabricacaoDeComponente
    {
        int FabricanteId { get; }

        int ComponenteId { get; }
    }

    public interface IRespostaDeCadastroDeFabricacaoDeComponente
    {

    }

    public class SolicitacaoDeCadastroDeFabricacaoDeComponente : ISolicitacaoDeCadastroDeFabricacaoDeComponente
    {
        public int FabricanteId { get; set; }

        public int ComponenteId { get; set; }
    }

    public class RespostaDeCadastroDeFabricacaoDeComponente : IRespostaDeCadastroDeFabricacaoDeComponente
    {

    }

    ////

    //public interface ISolicitacaoDeCadastroDeCatalogo
    //{
    //    int FabricanteId { get; }

    //    int ComponenteId { get; }

    //    string Nome { get; }
    //}

    //public interface IRespostaDeCadastroDeCatalogo
    //{

    //}

    //public class SolicitacaoDeCadastroDeCatalogo : ISolicitacaoDeCadastroDeCatalogo
    //{
    //    public int FabricanteId { get; set; }

    //    public int ComponenteId { get; set; }

    //    public string Nome { get; set; }
    //}

    //public class RespostaDeCadastroDeCatalogo : IRespostaDeCadastroDeCatalogo
    //{

    //}

    ////

    //public interface ISolicitacaoDeDefinicaoDeCorNoCatalogo : ISolicitacaoDeCadastroDeCor
    //{
    //    int FabricanteId { get; }

    //    int ComponenteId { get; }

    //    string CatalogoNome { get; }

    //    string Categoria { get; }

    //    string Localizacao { get; }

    //    decimal? CustoPadrao { get; }

    //    string CorDeUsoInternoCodigo { get; }
    //}

    //public interface IRespostaDeDefinicaoDeCorNoCatalogo : IRespostaDeCadastroDeCor
    //{

    //}

    //public class SolicitacaoDeDefinicaoDeCorNoCatalogo : SolicitacaoDeCadastroDeCor, ISolicitacaoDeDefinicaoDeCorNoCatalogo
    //{
    //    public int FabricanteId { get; set; }

    //    public int ComponenteId { get; set; }

    //    public string CatalogoNome { get; set; }

    //    public string Categoria { get; set; }

    //    public string Localizacao { get; set; }

    //    public decimal? CustoPadrao { get; set; }

    //    public string CorDeUsoInternoCodigo { get; set; }
    //}

    //public class RespostaDeDefinicaoDeCorNoCatalogo : RespostaDeCadastroDeCor, IRespostaDeDefinicaoDeCorNoCatalogo
    //{

    //}

    ////

    //public interface ISolicitacaoDeDisponibilizacaoDeEmbalagemNoCatalogo
    //{
    //    int FabricanteId { get; }

    //    int ComponenteId { get; }

    //    string CatalogoNome { get; }

    //    string EmbalagemNome { get; }

    //    string UnidadeSigla { get; }

    //    double Valor { get; }

    //    string UnidadeBaseSigla { get; }
    //}

    //public interface IRespostaDeDisponibilizacaoDeEmbalagemNoCatalogo
    //{

    //}

    //public class SolicitacaoDeDisponibilizacaoDeEmbalagemNoCatalogo : ISolicitacaoDeDisponibilizacaoDeEmbalagemNoCatalogo
    //{
    //    public int FabricanteId { get; set; }

    //    public int ComponenteId { get; set; }

    //    public string CatalogoNome { get; set; }

    //    public string EmbalagemNome { get; set; }

    //    public string UnidadeSigla { get; set; }

    //    public double Valor { get; set; }

    //    public string UnidadeBaseSigla { get; set; }
    //}

    //public class RespostaDeDisponibilizacaoDeEmbalagemNoCatalogo : IRespostaDeDisponibilizacaoDeEmbalagemNoCatalogo
    //{

    //}
}
