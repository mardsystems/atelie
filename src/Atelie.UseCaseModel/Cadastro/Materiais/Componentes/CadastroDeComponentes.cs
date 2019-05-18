using System.Threading.Tasks;

namespace Atelie.Cadastro.Materiais.Componentes
{
    public interface ICadastroDeComponentes
    {
        Task<IRespostaDeCadastroDeComponente> CadastraComponente(ISolicitacaoDeCadastroDeComponente solicitacao);

        Task<IRespostaDeCadastroDeComponente> AtualizaComponente(int componenteId, ISolicitacaoDeCadastroDeComponente solicitacao);

        Task ExcluiComponente(int componenteId);
    }

    public interface ISolicitacaoDeCadastroDeComponente
    {
        int Id { get; }

        string Nome { get; }

        int? ComponentePaiId { get; }

        string UnidadePadraoSigla { get; }
    }

    public interface IRespostaDeCadastroDeComponente
    {
        int Id { get; }
    }

    public class SolicitacaoDeCadastroDeComponente : ISolicitacaoDeCadastroDeComponente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int? ComponentePaiId { get; set; }

        public string UnidadePadraoSigla { get; set; }
    }

    public class RespostaDeCadastroDeComponente : IRespostaDeCadastroDeComponente
    {
        public int Id { get; internal set; }
    }
}
