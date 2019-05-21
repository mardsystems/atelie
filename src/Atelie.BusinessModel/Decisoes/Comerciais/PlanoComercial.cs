using Atelie.Cadastro.Modelos;
using Atelie.Operacoes.Producao;

namespace Atelie.Decisoes.Comerciais
{
    public interface IPlanoComercial
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

        ICusto[] CustosFixos { get; }

        ICusto[] CustosVariaveis { get; }

        IItemDePlanoComercial[] Itens { get; }
    }

    public interface IItemDePlanoComercial
    {
        IPlanoComercial PlanoComercial { get; }

        IModelo Modelo { get; }

        ICustoDeProducao CustoDeProducao { get; }

        decimal PrecoDeVenda { get; }
    }

    public interface ICusto
    {
        string Descricao { get; }

        decimal Valor { get; }

        decimal ValorPercentual { get; }
    }
}