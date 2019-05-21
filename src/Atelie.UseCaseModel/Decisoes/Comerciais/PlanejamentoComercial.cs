using System.Threading.Tasks;

namespace Atelie.Decisoes.Comerciais
{
    public interface IPlanejamentoComercial
    {
        Task<IRespostaDeCriacaoDePlanoComercial> CriaPlanoComercial(ISolicitacaoDeCriacaoDePlanoComercial solicitacao);

        Task<IRespostaDeCriacaoDePlanoComercial> AtualizaPlanoComercial(string planoComercialId, ISolicitacaoDeCriacaoDePlanoComercial solicitacao);

        Task ExcluiPlanoComercial(string planoComercialId);
    }

    //

    public interface ISolicitacaoDeCriacaoDePlanoComercial
    {
        string Id { get; }

        string Nome { get; }

        decimal ReceitaBrutaMensal { get; }

        decimal CustoFixo { get; }

        decimal CustoFixoPercentual { get; }

        decimal CustoVariavel { get; }

        decimal CustoPercentual { get; }

        decimal Margem { get; }

        decimal MargemPercentual { get; }

        decimal TaxaDeMarcacao { get; }
    }

    public interface IRespostaDeCriacaoDePlanoComercial
    {
        string Id { get; }
    }

    public class SolicitacaoDeCriacaoDePlanoComercial : ISolicitacaoDeCriacaoDePlanoComercial
    {
        public string Id { get; set; }

        public string Nome { get; set; }

        public decimal ReceitaBrutaMensal { get; set; }

        public decimal CustoFixo { get; set; }

        public decimal CustoFixoPercentual { get; set; }

        public decimal CustoVariavel { get; set; }

        public decimal CustoPercentual { get; set; }

        public decimal Margem { get; set; }

        public decimal MargemPercentual { get; set; }

        public decimal TaxaDeMarcacao { get; set; }
    }

    public class RespostaDeCriacaoDePlanoComercial : IRespostaDeCriacaoDePlanoComercial
    {
        public string Id { get; internal set; }
    }
}
