using Atelie.Cadastro.Modelos;
using Atelie.Operacoes.Producao;
using System.Collections.Generic;
using System.Linq;

namespace Atelie.Decisoes.Comerciais
{
    public class PlanoComercial : IPlanoComercial
    {
        public int Id { get; internal set; }

        public string Nome { get; internal set; }

        /// <summary>
        /// 0.90
        /// </summary>
        public decimal PercentualDePrecoDeAtacado { get; internal set; }

        /// <summary>
        /// 3
        /// </summary>
        public decimal RazaoDoPrecoDeAtacado3 { get; internal set; }


        /// <summary>
        /// 0.45.
        /// </summary>
        public decimal PercentualDePrecoDeConsignacao { get; internal set; }

        public virtual ICollection<ItemDePlanoComercial> Itens { get; internal set; }

        public PlanoComercial()
        {
            Itens = new HashSet<ItemDePlanoComercial>();
        }

        #region IPlanoComercial

        IItemDePlanoComercial[] IPlanoComercial.Itens => Itens.ToArray();

        #endregion
    }

    public class ItemDePlanoComercial : IItemDePlanoComercial
    {
        public PlanoComercial PlanoComercial { get; internal set; }

        public Modelo Modelo { get; internal set; }

        public Benchmarks Benchmarks { get; internal set; }

        public CustoDeProducao CustoDeProducao { get; internal set; }

        public PrecoDePrateleiraDesejado PrecoDePrateleiraDesejado { get; internal set; }

        /// <summary>
        /// 0.90 <= 1 / 1.1
        /// </summary>
        public decimal PrecoDeAtacado { get { return PrecoDeConsignacao.Valor * PlanoComercial.PercentualDePrecoDeAtacado; } }

        public decimal PrecoDeAtacado2 { get { return PrecoDeAtacado - CustoDeProducao.Valor; } }

        /// <summary>
        /// Percentual.
        /// </summary>
        public decimal MargemDoAtelieAtacado { get { return PrecoDeAtacado2 / CustoDeProducao.Valor; } }

        public decimal PrecoDeAtacado3 { get { return PrecoDePrateleiraDesejado.Valor / PlanoComercial.RazaoDoPrecoDeAtacado3; } }

        public decimal MargemDoAtelie { get { return PrecoDeAtacado3 - CustoDeProducao.Valor; } }

        /// <summary>
        /// Percentual.
        /// </summary>
        public decimal MargemDoAtelie2 { get { return MargemDoAtelie / CustoDeProducao.Valor; } }

        /// <summary>
        /// 0.45 <= 1 / 2.2
        /// </summary>
        public PrecoDeConsignacao PrecoDeConsignacao { get { return new PrecoDeConsignacao { Valor = PrecoDePrateleiraDesejado.Valor * PlanoComercial.PercentualDePrecoDeConsignacao }; } }

        public decimal PrecoDeConsignacao2 { get { return PrecoDeConsignacao.Valor - CustoDeProducao.Valor; } }

        /// <summary>
        /// Percentual.
        /// </summary>
        public decimal MargemDoAtelieDeConsignacao { get { return PrecoDeConsignacao2 / CustoDeProducao.Valor; } }

        /// <summary>
        /// Percentual. ?
        /// </summary>
        public decimal PercentualDeRecomendacao { get { return ((CustoDeProducao.x10 - PrecoDePrateleiraDesejado.Valor) / PrecoDePrateleiraDesejado.Valor) * 100; } }

        #region IItemDePlanoComercial

        IPlanoComercial IItemDePlanoComercial.PlanoComercial => PlanoComercial;

        IModelo IItemDePlanoComercial.Modelo => Modelo;

        IBenchmarks IItemDePlanoComercial.Benchmarks => Benchmarks;

        ICustoDeProducao IItemDePlanoComercial.CustoDeProducao => CustoDeProducao;

        IPrecoDePrateleiraDesejado IItemDePlanoComercial.PrecoDePrateleiraDesejado => PrecoDePrateleiraDesejado;

        IPrecoDeConsignacao IItemDePlanoComercial.PrecoDeConsignacao => PrecoDeConsignacao;

        #endregion
    }

    public class Benchmarks : IBenchmarks
    {
        /// <summary>
        /// Marcas e seus produtos exemplares.
        /// </summary>
        public string Produto { get; internal set; }

        /// <summary>
        /// Faixa de preço dos produtos benchmarks.
        /// </summary>
        public decimal FaixaDePrecoDoProduto { get; internal set; }

        /// <summary>
        /// Preço de pratileira planejado.
        /// </summary>
        public decimal PrecoDeVarejo { get; internal set; }

        /// <summary>
        /// Número de unidades vendidas no primeiro ano.
        /// </summary>
        public decimal VolumeDeVendas1oAno { get; internal set; }

        /// <summary>
        /// Número de unidades vendidas no segundo ano.
        /// </summary>
        public decimal VolumeDeVendas2oAno { get; internal set; }

        /// <summary>
        /// Número de unidades vendidas no terceiro ano.
        /// </summary>
        public decimal VolumeDeVendas3oAno { get; internal set; }
    }

    public class PrecoDePrateleiraDesejado : IPrecoDePrateleiraDesejado
    {
        public decimal Valor { get; internal set; }
    }

    public class PrecoDeConsignacao : IPrecoDeConsignacao
    {
        public decimal Valor { get; internal set; }
    }
}
