namespace Atelie.Cadastro.Modelos.Investimentos
{
    public interface IAplicacaoDeInvestimento
    {
        IModelo Modelo { get; }

        IInvestimento Investimento { get; }

        int Peso { get; }

        decimal CustoProporcional { get; }
    }
}
