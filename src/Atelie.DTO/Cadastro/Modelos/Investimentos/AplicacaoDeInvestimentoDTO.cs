namespace Atelie.Cadastro.Modelos.Investimentos
{
    public class AplicacaoDeInvestimentoDTO : IAplicacaoDeInvestimento
    {
        public ModeloDTO Modelo { get; set; }

        public InvestimentoDTO Investimento { get; set; }

        public int Peso { get; set; }

        public decimal CustoProporcional { get; set; }

        IModelo IAplicacaoDeInvestimento.Modelo => Modelo;

        IInvestimento IAplicacaoDeInvestimento.Investimento => Investimento;
    }
}
