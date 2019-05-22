using Atelie.Cadastro.Modelos;
using Atelie.Operacoes.Producao;

namespace Atelie.Decisoes.Comerciais
{
    public class PlanoComercialDTO : IPlanoComercial
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

        public CustoDTO[] CustosFixos { get; set; }

        public CustoDTO[] CustosVariaveis { get; set; }

        public ItemDePlanoComercialDTO[] Itens { get; set; }

        ICusto[] IPlanoComercial.CustosFixos => CustosFixos;

        ICusto[] IPlanoComercial.CustosVariaveis => CustosVariaveis;

        IItemDePlanoComercial[] IPlanoComercial.Itens => Itens;
    }

    public class ItemDePlanoComercialDTO : IItemDePlanoComercial
    {
        public PlanoComercialDTO PlanoComercial { get; set; }

        public ModeloDTO Modelo { get; set; }

        public CustoDeProducaoDTO CustoDeProducao { get; set; }

        public decimal PrecoDeVenda { get; set; }

        IPlanoComercial IItemDePlanoComercial.PlanoComercial => PlanoComercial;

        IModelo IItemDePlanoComercial.Modelo => Modelo;

        ICustoDeProducao IItemDePlanoComercial.CustoDeProducao => CustoDeProducao;
    }

    public class CustoDTO : ICusto
    {
        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public decimal ValorPercentual { get; set; }
    }
}
