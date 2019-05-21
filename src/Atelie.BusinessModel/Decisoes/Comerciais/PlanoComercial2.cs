using Atelie.Cadastro.Modelos;
using Atelie.Operacoes.Producao;

namespace Atelie.Decisoes.Comerciais
{
    public interface IPlanoComercial
    {
        int Id { get; }

        string Nome { get; }

        IItemDePlanoComercial[] Itens { get; }
    }

    public interface IItemDePlanoComercial
    {
        IPlanoComercial PlanoComercial { get; }

        IModelo Modelo { get; }

        IBenchmarks Benchmarks { get; }

        ICustoDeProducao CustoDeProducao { get; }

        IPrecoDePrateleiraDesejado PrecoDePrateleiraDesejado { get; }

        decimal PrecoDeAtacado { get; }

        decimal PrecoDeAtacado2 { get; }

        decimal MargemDoAtelieAtacado { get; }

        decimal PrecoDeAtacado3 { get; }

        decimal MargemDoAtelie { get; }

        decimal MargemDoAtelie2 { get; }

        IPrecoDeConsignacao PrecoDeConsignacao { get; }

        decimal PrecoDeConsignacao2 { get; }

        decimal MargemDoAtelieDeConsignacao { get; }

        decimal PercentualDeRecomendacao { get; }
    }

    public interface IBenchmarks
    {
        string Produto { get; }

        decimal FaixaDePrecoDoProduto { get; }

        decimal PrecoDeVarejo { get; }

        decimal VolumeDeVendas1oAno { get; }

        decimal VolumeDeVendas2oAno { get; }

        decimal VolumeDeVendas3oAno { get; }
    }

    public interface IPrecoDePrateleiraDesejado
    {
        decimal Valor { get; }
    }

    public interface IPrecoDeConsignacao
    {
        decimal Valor { get; }
    }
}