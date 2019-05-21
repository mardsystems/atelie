namespace Atelie.Cadastro.Modelos.Investimentos
{
    public class AplicacaoDeInvestimento : IAplicacaoDeInvestimento
    {
        public virtual Modelo Modelo { get; internal set; }

        public virtual Investimento Investimento { get; internal set; }

        public int Peso { get; internal set; }

        public decimal CustoProporcional { get; internal set; }

        IModelo IAplicacaoDeInvestimento.Modelo => Modelo;

        IInvestimento IAplicacaoDeInvestimento.Investimento => Investimento;

        public string ModeloCodigo { get; internal set; }

        public int InvestimentoId { get; internal set; }
    }
}
