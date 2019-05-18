namespace Atelie.Operacoes.Producao
{
    public interface ICustoDeProducao
    {
        decimal CustoDeComposicao { get; }

        decimal CustoDeConfeccao { get; }

        decimal Valor { get; }

        decimal x10 { get; }
    }
}
