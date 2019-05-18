using System.Threading.Tasks;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public interface ICadastroDeFabricantes
    {
        Task<IRespostaDeCadastroDeFabricante> CadastraFabricante(ISolicitacaoDeCadastroDeFabricante solicitacao);

        Task<IRespostaDeCadastroDeFabricante> AtualizaFabricante(int fabricanteId, ISolicitacaoDeCadastroDeFabricante solicitacao);

        Task ExcluiFabricante(int fabricanteId);
    }

    //

    public interface ISolicitacaoDeCadastroDeFabricante
    {
        int Id { get; }

        string Nome { get; }

        string Marca { get; }

        string Site { get; }
    }

    public interface IRespostaDeCadastroDeFabricante
    {
        int Id { get; }
    }

    public class SolicitacaoDeCadastroDeFabricante : ISolicitacaoDeCadastroDeFabricante
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Marca { get; set; }

        public string Site { get; set; }
    }

    public class RespostaDeCadastroDeFabricante : IRespostaDeCadastroDeFabricante
    {
        public int Id { get; internal set; }
    }
}
