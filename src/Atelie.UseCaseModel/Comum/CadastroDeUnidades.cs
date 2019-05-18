using System.Threading.Tasks;

namespace Atelie.Comum
{
    public interface ICadastroDeUnidades<TUnidade> where TUnidade : IUnidade
    {
        Task<IRespostaDeCadastroDeUnidade> CadastraUnidade(ISolicitacaoDeCadastroDeUnidade solicitacao);

        Task<IRespostaDeCadastroDeUnidade> AtualizaUnidade(string sigla, ISolicitacaoDeCadastroDeUnidade solicitacao);

        Task ExcluiUnidade(string sigla);
    }

    public interface ISolicitacaoDeCadastroDeUnidade
    {
        string Sigla { get; }

        string NomeNoSingular { get; }

        string NomeNoPlural { get; }
    }

    public interface IRespostaDeCadastroDeUnidade
    {
        string Sigla { get; }
    }

    public abstract class SolicitacaoDeCadastroDeUnidade : ISolicitacaoDeCadastroDeUnidade
    {
        public string Sigla { get; set; }

        public string NomeNoSingular { get; set; }

        public string NomeNoPlural { get; set; }
    }

    public abstract class RespostaDeCadastroDeUnidade : IRespostaDeCadastroDeUnidade
    {
        public string Sigla { get; internal set; }
    }
}
